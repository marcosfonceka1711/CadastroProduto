using CadastroProduto.Model;
using CadastroProduto.ViewModel;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroProduto.Interfaces
{
    public interface IProdutoApi
    {

        [Post("api/produto")]
        Task<ProdutoViewModel> Gravar(ProdutoViewModel produtoViewModel);

        [Put("api/produto")]
        Task<ProdutoViewModel> Alterar(ProdutoViewModel produtoViewModel);

        [Get("api/produto/por_descricao_filtro/{descricao}/{filtro}")]
        Task<List<Produto>> PesquisarPorDescricaoFiltro(string descricao, int filtro);

        [Get("api/produto/excluir/{codigo}")]
        Task Excluir(int codigo);

        [Get("api/produto/pesquisar_por_codigo/{codigo}")]
        Task<List<Produto>> PesquisarPorCodigo(string descricao, int filtro);

        [Get("api/produto")]
        Task<List<Produto>> ListarTodos();

    }
}
