using ProjetoApi1.Models;

namespace ProjetoApi1.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategoriasProdutos();
    }
}
