using Blog.Application.Common.Exceptions;
using Blog.Application.Entries.ViewModels;
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

namespace Blog.Application.Entries.Queries
{
    public record EntityCreateRequest(EntryCreateViewModel ViewModel, ClaimsPrincipal User)
        : IRequest<WrapperResult<EntryCreateViewModel>>;
    public class EntityCreateRequestHandler
        : IRequestHandler<EntityCreateRequest, WrapperResult<EntryCreateViewModel>>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ICustomMapper<Entry, EntryCreateViewModel> _mapper;
        public EntityCreateRequestHandler(IBlogDbContext dbContext, ICustomMapper<Entry, EntryCreateViewModel> mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }
        public async Task<WrapperResult<EntryCreateViewModel>> Handle(EntityCreateRequest request, CancellationToken cancellationToken)
        {
            var result = WrapperResult.Build<EntryCreateViewModel>();

            var entry = _mapper.ToModel(request.ViewModel);
            entry.CreatedBy = request.User.Identity!.Name!;
            entry.CreatedAt = DateTime.UtcNow;

            _dbContext.Entries.Add(entry);

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
}
