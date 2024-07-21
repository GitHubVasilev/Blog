using Blog.Application.Reviews.Queries;
using FluentValidation;

namespace Blog.Application.Reviews.Validators;

public class ReviewDeleteByIdRequestValidation : AbstractValidator<ReviewDeleteByIdRequest>
{
    public ReviewDeleteByIdRequestValidation()
    {
        RuleFor(m => m.ReviewId).NotEmpty();
        RuleFor(m => m.User).NotNull();
    }
}
