using Blog.Application.Categories.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Categories.Queries
{
    public record CategoryGetAllRequest(ClaimsPrincipal User)
            : IRequest<WrapperResult<List<CategoryGetViewModel>>>;

    public class CategoryGetAllRequestHandler
        : IRequestHandler<CategoryGetAllRequest, WrapperResult<List<CategoryGetViewModel>>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ICustomMapper<Category, CategoryGetViewModel> _mapper;

        public CategoryGetAllRequestHandler(IBlogDbContext blogDbContext, ICustomMapper<Category, CategoryGetViewModel> mapper)
        {
            _dbContext = blogDbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<List<CategoryGetViewModel>>> Handle(CategoryGetAllRequest request, CancellationToken cancellationToken)
        {
            var result = WrapperResult.Build<List<CategoryGetViewModel>>();
            result.Result = new List<CategoryGetViewModel>();
            await _dbContext.Categories.ForEachAsync(m => result.Result.Add(_mapper.ToViewModel(m)), cancellationToken);

            return result;
        }
    }
}
