

namespace Domain.Repositories.Usuario
{
    public interface IUsuarioReadOnlyRepository
    {
        public Task<bool> ExisteUsuarioAtivoComEmail(string email);
    }
}