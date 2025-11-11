

using Communication.Requests;
using Communication.Responses;
using Exceptions.ExceptionsBase;
using Mapster;
using Application.Services.Cryptography;
using Domain.Repositories.Usuario;
using Domain.Repositories;
using FluentValidation.Results;
using Exceptions;
using Exceptions.Enums;

namespace Application.UseCases.Usuario.Cadastrar
{
    public class CadastrarUsuarioUseCase : ICadastrarUsuarioUseCase
    {
        private readonly IUsuarioWriteOnlyRepository _writeOnlyRepository;
        private readonly IUsuarioReadOnlyRepository _readOnlyRepository;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly PasswordEncripter _passwordEncripter;

        public CadastrarUsuarioUseCase(
            IUsuarioWriteOnlyRepository writeOnlyRepository,
            IUsuarioReadOnlyRepository readOnlyRepository,
            PasswordEncripter passwordEncripter,
            IUnidadeDeTrabalho unidadeDeTrabalho
            )
        {
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
            _passwordEncripter = passwordEncripter;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }
        public async Task<ResponseUsuarioCadastradoJson> Executar(RequestCadastrarUsuarioJson request)
        {

            //1 validar a request
            await Validate(request);
            //2 mapear a request em uma entidade
            var usuario = request.Adapt<Domain.Entities.Usuario>();
            //3 Criptografar a senha
            usuario.Senha = _passwordEncripter.Encrypt(request.Senha);
            //4 Salvar no banco de dados
            await _writeOnlyRepository.Adicionar(usuario);

            await _unidadeDeTrabalho.Commit();
            return new ResponseUsuarioCadastradoJson()
            {
                Nome = request.Nome,
            };
        }

        private async Task Validate(RequestCadastrarUsuarioJson request)
        {
            var validator = new CadastrarUsuarioValidator();

            var resultado = validator.Validate(request);

            var emailExiste = await _readOnlyRepository.ExisteUsuarioAtivoComEmail(request.Email);

            if (emailExiste)
                resultado.Errors.Add(new ValidationFailure(string.Empty, ResourceMessagesException.Get(ExceptionName.EMAIL_JA_REGISTRADO)));

            if (resultado.IsValid == false)
            {
                var errorMessages = resultado.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErroNaValidacaoException(errorMessages);
            }
        }
    }
}