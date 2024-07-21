using Blog.Application.Reviews.Queries;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers;

public class ReviewController : BaseController
{
    [HttpGet]
    [Authorize]
    public async Task<WrapperResult<List<ReviewGetViewModel>>> GetAllTree(Guid productId)
    {
        var query = new ReviewGetAllTreeRequest(productId, User);
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Authorize]
    public async Task<WrapperResult<ReviewGetViewModel>> GetById(Guid reviewId) 
    {
        var query = new ReviewGetByIdRequest(reviewId, User);
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Authorize]
    public async Task<WrapperResult<ReviewCreateViewModel>> Create()
    {
        var query = new ReviewGetForCreateRequest(User);
        return await Mediator.Send(query);
    }

    [HttpPost]
    [Authorize]
    public async Task<WrapperResult> Create([FromBody] ReviewCreateViewModel viewModel) 
    {
        var query = new ReviewCreateRequest(viewModel, User);
        return await Mediator.Send(query);
    }

    [HttpDelete]
    [Authorize]
    public async Task<WrapperResult<int>> Delete(Guid reviewId)
    {
        var query = new ReviewDeleteByIdRequest(reviewId, User);
        return await Mediator.Send(query);
    }

    [HttpGet]
    [Authorize]
    public async Task<WrapperResult<ReviewUpdateViewModel>> Update(Guid reviewId) 
    {
        var query = new ReviewGetForUpdateRequest(reviewId, User);
        return await Mediator.Send(query);
    }

    [HttpPut]
    [Authorize]
    public async Task<WrapperResult<int>> Update([FromBody] ReviewUpdateViewModel viewModel) 
    {
        var query = new ReviewUpdateRequest(viewModel, User);
        return await Mediator.Send(query);
    }

    [HttpGet]
    public async Task<WrapperResult<List<ReviewGetViewModel>>> GetLastReviews(int count) 
    {
        var query = new ReviewGetLastRequest(count, User);
        return await Mediator.Send(query);
    }

    [HttpGet]
    public async Task<WrapperResult<List<ReviewGetViewModel>>> GetPaged(int pageIndex, int pageSize)
    {
        var query = new ReviewGetPagedRequest(pageIndex, pageSize, User);
        return await Mediator.Send(query);
    }
}
