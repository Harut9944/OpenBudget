using MongoDB.Driver;
using OpenBudget.Application.Groups.Repositories;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Persistence.MongoDB.Repositories
{
  public class GroupRepository : Repository<Group>, IGroupRepository
  {
    public GroupRepository(IMongoDatabase database, string collectionName) 
      : base(database, collectionName)
    {
    }
  }
}