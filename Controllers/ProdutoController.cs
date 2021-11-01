using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CadastroProduto.Interfaces;
using CadastroProduto.ViewModel;
using CadastroProduto.Model;
using CadastroProduto.Servicos;

namespace CadastroProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("listar_todos/")]
        public async Task<IActionResult> ListarTodos()
        {
            var produtos = await _produtoRepositorio.ListarTodos();

            if (produtos.Any())
                return Ok(produtos);
            else
                return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("pesquisar_por_codigo/{codigo}")]
        public async Task<IActionResult> PesquisarPorCodigo(int codigo)
        {
            var produtos = await _produtoRepositorio.RecuperarPorCodigo(codigo);

            if (produtos != null)
                return Ok(produtos);
            else
                return NoContent();
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("por_descricao_filtro/{descricao}/{filtro}")]
        public IActionResult PesquisarPorDescricaoFiltro(string descricao, int filtro)
        {
            var produtos = _produtoRepositorio.PesquisarPorDescricaoFiltro(descricao, filtro);

            if (produtos != null)
                return Ok(produtos);
            else
                return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("excluir/{codigo}")]
        public async Task<IActionResult> Excluir(int codigo)
        {
            var produto = await _produtoRepositorio.RecuperarPorCodigo(codigo);

            if (produto != null)
            {
                await _produtoRepositorio.Excluir(produto);
                return Ok();
            }
            else
                return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("gravar/")]
        public async Task<IActionResult> Gravar(ProdutoViewModel produtoViewModel)
        {
            Produto produto = null;

            var resultadoValidacao = Validar(produtoViewModel);

            if (!string.IsNullOrWhiteSpace(resultadoValidacao))
                return NotFound(resultadoValidacao);

            produto = await ProdutoServico.ConverterViewModelEmModel(produtoViewModel);

            await _produtoRepositorio.Inserir(produto);

            if (produto.Codigo > 0)
                return Ok(produto);
            else
                return NotFound("Falha ao gravar produto");

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("alterar/")]
        public async Task<IActionResult> Alterar(ProdutoViewModel produtoViewModel)
        {
            Produto produto = null;

            var resultadoValidacao = Validar(produtoViewModel);

            if (!string.IsNullOrWhiteSpace(resultadoValidacao))
                return NotFound(resultadoValidacao);

            produto = await ProdutoServico.ConverterViewModelEmModel(produtoViewModel);

            await _produtoRepositorio.Alterar(produto);

            if (produto.Codigo > 0)
                return Ok(produto);
            else
                return NotFound("Falha ao alterar produto");

        }

        private string Validar(ProdutoViewModel produtoViewModel)
        {
            if(produtoViewModel != null)
            {
                if(string.IsNullOrWhiteSpace(produtoViewModel.Descricao))
                    return "O campo descrição é obrigatório";
                else if(produtoViewModel.Descricao.Length > 200)
                    return "O campo descrição comporta no máximo 200 caracteres.";

                if (produtoViewModel.Preco < 0)
                    return "O campo preço não pode ser negativo.";
                else
                    return string.Empty;
            }
            else
            {
                return "Falha ao gravar produto.";
            }
        }
    }
}
