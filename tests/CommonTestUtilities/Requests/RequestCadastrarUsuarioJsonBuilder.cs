
using Bogus;
using Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestCadastrarUsuarioJsonBuilder
    {
        public static RequestCadastrarUsuarioJson Build(int passwordLength = 10)
        {
            return new Faker<RequestCadastrarUsuarioJson>()
            .RuleFor(user => user.Nome, (f) => f.Person.FirstName)
            .RuleFor(user => user.Email, (f, u) => f.Internet.Email(u.Nome))
            .RuleFor(user => user.Senha, (f) => f.Internet.Password(passwordLength));
        }
    }
}