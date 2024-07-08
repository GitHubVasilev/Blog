using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Reviews.Queries;

public record ReviewGetAllTreeRequest(ClaimsPrincipal User)
    : IRequest<WrapperResult<List<ReviewGetViewModel>>>;

public class ReviewGetAllTreeRequestHandler : IRequestHandler<ReviewGetAllTreeRequest, WrapperResult<List<ReviewGetViewModel>>>
{
    private readonly IBlogDbContext _dbContext;
    private readonly TreeBuilder<Review, ReviewGetViewModel> _treeBuilder;

    public ReviewGetAllTreeRequestHandler(IBlogDbContext blogDbContext, TreeBuilder<Review, ReviewGetViewModel> treeBuilder)
    {
        _dbContext = blogDbContext;
        _treeBuilder = treeBuilder;
    }
    public async Task<WrapperResult<List<ReviewGetViewModel>>> Handle(ReviewGetAllTreeRequest request, CancellationToken cancellationToken)
    {
        var result = WrapperResult.Build<List<ReviewGetViewModel>>();
        result.Result = _treeBuilder.Build(await _dbContext.Reviews.Where(m => m.IsVisible).ToListAsync(cancellationToken));
        return result;
    }
}
