using AutoMapper;
using OpenBudget.Application.Groups.Repositories;
using OpenBudget.Application.Groups.UseCases.Dtos;
using OpenBudget.Application.Infrastructure.UseCases;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Groups.UseCases.GetGroupById
{
  public class GetGroupByIdRequestHandler
    : GetItemRequestHandler<Group, IGroupRepository, GetGroupByIdRequest, GroupDto>
  {
    public GetGroupByIdRequestHandler(IGroupRepository repository, IMapper mapper)
      : base(repository, mapper)
    {
    }
  }
}