using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Reviews.Queries;

public record ReviewGetLastRequest(int Count, ClaimsPrincipal User)
    : IRequest<WrapperResult<List<ReviewGetViewModel>>>;

public class ReviewGetLastRequestHandler : IRequestHandler<ReviewGetLastRequest, WrapperResult<List<ReviewGetViewModel>>>
{
    private readonly IBlogDbContext _dbContext;
    private readonly ICustomMapper<Review, ReviewGetViewModel> _mapper;

    public ReviewGetLastRequestHandler(IBlogDbContext dbContext, ICustomMapper<Review, ReviewGetViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<WrapperResult<List<ReviewGetViewModel>>> Handle(ReviewGetLastRequest request, CancellationToken cancellationToken)
    {
        var result = WrapperResult.Build<List<ReviewGetViewModel>>();

        result.Result = await _dbContext.Reviews.OrderBy(r => r.CreatedAt).TakeLast(request.Count).Select(m => _mapper.ToViewModel(m)).ToListAsync(cancellationToken);

        return result;
    }
}
