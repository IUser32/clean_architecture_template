using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.UoW;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositorios
            services.AddScoped<IBookRepository, BookRepository>();

            // Unidad de trabajo
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
