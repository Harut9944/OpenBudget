using System;
using MediatR;

namespace OpenBudget.Application.Infrastructure.UseCases
{
  public abstract class CheckExistsRequest : IRequest<bool>
  {
    public Guid Id { get; set; }
  }
}