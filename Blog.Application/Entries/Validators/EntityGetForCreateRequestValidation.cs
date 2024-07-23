using Blog.Application.Entries.Queries;
using FluentValidation;

namespace Blog.Application.Entries.Validators;

public class EntityGetForCreateRequestValidation : AbstractValidator<EntityGetForCreateRequest>
{
    public EntityGetForCreateRequestValidation()
    {
        RuleFor(m => m.User).NotNull();
    }
}
