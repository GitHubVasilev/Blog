using Blog.Application.Reviews.Queries;
using FluentValidation;

namespace Blog.Application.Reviews.Validators;

public class ReviewGetByIdRequestValidation : AbstractValidator<ReviewGetByIdRequest>
{
    public ReviewGetByIdRequestValidation()
    {
        RuleFor(x => x.ReviewId).NotEmpty();
        RuleFor(x => x.User).NotNull();
    }
}
