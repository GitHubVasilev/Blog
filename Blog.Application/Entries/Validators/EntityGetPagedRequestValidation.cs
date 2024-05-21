using Blog.Application.Entries.Queries;
using FluentValidation;

namespace Blog.Application.Entries.Validators;

public class EntityGetPagedRequestValidation : AbstractValidator<EntityGetPagedRequest>
{
    public EntityGetPagedRequestValidation()
    {
        RuleFor(m => m.PageIndex).NotEmpty();
        RuleFor(m => m.PageSize).NotEmpty();
    }
}
