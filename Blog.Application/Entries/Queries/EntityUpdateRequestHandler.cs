using Blog.Application.Common.Exceptions;
using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Entries.Queries;

public record EntityUpdateRequest(EntityUpdateViewModel ViewModel, ClaimsPrincipal User)
    : IRequest<WrapperResult<int>>;
public class EntityUpdateRequestHandler : IRequestHandler<EntityUpdateRequest, WrapperResult<int>>
{
    private readonly IBlogDbContext _dbContext;
    private readonly ICustomMapper<Entity, EntityUpdateViewModel> _mapper;

    public EntityUpdateRequestHandler(IBlogDbContext dbContext, ICustomMapper<Entity, EntityUpdateViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<WrapperResult<int>> Handle(EntityUpdateRequest request, CancellationToken cancellationToken)
    {
        var result = WrapperResult.Build<int>();

        if (request.User.IsInRole(AppData.SystemAdministratorRoleName) || request.User.Identity!.Name == request.ViewModel.CreatedBy)
        {
            if (!await _dbContext.Entities.AnyAsync(m => m.Id == request.ViewModel.Id)) 
            {
                var exception = new BlogEntityNotFoundException(nameof(EntityUpdateRequest), request);
                result.ExceptionObject = exception;
                result.Message = exception.Message;
                return result;
            }
            var model = _mapper.ToModel(request.ViewModel);
            _dbContext.Entities.Update(model);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }
        else 
        {
            var exception = new BlogAccessDeniedException(request.User.Identity.Name ?? string.Empty);
            result.ExceptionObject = exception;
            result.Message = exception.Message;
            return result;
        }
    }
}
