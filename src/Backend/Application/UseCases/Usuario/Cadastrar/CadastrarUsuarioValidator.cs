
using Communication.Requests;
using Exceptions;
using FluentValidation;
namespace Application.UseCases.Usuario.Cadastrar
{
    public class CadastrarUsuarioValidator : AbstractValidator<RequestCadastrarUsuarioJson>
    {
        public CadastrarUsuarioValidator()
        {
            RuleFor(usuario => usuario.Nome).NotEmpty().WithMessage(ResourceMessagesException.Get("NOME_VAZIO"));
            RuleFor(usuario => usuario.Email).NotEmpty().WithMessage(ResourceMessagesException.Get("EMAIL_VAZIO"));
            RuleFor(usuario => usuario.Email).EmailAddress().WithMessage(ResourceMessagesException.Get("EMAIL_INVALIDO"));
            RuleFor(usuario => usuario.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.Get("SENHA_VAZIA"));
        }
    }
}