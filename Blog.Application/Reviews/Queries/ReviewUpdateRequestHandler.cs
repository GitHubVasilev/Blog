using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Reviews.Queries;

public record ReviewUpdateRequest(ReviewUpdateViewModel ViewModel, ClaimsPrincipal User)
    : IRequest<WrapperResult<int>>;

public class ReviewUpdateRequestHandler : IRequestHandler<ReviewUpdateRequest, WrapperResult<int>>
{
    private readonly IBlogDbContext _dbContext;
    private readonly ICustomMapper<Review, ReviewUpdateViewModel> _customMapper;

    public ReviewUpdateRequestHandler(IBlogDbContext blogDbContext, ICustomMapper<Review, ReviewUpdateViewModel> customMapper)
    {
        _dbContext = blogDbContext;
        _customMapper = customMapper;
    }
    public async Task<WrapperResult<int>> Handle(ReviewUpdateRequest request, CancellationToken cancellationToken)
    {
        var result = WrapperResult.Build<int>();

        var model = await _dbContext
            .Reviews
            .FirstOrDefaultAsync(m => m.Id == request.ViewModel.Id && (m.IsVisible || request.User.IsInRole(AppData.SystemAdministratorRoleName)), cancellationToken);

        if (model is null)
        {
            result.ExceptionObject = new BlogEntityNotFoundException(nameof(Review), request);
            return result;
        }

        var newModel = _customMapper.ToModel(request.ViewModel);
        newModel.UpdatedAt = DateTime.UtcNow;
        newModel.UpdatedBy = request.User.Identity!.Name!;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return request;
    }
}
