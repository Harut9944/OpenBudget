using AutoMapper;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Groups.UseCases.CreateGroup
{
  public class CreateGroupMapping : Profile
  {
    public CreateGroupMapping()
    {
        this.CreateMap<CreateGroupRequest, Group>();
    }
  }
}