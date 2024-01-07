using Blog.Application.Categories.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Categories.Queries
{
    public record CategoryGetAllTreeRequest(ClaimsPrincipal User)
    : IRequest<WrapperResult<List<CategoryGetViewModel>>>;

    public class CategoryGetAllTreeRequestHandler
        : IRequestHandler<CategoryGetAllTreeRequest, WrapperResult<List<CategoryGetViewModel>>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly TreeBuilder<Category, CategoryGetViewModel> _treeBuilder;

        public CategoryGetAllTreeRequestHandler(IBlogDbContext blogDbContext, TreeBuilder<Category, CategoryGetViewModel> treeBuilder)
        {
            _dbContext = blogDbContext;
            _treeBuilder = treeBuilder;
        }

        public async Task<WrapperResult<List<CategoryGetViewModel>>> Handle(CategoryGetAllTreeRequest request, CancellationToken cancellationToken)
        {
            var result = WrapperResult.Build<List<CategoryGetViewModel>>();
            result.Result = _treeBuilder.Build(await _dbContext.Categories.ToListAsync(cancellationToken));
            return result;
        }
    }
}
