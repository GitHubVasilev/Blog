using Blog.Application.Reviews.ViewModels;
using Blog.Domain.Base;
using MediatR;
using System.Security.Claims;

namespace Blog.Application.Reviews.Queries;

public record ReviewGetForCreateRequest(ClaimsPrincipal User) 
    : IRequest<WrapperResult<ReviewCreateViewModel>>;
public class ReviewGetForCreateRequestHandler : IRequestHandler<ReviewGetForCreateRequest, WrapperResult<ReviewCreateViewModel>>
{
    public async Task<WrapperResult<ReviewCreateViewModel>> Handle(ReviewGetForCreateRequest request, CancellationToken cancellationToken)
    {
        return WrapperResult.Build<ReviewCreateViewModel>();
    }
}
