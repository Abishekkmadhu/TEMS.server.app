using Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Register EFCore DB contexts.
            services.AddDbContext<TravelDBContext>(options =>
                options.UseSqlServer("Server=LAPTOP-C0CETLMF;Database=TEMS_DB;Trusted_Connection=True;TrustServerCertificate=True;"));
            //Register Repository and interfaces 

            return services;
        }
    }
}
