
using Application.UseCases.Usuario.Cadastrar;
using CommonTestUtilities.Requests;
using Exceptions;
using Exceptions.Enums;
using Shouldly;

namespace Validators.Test.Usuario.Cadastrar
{
    public class CadastrarUsuarioValidatorTest
    {
        [Fact]
        public void Sucesso()
        {
            var validator = new CadastrarUsuarioValidator();
            var request = RequestCadastrarUsuarioJsonBuilder.Build();
            var resultado = validator.Validate(request);

            //Assert
            resultado.IsValid.ShouldBeTrue();
        }
        
        [Fact]
        public void Erro_Nome_Vazio()
        {
            var validator = new CadastrarUsuarioValidator();
            var request = RequestCadastrarUsuarioJsonBuilder.Build();
            request.Nome = string.Empty;

            var resultado = validator.Validate(request);

            //Assert
            resultado.IsValid.ShouldBeFalse();
            resultado.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ResourceMessagesException.Get(ExceptionName.NOME_VAZIO));
        }

        [Fact]
        public void Erro_Email_Vazio()
        {
            var validator = new CadastrarUsuarioValidator();
            var request = RequestCadastrarUsuarioJsonBuilder.Build();
            request.Email = string.Empty;

            var resultado = validator.Validate(request);

            //Assert
            resultado.IsValid.ShouldBeFalse();
            resultado.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ResourceMessagesException.Get(ExceptionName.EMAIL_VAZIO));
        }

        [Fact]
        public void Erro_Email_Invalido()
        {
            var validator = new CadastrarUsuarioValidator();
            var request = RequestCadastrarUsuarioJsonBuilder.Build();
            request.Email = "email.com";

            var resultado = validator.Validate(request);

            //Assert
            resultado.IsValid.ShouldBeFalse();
            resultado.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ResourceMessagesException.Get(ExceptionName.EMAIL_INVALIDO));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Erro_Senha_Invalida(int passwordLength)
        {
            var validator = new CadastrarUsuarioValidator();
            var request = RequestCadastrarUsuarioJsonBuilder.Build(passwordLength);

            var resultado = validator.Validate(request);

            //Assert
            resultado.IsValid.ShouldBeFalse();
            resultado.Errors.ShouldHaveSingleItem().ErrorMessage.ShouldBe(ResourceMessagesException.Get(ExceptionName.SENHA_INVALIDA));
        }
    }
}