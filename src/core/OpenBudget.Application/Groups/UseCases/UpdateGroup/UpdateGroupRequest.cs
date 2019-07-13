using System;
using MediatR;
using OpenBudget.Application.Groups.UseCases.Dtos;

namespace OpenBudget.Application.Groups.UseCases.UpdateGroup
{
  public class UpdateGroupRequest : IRequest<GroupDto>
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}