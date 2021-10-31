using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using CadastroProduto.Interfaces;

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
        public async Task<IActionResult> ListarTodos(CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepositorio.ListarTodos();

            if (produtos.Any())
                return Ok(produtos);
            else
                return NoContent();
        }

        [HttpGet("{codigo:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PesquisarPorCodigo(int codigo, CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepositorio.RecuperarPorCodigo(codigo);

            if (produtos != null)
                return Ok(produtos);
            else
                return NoContent();
        }
    }
}
