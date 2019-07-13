using AutoMapper;
using OpenBudget.Application.Groups.UseCases.Dtos;
using OpenBudget.Domain.Entities;

namespace OpenBudget.Application.Groups.UseCases.Mapping
{
  public class GroupMapping : Profile
  {
    public GroupMapping()
    {
      this.CreateMap<Group, GroupDto>();
    } 
  }
}