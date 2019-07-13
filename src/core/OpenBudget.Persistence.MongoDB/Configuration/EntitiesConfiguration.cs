using MongoDB.Bson.Serialization;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Persistence.MongoDB.Configuration
{
  public static class EntitiesConfiguration
  {
    public static void ConfigureAllEntities()
    {
      BsonClassMap.RegisterClassMap<Group>();
    }
  }
}