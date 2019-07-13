using System;

namespace OpenBudget.Domain.Entities
{
  public class Transaction : EntityBase
  {
    public Group Group { get; set; }
    public string Payee { get; set; }
    public string Memo { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExecutedAt { get; set; }
    public bool IsConfirmed { get; set; }
  }
}