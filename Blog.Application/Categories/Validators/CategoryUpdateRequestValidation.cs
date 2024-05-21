using Blog.Application.Categories.Queries;
using FluentValidation;

namespace Blog.Application.Categories.Validators;

public class CategoryUpdateRequestValidation : AbstractValidator<CategoryUpdateRequest>
{
    public CategoryUpdateRequestValidation()
    {
        RuleFor(m => m.ViewModel.Id).NotEmpty().NotEqual(Guid.Empty);
        RuleFor(m => m.ViewModel.Name).NotEmpty().Length(5, 50);
        RuleFor(m => m.ViewModel.Description).Length(0, 1024);
        RuleFor(m => m.User).NotNull();
    }
}
