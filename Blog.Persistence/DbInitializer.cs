using Microsoft.Extensions.DependencyInjection;

namespace Blog.Persistence
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider) 
        {
            IServiceScope scope = serviceProvider.CreateScope();
            await using BlogDbContext context = scope.ServiceProvider.GetService<BlogDbContext>()!;
            context.Database.EnsureCreated();
        }
    }
}
