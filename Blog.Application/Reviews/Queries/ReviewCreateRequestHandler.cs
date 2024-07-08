using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using System.Security.Claims;

namespace Blog.Application.Reviews.Queries;

public record ReviewCreateRequest(ReviewCreateViewModel ViewModel, ClaimsPrincipal User)
    : IRequest<WrapperResult<int>>;

public class ReviewCreateRequestHandler : IRequestHandler<ReviewCreateRequest, WrapperResult<int>>
{
    private readonly IBlogDbContext _dbContext;
    private readonly ICustomMapper<Review, ReviewCreateViewModel> _customMapper;

    public ReviewCreateRequestHandler(IBlogDbContext dbContext, ICustomMapper<Review, ReviewCreateViewModel> customMapper)
    {
        _dbContext = dbContext;
        _customMapper = customMapper;
    }

    public async Task<WrapperResult<int>> Handle(ReviewCreateRequest request, CancellationToken cancellationToken)
    {
        var result = WrapperResult.Build<int>();

        if (_dbContext.Entities.Any(m => m.Id == request.ViewModel.EntityId)) 
        {
            var model = _customMapper.ToModel(request.ViewModel);
            model.CreatedBy = request.User.Identity!.Name!;
            model.CreatedAt = DateTime.UtcNow;

            _dbContext.Reviews.Add(model);

            var saveResult = await _dbContext.SaveChangesAsync(cancellationToken);

            if (saveResult == 0) 
            {
                result.ExceptionObject = new BlogEntityAlreadyExistsException(nameof(Review), request.ViewModel);
                return result;
            }
        }
        result.ExceptionObject = new BlogEntityNotFoundException(nameof(Review), request.ViewModel);
        return result;
    }
}
