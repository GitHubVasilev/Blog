using Blog.Application.Categories.ViewModels;
using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Categories.Queries
{
    public record CategoryDeleteByIdRequest(Guid CategoryId, ClaimsPrincipal User)
            : IRequest<WrapperResult<int>>;
    public class CategoryDelete
        : IRequestHandler<CategoryDeleteByIdRequest, WrapperResult<int>>
    {
        private readonly IBlogDbContext _dbContext;

        public CategoryDelete(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WrapperResult<int>> Handle(CategoryDeleteByIdRequest request, CancellationToken cancellationToken)
        {
            var result = WrapperResult.Build<int>();

            if (request.User.IsInRole(AppData.SystemAdministratorRoleName))
            {
                result.ExceptionObject = new BlogAccessDeniedException(nameof(CategoryUpdateRequest));
                return result;
            }

            var entity = await _dbContext.Categories.FirstOrDefaultAsync(m => m.Id == request.CategoryId);

            if (entity is null)
            {
                result.ExceptionObject = new BlogEntityNotFoundException(nameof(Category), request.CategoryId);
                return result;
            }

            _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
