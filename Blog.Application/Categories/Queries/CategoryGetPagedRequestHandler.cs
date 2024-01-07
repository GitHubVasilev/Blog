using Blog.Application.Categories.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Categories.Queries
{
    public record CategoryGetPagedRequest(int pageIndex, int pageSize, ClaimsPrincipal User)
    : IRequest<WrapperResult<List<CategoryGetViewModel>>>;
    public class CategoryGetPagedRequestHandler
        : IRequestHandler<CategoryGetPagedRequest, WrapperResult<List<CategoryGetViewModel>>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ICustomMapper<Category, CategoryGetViewModel> _mapper;

        public CategoryGetPagedRequestHandler(IBlogDbContext blogDbContext, ICustomMapper<Category, CategoryGetViewModel> mapper)
        {
            _dbContext = blogDbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<List<CategoryGetViewModel>>> Handle(CategoryGetPagedRequest request, CancellationToken cancellationToken)
        {
            var listCategories = _dbContext.Categories
                .OrderBy(c => c.Id).Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize);
            var result = new WrapperResult<List<CategoryGetViewModel>>();
            result.Result = new List<CategoryGetViewModel>();
            await listCategories.ForEachAsync(m => result.Result.Add(_mapper.ToViewModel(m)), cancellationToken: cancellationToken);
            return result;
        }
    }
}
