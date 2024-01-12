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
            : IRequest<WrapperResult<List<EntryViewModel>>>;
    partial class EntityGetAllRequestHandler
        : IRequestHandler<EntityGetAllRequest, WrapperResult<List<EntryViewModel>>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ICustomMapper<Entry, EntryViewModel> _mapper;
        public EntityGetAllRequestHandler(IBlogDbContext dbContext, ICustomMapper<Entry, EntryViewModel> mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WrapperResult<List<EntryViewModel>>> Handle(EntityGetAllRequest request, CancellationToken cancellationToken)
        {
            var result = WrapperResult.Build<List<EntryViewModel>>();
            result.Result = new List<EntryViewModel>();
            var entries = await _dbContext.Entries.ToListAsync(cancellationToken);
            entries.ForEach(m => result.Result.Add(_mapper.ToViewModel(m)));
            return result;
        }
    }
}
