using Blog.Application.Categories.Queries;
using FluentValidation;

namespace Blog.Application.Categories.Validators;

public class CategoryGetByIdRequestValidation : AbstractValidator<CategoryDeleteByIdRequest>
{
    public CategoryGetByIdRequestValidation()
    {
        RuleFor(m => m.CategoryId).NotEmpty();
    }
}
