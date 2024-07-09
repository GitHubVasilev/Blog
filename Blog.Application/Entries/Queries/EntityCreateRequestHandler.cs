using Blog.Application.Common.Exceptions;
using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using System.Security.Claims;

namespace Blog.Application.Entries.Queries;

public record EntityCreateRequest(EntityCreateViewModel ViewModel, ClaimsPrincipal User)
    : IRequest<WrapperResult<EntityCreateViewModel>>;
public class EntityCreateRequestHandler
    : IRequestHandler<EntityCreateRequest, WrapperResult<EntityCreateViewModel>>
{
    private readonly IBlogDbContext _dbContext;
    private readonly ICustomMapper<Entity, EntityCreateViewModel> _mapper;
    public EntityCreateRequestHandler(IBlogDbContext dbContext, ICustomMapper<Entity, EntityCreateViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;   
    }
    public async Task<WrapperResult<EntityCreateViewModel>> Handle(EntityCreateRequest request, CancellationToken cancellationToken)
    {
        var result = WrapperResult.Build<EntityCreateViewModel>();

        var entry = _mapper.ToModel(request.ViewModel);
        entry.CreatedBy = request.User.Identity!.Name!;
        entry.CreatedAt = DateTime.UtcNow;

        _dbContext.Entities.Add(entry);

        var saveResult = await _dbContext.SaveChangesAsync(cancellationToken);

        if (saveResult == 0)
        {
            result.ExceptionObject = new BlogEntityAlreadyExistsException(nameof(Category), request.ViewModel);
            return result;
        }

        result.Result = _mapper.ToViewModel(entry);
        return result;
    }
}
