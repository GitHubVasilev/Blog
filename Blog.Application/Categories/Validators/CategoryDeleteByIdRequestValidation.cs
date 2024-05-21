using Blog.Application.Categories.Queries;
using FluentValidation;

namespace Blog.Application.Categories.Validators;

public class CategoryDeleteByIdRequestValidation : AbstractValidator<CategoryDeleteByIdRequest>
{
    public CategoryDeleteByIdRequestValidation()
    {
        RuleFor(m => m.CategoryId).NotEmpty();
        RuleFor(m => m.User).NotEmpty();
    }
}
