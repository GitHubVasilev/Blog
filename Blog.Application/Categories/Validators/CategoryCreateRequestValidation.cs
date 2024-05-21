using Blog.Application.Categories.ViewModels;
using FluentValidation;

namespace Blog.Application.Categories.Validators;

public class CategoryCreateRequestValidation : AbstractValidator<CategoryCreateViewModel>
{
    public CategoryCreateRequestValidation()
    {
        RuleFor(m => m.Id).NotEmpty().NotEqual(Guid.Empty);
        RuleFor(m => m.Name).NotEmpty().Length(5, 50);
        RuleFor(m => m.Description).Length(0, 1024);
    }
}
