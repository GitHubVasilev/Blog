using Blog.Application.Reviews.Queries;
using FluentValidation;

namespace Blog.Application.Reviews.Validators;

public class ReviewGetForUpdateRequestValidation : AbstractValidator<ReviewGetForUpdateRequest>
{
    public ReviewGetForUpdateRequestValidation()
    {
        RuleFor(m => m.User).NotNull();
    }
}
