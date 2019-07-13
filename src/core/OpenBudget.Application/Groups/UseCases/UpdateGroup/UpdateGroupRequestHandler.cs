using AutoMapper;
using OpenBudget.Application.Groups.Repositories;
using OpenBudget.Application.Groups.UseCases.Dtos;
using OpenBudget.Application.Infrastructure.UseCases;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Groups.UseCases.UpdateGroup
{
  public class UpdateGroupRequestHandler : UpdateRequestHandler<Group, IGroupRepository, UpdateGroupRequest, GroupDto>
  {
    public UpdateGroupRequestHandler(IGroupRepository groupRepository, IMapper mapper)
      : base(groupRepository, mapper)
    {
    }
  }
}