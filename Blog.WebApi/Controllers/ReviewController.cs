using Blog.Application.Reviews.Queries;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers;

public class ReviewController : BaseController
{
    [HttpGet]
    public async Task<WrapperResult<List<ReviewGetViewModel>>> GetAllTree()
    {
        var query = new ReviewGetAllTreeRequest(User);
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<WrapperResult> Create([FromBody] ReviewCreateViewModel viewModel) 
    {
        var query = new ReviewCreateRequest(viewModel, User);
        return await Mediator.Send(query);
    }
}
