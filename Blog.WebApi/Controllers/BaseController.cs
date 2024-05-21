using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : Controller
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    internal Guid UserID => User.Identity!.IsAuthenticated
        ? Guid.NewGuid()
        : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}
