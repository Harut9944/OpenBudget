using System.Collections.Generic;
using AutoMapper;
using OpenBudget.Application.Groups.Repositories;
using OpenBudget.Application.Groups.UseCases.Dtos;
using OpenBudget.Application.Infrastructure.UseCases;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Groups.UseCases.GetGroups
{
  public class GetGroupsRequestHandler 
    : GetItemsRequestHandler<Group, IGroupRepository, GetGroupsRequest, List<GroupDto>>
  {
    public GetGroupsRequestHandler(IGroupRepository repository, IMapper mapper)
      : base(repository, mapper)
    {
    }
  }
}