using CadastroProduto.Model;
using CadastroProduto.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Servicos
{
    public static class ProdutoServico
    {

        public static async Task<Produto> ConverterViewModelEmModel(ProdutoViewModel viewModel)
        {
            Produto model = new Produto();

            model.Codigo = viewModel.Codigo;
            model.Descricao = viewModel.Descricao;
            model.Estoque = viewModel.Estoque;
            model.Preco = viewModel.Preco;

            return model;
        }

        public static ProdutoViewModel ConverterModelEmViewModel(Produto model)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();

            viewModel.Codigo = model.Codigo;
            viewModel.Descricao = model.Descricao;
            viewModel.Estoque = model.Estoque;
            viewModel.Preco = model.Preco;

            return viewModel;
        }
    }
}
