using Microsoft.EntityFrameworkCore;
using ProjetoApi1.Context;
using ProjetoApi1.Models;

namespace ProjetoApi1.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext contexto) : base(contexto)
        {

        }
        public IEnumerable<Categoria> GetCategoriasProdutos()
        {
            return Get().Include(x => x.Produtos);
        }
    }
}
