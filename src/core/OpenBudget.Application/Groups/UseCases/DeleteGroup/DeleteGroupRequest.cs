using System;
using MediatR;

namespace OpenBudget.Application.Groups.UseCases.DeleteGroup
{
  public class DeleteGroupRequest : IRequest
  {
    public Guid Id { get; set; }
  }
}