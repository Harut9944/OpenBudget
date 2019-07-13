using AutoMapper;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Groups.UseCases.UpdateGroup
{
  public class UpdateGroupMapping : Profile
  {
    public UpdateGroupMapping()
    {
        this.CreateMap<UpdateGroupRequest, Group>();
    }
  }
}