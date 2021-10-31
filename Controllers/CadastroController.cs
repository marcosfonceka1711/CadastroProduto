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
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CadastrarAsync(ProdutoViewModel model)
        {

            Produto produto = null;
            produto = await ProdutoServico.ConverterViewModelEmModel(model);

            await _produtoRepositorio.Inserir(produto);

            if (produto.Codigo > 0)
                return Ok();
            else
                return NotFound();
        }
    }
}
