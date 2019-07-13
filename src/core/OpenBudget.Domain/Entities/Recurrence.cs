using OpenBudget.Domain.Enums;

namespace OpenBudget.Domain.Entities
{
  public class Recurrence
  {
    public RecurrencePeriod ForPeriod { get; set; }
    public int ForPeriodAmount { get; set; }

    public Transaction Transaction { get; set; }
  }
}