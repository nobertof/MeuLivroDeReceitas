using Domain.Repositories;
using Domain.Repositories.Usuario;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            services.AddDbContext<MeuLivroDeReceitasDbContext>(options =>
            {
                options.UseNpgsql(
                connectionString!,
                builder =>
                {
                    builder.MigrationsAssembly("Infrastructure");
                    builder.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorCodesToAdd: null
                    );
                });

            });

        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
            services.AddScoped<IUsuarioWriteOnlyRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioReadOnlyRepository, UsuarioRepository>();
        }
    }
}