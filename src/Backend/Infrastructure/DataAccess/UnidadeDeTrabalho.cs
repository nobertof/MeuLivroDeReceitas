using Domain.Repositories;

namespace Infrastructure.DataAccess
{
    public class UnidadeDeTrabalho:IUnidadeDeTrabalho
    {
        private readonly MeuLivroDeReceitasDbContext _dbContext;
        public UnidadeDeTrabalho(MeuLivroDeReceitasDbContext dbContext) => _dbContext = dbContext;

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}