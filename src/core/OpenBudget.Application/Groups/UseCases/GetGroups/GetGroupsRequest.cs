using System.Collections.Generic;
using MediatR;
using OpenBudget.Application.Groups.UseCases.Dtos;

namespace OpenBudget.Application.Groups.UseCases.GetGroups
{
  public class GetGroupsRequest : IRequest<List<GroupDto>>
  {
  }
}