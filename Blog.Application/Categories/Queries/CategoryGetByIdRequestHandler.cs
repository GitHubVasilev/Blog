using Blog.Application.Categories.ViewModels;
using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Categories.Queries
{
    public record CategoryGetByIdRequest(Guid CategoryId, ClaimsPrincipal User)
    : IRequest<WrapperResult<CategoryDetailViewModel>>;
    public class CategoryGetByIdRequestHandler
        : IRequestHandler<CategoryGetByIdRequest, WrapperResult<CategoryDetailViewModel>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ICustomMapper<Category, CategoryDetailViewModel> _mapper;
        public CategoryGetByIdRequestHandler(IBlogDbContext blogDbContext, ICustomMapper<Category, CategoryDetailViewModel> mapper)
        {
            _dbContext = blogDbContext;
            _mapper = mapper;
        }
        public async Task<WrapperResult<CategoryDetailViewModel>> Handle(CategoryGetByIdRequest request, CancellationToken cancellationToken)
        {
            var wrapperResult = WrapperResult.Build<CategoryDetailViewModel>();
            var entity = await _dbContext.Categories.FirstOrDefaultAsync(m => m.Id == request.CategoryId, cancellationToken);

            if (entity is null) 
            {
                wrapperResult.ExceptionObject = new BlogEntityNotFoundException(nameof(Category), request.CategoryId);
                return wrapperResult;
            }
            var childrenCategories = _dbContext.Categories.Where(m => m.ParentId == entity.ParentId);

            var modelParent = await _dbContext.Categories.FirstOrDefaultAsync(m => m.Id == entity.ParentId, cancellationToken);

            wrapperResult.Result = _mapper.ToViewModel(entity);
            wrapperResult.Result!.Parent = modelParent is null ? null : _mapper.ToViewModel(modelParent);
            wrapperResult.Result.Children = new List<CategoryDetailViewModel>();
            await childrenCategories.ForEachAsync(m => wrapperResult.Result.Children.Add(_mapper.ToViewModel(m)), cancellationToken);
            wrapperResult.Result.CountChildren = await childrenCategories.CountAsync(cancellationToken);

            return wrapperResult;
        }
    }
}
