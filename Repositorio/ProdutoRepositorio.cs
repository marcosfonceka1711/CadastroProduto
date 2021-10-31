
using CadastroProduto.Interfaces;
using CadastroProduto.Model;

namespace CadastroProduto.Repositorio
{
    public class ProdutoRepositorio : RepositorioGenerico<Produto>, IProdutoRepositorio
    {
        private readonly ContextoDb _contexto;

        public ProdutoRepositorio(ContextoDb contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}