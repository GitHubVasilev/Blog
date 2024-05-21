using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Entries.Queries
{
    public record EntityGetAllRequest(ClaimsPrincipal User)
            : IRequest<WrapperResult<List<EntityGetViewModel>>>;
    partial class EntityGetAllRequestHandler
        : IRequestHandler<EntityGetAllRequest, WrapperResult<List<EntityGetViewModel>>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ICustomMapper<Entity, EntityGetViewModel> _mapper;
        public EntityGetAllRequestHandler(IBlogDbContext dbContext, ICustomMapper<Entity, EntityGetViewModel> mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<List<EntityGetViewModel>>> Handle(EntityGetAllRequest request, CancellationToken cancellationToken)
        {
            var result = WrapperResult.Build<List<EntityGetViewModel>>();
            result.Result = new List<EntityGetViewModel>();
            var entries = await _dbContext.Entries.ToListAsync(cancellationToken);
            entries.ForEach(m => result.Result.Add(_mapper.ToViewModel(m)));
            return result;
        }
    }
}
