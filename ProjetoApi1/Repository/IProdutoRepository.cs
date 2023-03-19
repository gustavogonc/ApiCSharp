using ProjetoApi1.Models;

namespace ProjetoApi1.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetProdutosPorPreco();
    }
}
