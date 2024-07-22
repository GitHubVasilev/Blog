using Blog.Application.Entries.Queries;
using FluentValidation;

namespace Blog.Application.Entries.Validators;

public class EntityGetAllRequestValidation : AbstractValidator<EntityGetAllRequest>
{
    public EntityGetAllRequestValidation()
    {
        RuleFor(m => m.User).NotNull();  
    }
}
