using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenBudget.Application.Groups.UseCases.CheckGroupExists;
using OpenBudget.Application.Groups.UseCases.CreateGroup;
using OpenBudget.Application.Groups.UseCases.DeleteGroup;
using OpenBudget.Application.Groups.UseCases.Dtos;
using OpenBudget.Application.Groups.UseCases.GetGroupById;
using OpenBudget.Application.Groups.UseCases.GetGroups;
using OpenBudget.Application.Groups.UseCases.UpdateGroup;

namespace OpenBudget.WebApi.Group
{
  [ApiController, Route("api/v1/groups")]
  public class GroupsController : ControllerBase
  {
    private readonly IMediator mediator;

    public GroupsController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      List<GroupDto> result = await this.mediator.Send(new GetGroupsRequest());
      return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetItem([FromRoute] Guid id)
    {
      if(id == Guid.Empty) 
      {
        return NotFound();
      }

      GroupDto requestedGroup = await this.mediator.Send(new GetGroupByIdRequest() { Id = id });
      if(requestedGroup == null)
      {
        return this.NotFound();
      }

      return this.Ok(requestedGroup);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateGroupRequest model)
    {
      GroupDto createdGroup = await this.mediator.Send(model);
      return this.CreatedAtAction(nameof(GetItem), new { id = createdGroup.Id }, createdGroup);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateGroupRequest model)
    {
      if(id == Guid.Empty)
      {
        return this.NotFound();
      }

      if(id != model.Id)
      {
        return this.BadRequest();
      }

      bool groupExists = await this.mediator.Send(new CheckGroupExistsRequest() { Id = id });
      if(groupExists == false)
      {
        return this.NotFound();
      }

      GroupDto updatedGroup = await this.mediator.Send(model);

      return this.Ok(updatedGroup);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
      if(id == Guid.Empty)
      {
        return this.NotFound();
      }

      bool groupExists = await this.mediator.Send(new CheckGroupExistsRequest() { Id = id });
      if(groupExists == false)
      {
        return this.NotFound();
      }

      await this.mediator.Send(new DeleteGroupRequest() { Id = id });

      return this.NoContent();
    }
  }
}