using CadastroProduto.Interfaces;
using CadastroProduto.Model;
using CadastroProduto.Servicos;
using CadastroProduto.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public CadastroController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;

        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(int? codigo)
        {
            Produto produto = null;

            ProdutoViewModel viewModel = null;

            if (codigo != null)
            {
                produto = await _produtoRepositorio.RecuperarPorCodigo((int)codigo);
                viewModel = ProdutoServico.ConverterModelEmViewModel(produto);
            }
            else
                viewModel = new ProdutoViewModel();

            return View(viewModel);
        }

        public async Task<IActionResult> CadastrarAsync(ProdutoViewModel model)
        {

            Produto produto = null;
            produto = await ProdutoServico.ConverterViewModelEmModel(model);

            if (model.Codigo == 0)
                await _produtoRepositorio.Inserir(produto);
            else
                await _produtoRepositorio.Alterar(produto);

            if (produto.Codigo > 0)
                return Ok();
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Pesquisar(string descricao, int filtro)
        {
            List<Produto> listaProduto = null;
            List<ProdutoViewModel> listaProdutoViewModels = null;

            listaProduto = (List<Produto>)_produtoRepositorio.PesquisarPorDescricaoFiltro(descricao, filtro);
            listaProdutoViewModels = new List<ProdutoViewModel>();


            foreach (Produto item in listaProduto)
            {
                listaProdutoViewModels.Add(ProdutoServico.ConverterModelEmViewModel(item));
            }

            return PartialView("_Tabela", listaProdutoViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirAsync(int? codigo)
        {
            
            Produto produto = null;
            produto =  await _produtoRepositorio.RecuperarPorCodigo((int)codigo);

            if (produto != null)
            {
                await _produtoRepositorio.Excluir(produto);
                return Ok();
            }

            return NotFound();
        }
    }
}
