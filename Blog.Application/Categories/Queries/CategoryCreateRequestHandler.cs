using Blog.Application.Categories.ViewModels;
using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Categories.Queries
{
    public record CategoryCreateRequest(CategoryCreateViewModel viewModel)
        : IRequest<WrapperResult<CategoryGetViewModel>>;
    public class CategoryCreateRequestHandler
        : IRequestHandler<CategoryCreateRequest, WrapperResult<CategoryGetViewModel>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ICustomMapper<Category, CategoryCreateViewModel> _mapper;
        private readonly ICustomMapper<Category, CategoryGetViewModel> _mapperGet;

        public CategoryCreateRequestHandler(IBlogDbContext dbContext,
            ICustomMapper<Category, CategoryCreateViewModel> customMapper,
            ICustomMapper<Category, CategoryGetViewModel> customMapperGet)
        {
            _mapper = customMapper;
            _dbContext = dbContext;
            _mapperGet = customMapperGet;
        }
        public async Task<WrapperResult<CategoryGetViewModel>> Handle(CategoryCreateRequest request, CancellationToken cancellationToken)
        {
            var result = WrapperResult.Build<CategoryGetViewModel>();
            var entity = _mapper.ToModel(request.viewModel);

            var parentCategory = await _dbContext.Categories.FirstOrDefaultAsync(m => m.Id == entity.ParentId, cancellationToken);

            if (parentCategory is null)
            {
                result.ExceptionObject = new BlogEntityNotFoundException(nameof(Category), entity.ParentId!);
                return result;
            }

            _dbContext.Categories.Add(entity);
            var saveResult = await _dbContext.SaveChangesAsync(cancellationToken);

            if (saveResult == 0) 
            {
                result.ExceptionObject = new BlogEntityAlreadyExistsException(nameof(Category), request.viewModel);
                return result;
            }

            result.Result = _mapperGet.ToViewModel(entity);
            result.Result.Parent = entity.ParentId is null ? null : _mapperGet.ToViewModel(parentCategory);
            return result;
        }
    }
}
