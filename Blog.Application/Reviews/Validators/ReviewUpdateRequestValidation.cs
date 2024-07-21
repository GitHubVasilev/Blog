using Blog.Application.Reviews.Queries;
using FluentValidation;

namespace Blog.Application.Reviews.Validators;

public class ReviewUpdateRequestValidation : AbstractValidator<ReviewUpdateRequest>
{
    public ReviewUpdateRequestValidation()
    {
        RuleFor(m => m.User).NotEmpty().NotNull();
        RuleFor(m => m.ViewModel.Content).NotEmpty().NotNull().MaximumLength(2048);
        RuleFor(m => m.ViewModel.Id).NotEmpty();
        RuleFor(m => m.ViewModel.Rating).NotEmpty().GreaterThan(1).LessThanOrEqualTo(5);
    }
}
