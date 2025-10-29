

namespace Domain.Repositories.Usuario
{
    public interface IUsuarioWriteOnlyRepository
    {
        public Task Adicionar(Entities.Usuario usuario);
    }
}