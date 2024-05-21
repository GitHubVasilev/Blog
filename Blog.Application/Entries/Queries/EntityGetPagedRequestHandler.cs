using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog.Application.Entries.Queries
{
    public record EntityGetPagedRequest(int PageIndex, int PageSize, ClaimsPrincipal User)
           : IRequest<WrapperResult<List<EntityGetViewModel>>>;
    public class EntityGetPagedRequestHandler
        : IRequestHandler<EntityGetPagedRequest, WrapperResult<List<EntityGetViewModel>>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ICustomMapper<Entity, EntityGetViewModel> _mapper;

        public EntityGetPagedRequestHandler(IBlogDbContext dbContext, ICustomMapper<Entity, EntityGetViewModel> mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<WrapperResult<List<EntityGetViewModel>>> Handle(EntityGetPagedRequest request, CancellationToken cancellationToken)
        {
            var listEntries = _dbContext.Entries
               .OrderBy(c => c.Id).Skip((request.PageIndex - 1) * request.PageSize)
               .Take(request.PageSize);
            var result = new WrapperResult<List<EntityGetViewModel>>();
            result.Result = new List<EntityGetViewModel>();
            await listEntries.ForEachAsync(m => result.Result.Add(_mapper.ToViewModel(m)), cancellationToken);
            return result;
        }
    }
}
