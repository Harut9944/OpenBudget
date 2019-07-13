using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OpenBudget.Application.Groups.Repositories;
using OpenBudget.Persistence.MongoDB.Configuration;
using OpenBudget.Persistence.MongoDB.Repositories;

namespace OpenBudget.WebApi.Infrastructure.Extensions
{
  public static class ServiceCollectionExtensions 
  {
    public static IServiceCollection AddMongoDBServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddSingleton<MongoClient>(factory => new MongoClient(configuration.GetConnectionString("Default")));
      services.AddSingleton<IMongoDatabase>(factory => 
      {
        var mongoClient = factory.GetRequiredService<MongoClient>();
        return mongoClient.GetDatabase("OpenBudget");
      });

      EntitiesConfiguration.ConfigureAllEntities();

      return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
      services.AddTransient<IGroupRepository, GroupRepository>(factory =>
      {
        var mongoDatabase = factory.GetRequiredService<IMongoDatabase>();
        return new GroupRepository(mongoDatabase, "Groups");
      });

      return services;
    }
  }
}