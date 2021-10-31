
using CadastroProduto.Interfaces;
using CadastroProduto.Model;
using System.Collections.Generic;
using System.Linq;

namespace CadastroProduto.Repositorio
{
    public class ProdutoRepositorio : RepositorioGenerico<Produto>, IProdutoRepositorio
    {
        private readonly ContextoDb _contexto;

        public ProdutoRepositorio(ContextoDb contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public List<Produto> PesquisarPorDescricaoFiltro(string descricao, int filtro)
        {
            List<Produto> listaProduto = null;


            /*
             * 1 - Ordena por descrição
             * 2 - Ordena por estoque positivo (somente)
             * 3 - Ordena por estoque negativo (somente)
             */

            if (descricao == null)
                descricao = string.Empty;

            switch (filtro)
            {
                case 1:
                    listaProduto = _contexto.Produto.Where(p => p.Descricao.Contains(descricao)).OrderBy(f => f.Descricao).ToList<Produto>();
                    break;
                case 2:
                    listaProduto = _contexto.Produto.Where(p => p.Descricao.Contains(descricao) && p.Estoque  >= 0).OrderBy(f => f.Descricao).ToList<Produto>();
                    break;
                case 3:
                    listaProduto = _contexto.Produto.Where(p => p.Descricao.Contains(descricao) && p.Estoque < 0).OrderBy(f => f.Descricao).ToList<Produto>();
                    break;
            }

            return listaProduto;
        }
    }
}