using Blog.Persistence;
using Blog.Application;
using Blog.WebApi.Identity;
using Blog.WebApi.Swagger;

namespace Blog.WebApi;

public class Program
{
    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AppPersistence(builder.Configuration);
        builder.Services.AddApplication();
        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();

        builder.Services
            .AddOpenIddict()
            .AddValidation(options =>
            {
                // Import the configuration from the local OpenIddict server instance.
                options.SetIssuer("https://localhost:7100/");
                // Register the ASP.NET Core host.
                options.UseAspNetCore();
                options.UseSystemNetHttp();
            });
        AuthorizationConfiguration.ConfigureServices(builder);
        SwaggerConfiguration.ConfigureServices(builder.Services, builder);
        
        builder.Services.AddCors(option => 
        {
            option.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.SetIsOriginAllowed(host => true);
                policy.AllowCredentials();
            });
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            await DbInitializer.InitializeAsync(scope.ServiceProvider);
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("CorsPolicy");
        app.UseAuthentication();
        app.UseAuthorization();
        
        SwaggerConfiguration.ConfigureApplication(app);
        app.MapDefaultControllerRoute();

        UserIdentity.Instance.Configure(app.Services.GetService<IHttpContextAccessor>()!);
        app.Run();
    }
}
