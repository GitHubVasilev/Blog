using Blog.Application.Categories.Queries;
using FluentValidation;

namespace Blog.Application.Categories.Validators;

public class CategoryGetPagedRequestValidation : AbstractValidator<CategoryGetPagedRequest>
{
    public CategoryGetPagedRequestValidation()
    {
        RuleFor(m => m.PageIndex).NotEmpty();
        RuleFor(m => m.PageSize).NotEmpty();
    }
}
