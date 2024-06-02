using Blog.Application.Categories.Queries;
using Blog.Application.Categories.ViewModels;
using Blog.Domain.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers;


public class CategoryController : BaseController
{
    [HttpGet]
    public async Task<WrapperResult<List<CategoryGetViewModel>>> GetAllTree()
    {
        var query = new CategoryGetAllTreeRequest(User);
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Authorize]
    public async Task<WrapperResult<List<CategoryGetViewModel>>> GetAll()
    {
        var query = new CategoryGetAllRequest(User);
        return await Mediator.Send(query);
    }

    [HttpGet("{id:guid}")]
    public async Task<WrapperResult<CategoryDetailViewModel>> GetById(Guid id)
    {
        var query = new CategoryGetByIdRequest(id, User);
        return await Mediator.Send(query);
    }

    [HttpGet()]
    public async Task<WrapperResult<List<CategoryGetViewModel>>> GetPage(int pageIndex, int pageSize)
    {
        var query = new CategoryGetPagedRequest(pageIndex, pageSize, User);
        return await Mediator.Send(query);
    }

    [HttpPost]
    [Authorize]
    public async Task<WrapperResult> Create([FromBody] CategoryCreateViewModel categoryCreateViewModel) 
    {
        var query = new CategoryCreateRequest(categoryCreateViewModel, User);
        return await Mediator.Send(query);
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<WrapperResult> Delete(Guid id) 
    {
        var query = new CategoryDeleteByIdRequest(id, User);
        return await Mediator.Send(query);
    }

    [HttpPut]
    [Authorize]
    public async Task<WrapperResult> Update([FromBody] CategoryUpdateViewModel categoryUpdateViewModel) 
    {
        var query = new CategoryUpdateRequest(categoryUpdateViewModel, User);
        return await Mediator.Send(query);
    }
}
