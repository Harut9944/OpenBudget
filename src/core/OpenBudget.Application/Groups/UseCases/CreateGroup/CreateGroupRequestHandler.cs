using AutoMapper;
using OpenBudget.Application.Groups.Repositories;
using OpenBudget.Application.Groups.UseCases.Dtos;
using OpenBudget.Application.Infrastructure.UseCases;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Groups.UseCases.CreateGroup
{
  public class CreateGroupRequestHandler : CreateRequestHandler<Group, IGroupRepository, CreateGroupRequest, GroupDto>
  {
    public CreateGroupRequestHandler(IGroupRepository groupRepository, IMapper mapper)
      : base(groupRepository, mapper)
    {
    }
  }
}