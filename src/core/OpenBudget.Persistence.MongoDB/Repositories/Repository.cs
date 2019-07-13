using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using OpenBudget.Application.Infrastructure.Persistence;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Persistence.MongoDB.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : EntityBase
  {
    protected IMongoCollection<TEntity> Collection { get; }

    public Repository(IMongoDatabase database, string collectionName)
    {
      this.Collection = database.GetCollection<TEntity>(collectionName);
    }

    public Task<bool> CheckExistsAsync(Guid id)
    {
      return this.Collection.Find(e => e.Id == id).AnyAsync();
    }

    public Task<long> CountAsync()
    {
      return this.Collection.CountDocumentsAsync(new BsonDocument());
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
      var deleteResult = await this.Collection.DeleteOneAsync(e => e.Id == entity.Id);
      return entity;
    }

    public Task<List<TEntity>> GetAsync()
    {
      return this.Collection.Find(new BsonDocument()).SortBy(e => e.Id).ToListAsync();
    }

    public Task<TEntity> GetAsync(Guid id)
    {
      return this.Collection.Find(e => e.Id == id).SingleOrDefaultAsync();
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
      await this.Collection.InsertOneAsync(entity);
      return entity;
    }

    public Task SaveChangesAsync()
    {
      //  There is no SaveChanges for MongoDB
      return Task.CompletedTask;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
      await this.Collection.ReplaceOneAsync(new BsonDocument("_id", entity.Id), entity);
      return entity;
    }
  }
}