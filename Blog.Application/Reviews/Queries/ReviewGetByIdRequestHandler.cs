using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
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

namespace Blog.Application.Reviews.Queries;

public record ReviewGetByIdRequest(Guid ReviewId, ClaimsPrincipal User)
    : IRequest<WrapperResult<ReviewGetViewModel>>;

public class ReviewGetByIdRequestHandler : IRequestHandler<ReviewGetByIdRequest, WrapperResult<ReviewGetViewModel>>
{
    private readonly IBlogDbContext _dbContext;
    private readonly ICustomMapper<Review, ReviewGetViewModel> _mapper;
    public ReviewGetByIdRequestHandler(IBlogDbContext dbContext, ICustomMapper<Review, ReviewGetViewModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<WrapperResult<ReviewGetViewModel>> Handle(ReviewGetByIdRequest request, CancellationToken cancellationToken)
    {
        var result = new WrapperResult<ReviewGetViewModel>();
        var model = await _dbContext.Reviews.FirstOrDefaultAsync(m => m.Id == request.ReviewId, cancellationToken);

        if (model is null)
        {
            result.ExceptionObject = new BlogEntityNotFoundException($"Отзыв с ID {request.ReviewId} не найден", request.ReviewId);
            return result;
        }

        result.Result = _mapper.ToViewModel(model);
        return result;
    }
}
