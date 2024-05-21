using Blog.Application.Entries.Queries;
using FluentValidation;

namespace Blog.Application.Entries.Validators;

public class EntityCreateRequestValidation : AbstractValidator<EntityCreateRequest>
{
    public EntityCreateRequestValidation()
    {
        RuleFor(m => m.ViewModel.Id).NotEmpty();
        RuleFor(m => m.ViewModel.Title).NotEmpty();
        RuleFor(m => m.ViewModel.Content).NotEmpty();
        RuleFor(m => m.User).NotEmpty();
    }
}
