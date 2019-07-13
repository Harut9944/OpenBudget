using System;
using MediatR;

namespace OpenBudget.Application.Infrastructure.UseCases
{
  public abstract class GetItemRequest<TResponse> : IRequest<TResponse>
  {
    public Guid Id { get; set; }
  }
}