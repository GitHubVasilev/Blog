using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Reviews.Queries;

public record ReviewGetForUpdateRequest(Guid ReviewId, ClaimsPrincipal User)
    : IRequest<WrapperResult<ReviewUpdateViewModel>>;

public class ReviewGetForUpdateRequestHandler : IRequestHandler<ReviewGetForUpdateRequest, WrapperResult<ReviewUpdateViewModel>>
{
    private readonly IBlogDbContext _blogDbContext;
    private readonly ICustomMapper<Review, ReviewUpdateViewModel> _customMapper;

    public ReviewGetForUpdateRequestHandler(IBlogDbContext blogDbContext, ICustomMapper<Review, ReviewUpdateViewModel> customMapper)
    {
        _blogDbContext = blogDbContext;
        _customMapper = customMapper;
    }

    public async Task<WrapperResult<ReviewUpdateViewModel>> Handle(ReviewGetForUpdateRequest request, CancellationToken cancellationToken)
    {
        var result = WrapperResult.Build<ReviewUpdateViewModel>();

        var model = await _blogDbContext
            .Reviews
            .FirstOrDefaultAsync(m => m.Id == request.ReviewId && (m.IsVisible || request.User.IsInRole(AppData.SystemAdministratorRoleName)), cancellationToken);

        if (model is null)
        {
            result.ExceptionObject = new BlogEntityNotFoundException(nameof(Review), request);
            return result;
        }

        result.Result = _customMapper.ToViewModel(model);
        return result;
    }
}
