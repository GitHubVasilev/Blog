using Blog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AppPersistence(this IServiceCollection services, IConfiguration configuration) 
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<BlogDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IBlogDbContext>(provider =>
                provider.GetService<BlogDbContext>());
        return services;
    }
}
