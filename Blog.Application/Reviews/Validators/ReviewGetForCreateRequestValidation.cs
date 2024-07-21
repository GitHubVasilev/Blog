using Blog.Application.Reviews.Queries;
using FluentValidation;

namespace Blog.Application.Reviews.Validators;

public class ReviewGetForCreateRequestValidation : AbstractValidator<ReviewGetForCreateRequest>
{
    public ReviewGetForCreateRequestValidation()
    {
        RuleFor(m => m.User).NotNull();
    }
}
