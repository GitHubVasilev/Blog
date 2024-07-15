using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Application.Reviews.ViewModels;
using Blog.Domain;
using Blog.Domain.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Reviews.Queries;

public record ReviewDeleteByIdRequest(Guid ReviewId, ClaimsPrincipal User)
    : IRequest<WrapperResult<int>>;

public class ReviewDeleteByIdRequestHandler : IRequestHandler<ReviewDeleteByIdRequest, WrapperResult<int>>
{
    private readonly IBlogDbContext _blogDbContext;

    public ReviewDeleteByIdRequestHandler(IBlogDbContext blogDbContext)
    {
        _blogDbContext = blogDbContext;
    }

    public async Task<WrapperResult<int>> Handle(ReviewDeleteByIdRequest request, CancellationToken cancellationToken)
    {
        var result = WrapperResult.Build<int>();

        var review = _blogDbContext.Reviews.FirstOrDefault(m => m.Id == request.ReviewId);
        if (review is null)
        {
            result.ExceptionObject = new BlogEntityNotFoundException(nameof(Review), request.ReviewId);
            return result;
        }

        _blogDbContext.Reviews.Remove(review);
        await _blogDbContext.SaveChangesAsync(cancellationToken);
        return result;
    }
}
