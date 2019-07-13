using AutoMapper;
using OpenBudget.Application.Groups.Repositories;
using OpenBudget.Application.Infrastructure.UseCases;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Groups.UseCases.DeleteGroup
{
  public class DeleteGroupRequestHandler : DeleteRequestHandler<Group, IGroupRepository, DeleteGroupRequest>
  {
    public DeleteGroupRequestHandler(IGroupRepository groupRepository, IMapper mapper)
      : base(groupRepository, mapper)
    {
    }
  }
}