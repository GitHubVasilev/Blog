using Blog.Application.Categories.Mappers;
using Blog.Application.Categories.ViewModels;
using Blog.Application.Common.Behaviors;
using Blog.Application.Entries.Mappers;
using Blog.Application.Entries.ViewModels;
using Blog.Application.Interfaces;
using Blog.Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region CustomeMappers
        services.AddSingleton<ICustomMapper<Entity, EntityGetViewModel>, EntityGetMapper>();
        services.AddSingleton<ICustomMapper<Entity, EntityCreateViewModel>, EntityCreateMapper>();
        services.AddSingleton<ICustomMapper<Category, CategoryGetViewModel>, CategoryGetMapper>();
        services.AddSingleton<ICustomMapper<Category, CategoryDetailViewModel>, CategoryDetailMapper>();
        services.AddSingleton<ICustomMapper<Category, CategoryCreateViewModel>, CategoryCreateMapper>();
        services.AddSingleton<ICustomMapper<Category, CategoryUpdateViewModel>, CategoryUpdateMapper>();
        services.AddScoped<TreeBuilder<Category, CategoryGetViewModel>>();
        #endregion

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        return services;
    }
}
