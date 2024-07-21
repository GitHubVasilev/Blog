using Blog.Application.Reviews.Queries;
using FluentValidation;

namespace Blog.Application.Reviews.Validators;

public class ReviewGetAllTreeRequestValidation : AbstractValidator<ReviewGetAllTreeRequest>
{
    public ReviewGetAllTreeRequestValidation()
    {
        RuleFor(m => m.User);
    }
}
