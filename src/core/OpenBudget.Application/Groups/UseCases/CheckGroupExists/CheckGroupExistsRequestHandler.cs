using AutoMapper;
using OpenBudget.Application.Groups.Repositories;
using OpenBudget.Application.Infrastructure.UseCases;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Groups.UseCases.CheckGroupExists
{
  public class CheckGroupExistsRequestHandler
    : CheckExistsRequestHandler<Group, IGroupRepository, CheckGroupExistsRequest>
  {
    public CheckGroupExistsRequestHandler(IGroupRepository repository, IMapper mapper) 
      : base(repository, mapper)
    {
    }
  }
}