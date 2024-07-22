using Blog.Application.Entries.Queries;
using FluentValidation;

namespace Blog.Application.Entries.Validators;

public class EntityGEtByIdRequestValidation : AbstractValidator<EntityGetByIdRequest>
{
    public EntityGEtByIdRequestValidation()
    {
        RuleFor(m => m.User).NotNull();
        RuleFor(m => m.EntityId).NotEmpty();
    }
}
