using Blog.Application.Entries.Queries;
using Blog.Application.Entries.ViewModels;
using Blog.Domain.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers;

public class EntityController : BaseController
{
    [HttpGet]
    public Task<WrapperResult<List<EntityGetViewModel>>> GetAll()
    {
        var query = new EntityGetAllRequest(User);
        return Mediator.Send(query);
    }

    [HttpGet]
    public Task<WrapperResult<List<EntityGetViewModel>>> GetPage(int pageIndex, int pageSize)
    {
        var query = new EntityGetPagedRequest(pageIndex, pageSize, User);
        return Mediator.Send(query);
    }

    [HttpPost]
    [Authorize]
    public Task<WrapperResult<EntityCreateViewModel>> Create([FromBody] EntityCreateViewModel entityCreateViewModel)
    {
        var query = new EntityCreateRequest(entityCreateViewModel, User);
        return Mediator.Send(query);
    }

    [HttpGet]
    public Task<WrapperResult<EntityGetViewModel>> GetById(Guid entityId)
    {
        var query = new EntityGetByIdRequest(entityId, User);
        return Mediator.Send(query);
    }

    [HttpGet]
    [Authorize]
    public Task<WrapperResult<EntityUpdateViewModel>> Update(Guid entityId) 
    {
        var query = new EntityGetForUpdateRequest(entityId, User);
        return Mediator.Send(query);
    }

    [HttpPut]
    [Authorize]
    public Task<WrapperResult<int>> Update([FromBody] EntityUpdateViewModel viewModel) 
    {
        var query = new EntityUpdateRequest(viewModel, User);
        return Mediator.Send(query);
    }
}
