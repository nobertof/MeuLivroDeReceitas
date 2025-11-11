
using Communication.Requests;
using Exceptions;
using Exceptions.Enums;
using FluentValidation;
namespace Application.UseCases.Usuario.Cadastrar
{
    public class CadastrarUsuarioValidator : AbstractValidator<RequestCadastrarUsuarioJson>
    {
        public CadastrarUsuarioValidator()
        {
            RuleFor(usuario => usuario.Nome).NotEmpty().WithMessage(ResourceMessagesException.Get(ExceptionName.NOME_VAZIO));
            RuleFor(usuario => usuario.Email).NotEmpty().WithMessage(ResourceMessagesException.Get(ExceptionName.EMAIL_VAZIO));
            RuleFor(usuario => usuario.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.Get(ExceptionName.SENHA_INVALIDA));
            When(usuario => String.IsNullOrEmpty(usuario.Email) == false, () =>
            {
                RuleFor(usuario => usuario.Email).EmailAddress().WithMessage(ResourceMessagesException.Get(ExceptionName.EMAIL_INVALIDO));
            });
        }
    }
}