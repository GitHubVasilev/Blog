using Blog.Application.Reviews.Queries;
using FluentValidation;

namespace Blog.Application.Reviews.Validators;

public class ReviewGetLastRequestValidation : AbstractValidator<ReviewGetLastRequest>
{
    public ReviewGetLastRequestValidation()
    {
        RuleFor(m => m.User).NotNull();
        RuleFor(m => m.Count).GreaterThan(0);
    }
}
