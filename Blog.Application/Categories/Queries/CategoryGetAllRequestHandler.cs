using Blog.Application.Categories.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain.Base;
using MediatR;
using System.Security.Claims;

namespace Blog.Application.Categories.Queries
{
    public record CategoryGetAllRequest(ClaimsPrincipal User)
    : IRequest<WrapperResult<List<CategoryViewModel>>>;

    public class CategoryGetAllRequestHandler
        : IRequestHandler<CategoryGetAllRequest, WrapperResult<List<CategoryViewModel>>>
    {
        private readonly IBlogDbContext _dbContext;
        public CategoryGetAllRequestHandler(IBlogDbContext blogDbContext)
        {
            _dbContext = blogDbContext;
        }

        public Task<WrapperResult<List<CategoryViewModel>>> Handle(CategoryGetAllRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
