using Communication.Requests;
using Mapster;

namespace Application.Services.Mapping
{
    public class MapConfigurations
    {
        public static void Configure()
        {
            TypeAdapterConfig<RequestCadastrarUsuarioJson, Domain.Entities.Usuario>
                .NewConfig()
                .Ignore(dest => dest.Senha);
        }
    }
}