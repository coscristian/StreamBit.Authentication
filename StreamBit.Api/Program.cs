using StreamBit.Application;
using StreamBit.Infrastructure;

namespace StreamBit.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Add swagger

            app.MapControllers();

            app.Run();
        }
    }
}
