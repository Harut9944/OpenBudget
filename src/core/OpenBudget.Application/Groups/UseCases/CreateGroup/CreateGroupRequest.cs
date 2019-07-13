using MediatR;
using OpenBudget.Application.Groups.UseCases.Dtos;

namespace OpenBudget.Application.Groups.UseCases.CreateGroup
{
  public class CreateGroupRequest : IRequest<GroupDto>
  {
    public string Name { get; set; }
  }
}