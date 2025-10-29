

using Domain.Entities;
using Domain.Repositories.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class UsuarioRepository : IUsuarioWriteOnlyRepository, IUsuarioReadOnlyRepository
    {
        private readonly MeuLivroDeReceitasDbContext _dbContext;

        public UsuarioRepository(MeuLivroDeReceitasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(Usuario usuario) => await _dbContext.Usuarios.AddAsync(usuario);
        public async Task<bool> ExisteUsuarioAtivoComEmail(string email) => await _dbContext.Usuarios.AnyAsync(u => u.Email.Equals(email) && u.Ativo);
    }
}