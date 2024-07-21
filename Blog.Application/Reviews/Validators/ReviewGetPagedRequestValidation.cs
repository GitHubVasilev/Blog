using Blog.Application.Reviews.Queries;
using FluentValidation;

namespace Blog.Application.Reviews.Validators;

public class ReviewGetPagedRequestValidation : AbstractValidator<ReviewGetPagedRequest>
{
    public ReviewGetPagedRequestValidation()
    {
        RuleFor(m => m.User).NotNull();
        RuleFor(m => m.PageIndex).GreaterThan(0);
        RuleFor(m => m.PageSize).GreaterThan(0);
    }
}
