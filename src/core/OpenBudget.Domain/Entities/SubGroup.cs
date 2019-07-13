namespace OpenBudget.Domain.Entities
{
  public class SubGroup : EntityBase
  {
    public string Name { get; set; }

    public Group Group { get; set; }
  }
}