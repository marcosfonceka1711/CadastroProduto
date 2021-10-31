using CadastroProduto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContextoDb _contexto;

        public HomeController(ContextoDb contexto, ILogger<HomeController> logger)
        {
            _contexto = contexto;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            await _contexto.Database.MigrateAsync();
            return View();
        }

       



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
