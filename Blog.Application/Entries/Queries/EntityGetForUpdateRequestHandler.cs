using Blog.Application.Common.Exceptions;
using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Entries.Queries;

public record EntityGetForUpdateRequest(Guid EntityId, ClaimsPrincipal User)
    : IRequest<WrapperResult<EntityUpdateViewModel>>;
public class EntityGetForUpdateRequestHandler : IRequestHandler<EntityGetForUpdateRequest, WrapperResult<EntityUpdateViewModel>>
{
    private readonly IBlogDbContext _dbContext;
    private readonly ICustomMapper<Entity, EntityUpdateViewModel> _mapper;

    public EntityGetForUpdateRequestHandler(IBlogDbContext dbContext, ICustomMapper<Entity, EntityUpdateViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<WrapperResult<EntityUpdateViewModel>> Handle(EntityGetForUpdateRequest request, CancellationToken cancellationToken)
    {
        var result = WrapperResult.Build<EntityUpdateViewModel>();
        var model = await _dbContext.Entities.FirstOrDefaultAsync(m => m.IsVisible && m.Id == request.EntityId, cancellationToken);

        if (model is null)
        {
            var extension = new BlogEntityNotFoundException(nameof(Entity), request);
            result.ExceptionObject = extension;
            result.Message = extension.Message;
            return result;
        }

        result.Result = _mapper.ToViewModel(model);
        return result;
    }
}
