using CadastroProduto.Interfaces;
using CadastroProduto.Model;
using CadastroProduto.Servicos;
using CadastroProduto.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroProduto.Controllers
{
    public class CadastroController : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> IndexAsync(int? codigo)
        {
            Produto produto = null;

            ProdutoViewModel viewModel = null;

            if (codigo != null)
            {

                var client = new RestClient(string.Concat("https://localhost:44335/api/produto/pesquisar_por_codigo/", codigo));
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    produto = JsonConvert.DeserializeObject<Produto>(response.Content);
                    viewModel = ProdutoServico.ConverterModelEmViewModel(produto);
                }
                else
                    return NotFound();
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
            {
                var client = new RestClient("https://localhost:44335/api/produto/gravar");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(produto), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    produto = JsonConvert.DeserializeObject<Produto>(response.Content);
                else
                    produto = null;
            }
            else
            {
                var client = new RestClient("https://localhost:44335/api/produto/alterar");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(produto), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    produto = JsonConvert.DeserializeObject<Produto>(response.Content);
                else
                    produto = null;
            }

            if (produto != null && produto.Codigo > 0)
                return Ok();
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Pesquisar(string descricao, int filtro)
        {
            List<Produto> listaProduto = null;
            List<ProdutoViewModel> listaProdutoViewModels = null;

            string url = null;

            if (string.IsNullOrWhiteSpace(descricao))
                url = "https://localhost:44335/api/produto/listar_todos";
            else
                url = string.Format("https://localhost:44335/api/produto/por_descricao_filtro/{0}/{1}", descricao == null ? string.Empty : descricao, filtro);


            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                listaProduto = JsonConvert.DeserializeObject<List<Produto>>(response.Content);

            listaProdutoViewModels = new List<ProdutoViewModel>();

            if (listaProduto != null)
            {
                foreach (Produto item in listaProduto)
                {
                    listaProdutoViewModels.Add(ProdutoServico.ConverterModelEmViewModel(item));
                }
            }
            return PartialView("_Tabela", listaProdutoViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> ExcluirAsync(int? codigo)
        {

            Produto produto = null;
            var client = new RestClient(string.Concat("https://localhost:44335/api/produto/pesquisar_por_codigo/", codigo));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                produto = JsonConvert.DeserializeObject<Produto>(response.Content);

            if (produto != null)
            {
                client = new RestClient(string.Concat("https://localhost:44335/api/produto/excluir/", codigo));
                client.Timeout = -1;
                request = new RestRequest(Method.GET);
                response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return Ok();
            }

            return NotFound();
        }
    }
}
