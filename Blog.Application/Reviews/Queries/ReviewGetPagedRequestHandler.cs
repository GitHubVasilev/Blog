using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Reviews.Queries;

public record ReviewGetPagedRequest(int PageIndex, int PageSize, ClaimsPrincipal User)
      : IRequest<WrapperResult<List<ReviewGetViewModel>>>;

public class ReviewGetPagedRequestHandler : IRequestHandler<ReviewGetPagedRequest, WrapperResult<List<ReviewGetViewModel>>>
{
    private readonly IBlogDbContext _dbContext;
    private readonly ICustomMapper<Review, ReviewGetViewModel> _mapper;

    public ReviewGetPagedRequestHandler(IBlogDbContext dbContext, ICustomMapper<Review, ReviewGetViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<WrapperResult<List<ReviewGetViewModel>>> Handle(ReviewGetPagedRequest request, CancellationToken cancellationToken)
    {
        var listReview = await _dbContext.Reviews
               .OrderBy(c => c.Id).Skip((request.PageIndex - 1) * request.PageSize)
               .Take(request.PageSize)
               .Select(m => _mapper.ToViewModel(m))
               .ToListAsync(cancellationToken);
        var result = new WrapperResult<List<ReviewGetViewModel>>();
        result.Result = listReview;
        return result;
    }
}
