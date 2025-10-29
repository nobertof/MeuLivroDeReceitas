

using Communication.Requests;
using Communication.Responses;

namespace Application.UseCases.Usuario.Cadastrar
{
    public interface ICadastrarUsuarioUseCase
    {
        public Task<ResponseUsuarioCadastradoJson> Executar(RequestCadastrarUsuarioJson request);
    }
}