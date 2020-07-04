using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Showcase.Application.Common.Interfaces;

namespace Showcase.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShowcaseDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ShowcaseDatabase"))
                        .UseSnakeCaseNamingConvention());

            services.AddScoped<IShowcaseDbContext>(provider => provider.GetService<ShowcaseDbContext>());

            return services;
        }
    }
}
