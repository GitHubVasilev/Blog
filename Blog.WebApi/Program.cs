using Blog.Persistence;
using Blog.Application;

namespace Blog.WebApi;

public class Program
{
    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AppPersistence(builder.Configuration);
        builder.Services.AddApplication();

        builder.Services.AddControllers();

        // TODO: Проверить. Скорее всего это не нужно
        builder.Services.AddCors(option => 
        {
            option.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        var app = builder.Build();

        try
        {
            using (var scope = app.Services.CreateScope())
            {
                await DbInitializer.InitializeAsync(scope.ServiceProvider);
            }
        }
        catch (Exception ex) 
        {
        }
        
        app.UseRouting();
        app.UseHttpsRedirection();

        // TODO: Проверить. Скорее всего это не нужно
        app.UseCors(cors => cors
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}
