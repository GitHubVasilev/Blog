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
           : IRequest<WrapperResult<List<EntryViewModel>>>;
    public class EntityGetPagedRequestHandler
        : IRequestHandler<EntityGetPagedRequest, WrapperResult<List<EntryViewModel>>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ICustomMapper<Entry, EntryViewModel> _mapper;

        public EntityGetPagedRequestHandler(IBlogDbContext dbContext, ICustomMapper<Entry, EntryViewModel> mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<WrapperResult<List<EntryViewModel>>> Handle(EntityGetPagedRequest request, CancellationToken cancellationToken)
        {
            var listEntries = _dbContext.Entries
               .OrderBy(c => c.Id).Skip((request.PageIndex - 1) * request.PageSize)
               .Take(request.PageSize);
            var result = new WrapperResult<List<EntryViewModel>>();
            result.Result = new List<EntryViewModel>();
            await listEntries.ForEachAsync(m => result.Result.Add(_mapper.ToViewModel(m)), cancellationToken);
            return result;
        }
    }
}
