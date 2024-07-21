using Blog.Application.Common.Exceptions;
using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Entries.Queries;

public record EntityGetByIdRequest(Guid EntityId, ClaimsPrincipal User)
    : IRequest<WrapperResult<EntityGetViewModel>>;
public class EntityGetByIdRequestHandler : IRequestHandler<EntityGetByIdRequest, WrapperResult<EntityGetViewModel>>
{
    private readonly IBlogDbContext _dbContext;
    private readonly ICustomMapper<Entity, EntityGetViewModel> _mapper;

    public EntityGetByIdRequestHandler(IBlogDbContext dbContext, ICustomMapper<Entity, EntityGetViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<WrapperResult<EntityGetViewModel>> Handle(EntityGetByIdRequest request, CancellationToken cancellationToken)
    {
        var result = WrapperResult.Build<EntityGetViewModel>();

        var model = await _dbContext.Entities.FirstOrDefaultAsync(m => m.Id == request.EntityId, cancellationToken);
        if (model is null)
        {
            var exception = new BlogEntityNotFoundException("ID", request);
            result.ExceptionObject = exception;
            result.Message = exception.Message;
            return result;
        }

        result.Result = _mapper.ToViewModel(model);
        return result;
    }
}
