

using Application.Services.Cryptography;
using Application.Services.Mapping;
using Application.UseCases.Usuario.Cadastrar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddPasswordEncrypter(services, configuration);
            AddMapperConfiguration();
            AddUseCases(services);
        }
        private static void AddMapperConfiguration()
        {
            MapConfigurations.Configure();
        }
        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<ICadastrarUsuarioUseCase, CadastrarUsuarioUseCase>();
        }
        private static void AddPasswordEncrypter(IServiceCollection services, IConfiguration configuration)
        {
            var chaveAdicional = configuration.GetValue<string>("Configuracoes:Senha:ChaveAdicional");
            services.AddScoped(options => new PasswordEncripter(chaveAdicional!));
        }

    }
}