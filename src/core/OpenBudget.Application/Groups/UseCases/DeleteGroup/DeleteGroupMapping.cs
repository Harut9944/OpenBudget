using AutoMapper;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Groups.UseCases.DeleteGroup
{
  public class DeleteGroupMapping : Profile
  {
    public DeleteGroupMapping()
    {
      this.CreateMap<DeleteGroupRequest, Group>();
    }
  }
}