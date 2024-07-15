using Blog.Application.Categories.ViewModels;
using Blog.Domain.Base;
using MediatR;
using System.Security.Claims;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Categories.Queries
{
    public record CategoryUpdateRequest(CategoryUpdateViewModel ViewModel, ClaimsPrincipal User)
            : IRequest<WrapperResult<CategoryUpdateViewModel>>;
    public class CategoryUpdateRequestHandler
        : IRequestHandler<CategoryUpdateRequest, WrapperResult<CategoryUpdateViewModel>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ICustomMapper<Category, CategoryUpdateViewModel> _mapper;

        public CategoryUpdateRequestHandler(IBlogDbContext dbContext, ICustomMapper<Category, CategoryUpdateViewModel> mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<CategoryUpdateViewModel>> Handle(CategoryUpdateRequest request, CancellationToken cancellationToken)
        {
            var result = WrapperResult.Build<CategoryUpdateViewModel>();

            if (request.User.IsInRole(AppData.SystemAdministratorRoleName))
            {
                result.ExceptionObject = new BlogAccessDeniedException(nameof(CategoryUpdateRequest));
                return result;
            }

            if (await _dbContext.Categories.AnyAsync(m => m.Id == request.ViewModel.Id, cancellationToken)) 
            {
                result.ExceptionObject = new BlogEntityNotFoundException(nameof(Category), request.ViewModel.Id);
                return result;
            }

            var newCategory = _mapper.ToModel(request.ViewModel);

            _dbContext.Categories.Update(newCategory);
            
            await _dbContext.SaveChangesAsync(cancellationToken);

            result.Result = request.ViewModel;
            return result;
        }
    }
}
