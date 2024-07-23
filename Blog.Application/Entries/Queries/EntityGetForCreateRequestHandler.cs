using Blog.Application.Entries.ViewModels;
using Blog.Domain.Base;
using MediatR;
using System.Security.Claims;

namespace Blog.Application.Entries.Queries;

public record EntityGetForCreateRequest(ClaimsPrincipal User) : IRequest<WrapperResult<EntityCreateViewModel>>;
public class EntityGetForCreateRequestHandler : IRequestHandler<EntityGetForCreateRequest, WrapperResult<EntityCreateViewModel>>
{
    public async Task<WrapperResult<EntityCreateViewModel>> Handle(EntityGetForCreateRequest request, CancellationToken cancellationToken)
    {
        return WrapperResult.Build<EntityCreateViewModel>();
    }
}
