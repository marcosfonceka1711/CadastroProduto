
using CadastroProduto.Model;
using System.Collections.Generic;
using static CadastroProduto.Interfaces.IRepositorioGenerico;

namespace CadastroProduto.Interfaces
{
    public interface IProdutoRepositorio : IRepositorioGenerico<Produto>
    {
        List<Produto> PesquisarPorDescricaoFiltro(string descricao, int filtro);
    }
}
