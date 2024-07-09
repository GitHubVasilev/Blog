using Blog.Application.Reviews.Queries;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers;

public class ReviewController : BaseController
{
    [HttpGet]
    public async Task<WrapperResult<List<ReviewGetViewModel>>> GetAllTree(Guid productId)
    {
        var query = new ReviewGetAllTreeRequest(productId, User);
        return await Mediator.Send(query);
    }

    [HttpGet]
    public async Task<WrapperResult<ReviewGetViewModel>> GetById(Guid reviewId) 
    {
        var query = new ReviewGetByIdRequest(reviewId, User);
        return await Mediator.Send(query);
    }

    [HttpGet]
    public async Task<WrapperResult<ReviewCreateViewModel>> Create()
    {
        var query = new ReviewGetForCreateRequest(User);
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<WrapperResult> Create([FromBody] ReviewCreateViewModel viewModel) 
    {
        var query = new ReviewCreateRequest(viewModel, User);
        return await Mediator.Send(query);
    }
}
