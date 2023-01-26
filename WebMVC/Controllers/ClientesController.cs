using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using System.Text;

namespace WebMVC.Controllers
{
    public class ClientesController : Controller
    {
        string apiUrl = "https://localhost:44311/";

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.GetAsync(@"api\clientes");
                }
                catch(Exception ex)
                { 
                    TempData["Error"] = "Erro ao se conectar com o servidor: " + ex.Message;
                    return View(new List<Cliente>());
                }

                if (response.IsSuccessStatusCode)
                {
                    var clientesJson = response.Content.ReadAsStringAsync().Result;
                    List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(clientesJson);

                    return View(clientes);
                }
                else
                {
                    TempData["Error"] = "Erro ao adquirir clientes: " + response.StatusCode.ToString();
                    System.Diagnostics.Debug.WriteLine(response.ToString());
                }
            }

            return View(new List<Cliente>());
        }

        // POST or PUT Cliente
        [HttpPost]
        public async Task<ActionResult> SaveCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = new HttpResponseMessage();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    cliente.Id = cliente.Id == null ? 0 : cliente.Id;  

                    var jsonCliente = JsonConvert.SerializeObject(cliente);
                    HttpContent content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");

                    if (cliente.Id == 0)
                    {
                        try
                        {
                            response = await client.PostAsync(@"api\clientes", content);
                        }
                        catch(Exception ex)
                        {
                            TempData["Error"] = "Erro ao se conectar com o servidor: " + ex.Message;
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        try
                        {
                            response = await client.PutAsync(@"api\clientes", content);
                        }
                        catch (Exception ex)
                        {
                            TempData["Error"] = "Erro ao se conectar com o servidor: " + ex.Message;
                            return RedirectToAction("Index");
                        }
                    }

                    if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
                    {
                        TempData["Message"] = "Cliente salvo com sucesso!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = "Erro ao salvar cliente: " + response.StatusCode.ToString();
                        System.Diagnostics.Debug.WriteLine(response.ToString());
                    }
                }
            }

            return RedirectToAction("Index");
        }

        // DELETE Cliente
        [HttpPost]
        public async Task<ActionResult> Delete(long id)
        { 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync($@"api\clientes\{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(response.ToString());
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            ViewBag.UFs = GetUFs();
            ViewBag.Orgaos = GetOrgaosExpedicao();
            ViewBag.Generos = GetGeneros();
            ViewBag.EstadosCivil = GetEstadosCivil();

            return View("Registration", null);
        }

        public async Task<ActionResult> Edit(long id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    response = await client.GetAsync($@"api\clientes\{id}");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Erro ao se conectar com o servidor: " + ex.Message;
                    return RedirectToAction("Index");
                }

                if (response.IsSuccessStatusCode)
                {
                    Cliente cliente = JsonConvert.DeserializeObject<Cliente>(await response.Content.ReadAsStringAsync());

                    ViewBag.UFs = GetUFs();
                    ViewBag.Orgaos = GetOrgaosExpedicao();
                    ViewBag.Generos = GetGeneros();
                    ViewBag.EstadosCivil = GetEstadosCivil();
                    return View("Registration", cliente);
                }
                else
                {
                    TempData["Error"] = "Erro ao adquirir cliente: " + response.StatusCode.ToString();
                    System.Diagnostics.Debug.WriteLine(response.ToString());
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Info(long id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    response = await client.GetAsync($@"api\clientes\{id}");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Erro ao se conectar com o servidor: " + ex.Message;
                    return RedirectToAction("Index");
                }

                if (response.IsSuccessStatusCode)
                {
                    Cliente cliente = JsonConvert.DeserializeObject<Cliente>(await response.Content.ReadAsStringAsync());

                    ViewBag.UFs = GetUFs();
                    ViewBag.Orgaos = GetOrgaosExpedicao();
                    ViewBag.Generos = GetGeneros();
                    ViewBag.EstadosCivil = GetEstadosCivil();
                    return View("Info", cliente);
                }
                else
                {
                    TempData["Error"] = "Erro ao adquirir cliente: " + response.StatusCode.ToString();
                    System.Diagnostics.Debug.WriteLine(response.ToString());
                }
            }

            return RedirectToAction("Index");
        }

        public List<SelectListItem> GetUFs()
        {
            List<SelectListItem> ufs = new List<SelectListItem>
            {
                new SelectListItem { Text = "...", Value = "" },
                new SelectListItem { Text = "Acre", Value = "AC" },
                new SelectListItem { Text = "Alagoass", Value = "AL" },
                new SelectListItem { Text = "Amapá", Value = "AP" },
                new SelectListItem { Text = "Amazonas", Value = "AM" },
                new SelectListItem { Text = "Bahia", Value = "BA" },
                new SelectListItem { Text = "Ceará", Value = "CE" },
                new SelectListItem { Text = "Espírito Santo", Value = "ES" },
                new SelectListItem { Text = "Goiás", Value = "GO" },
                new SelectListItem { Text = "Maranhão", Value = "MA" },
                new SelectListItem { Text = "Mato Grosso", Value = "MT" },
                new SelectListItem { Text = "Mato Grosso do Sul", Value = "MS" },
                new SelectListItem { Text = "Minas Gerais", Value = "MG" },
                new SelectListItem { Text = "Pará", Value = "PA" },
                new SelectListItem { Text = "Paraíba", Value = "PB" },
                new SelectListItem { Text = "Paraná", Value = "PR" },
                new SelectListItem { Text = "Pernambuco", Value = "PE" },
                new SelectListItem { Text = "Piauí", Value = "PI" },
                new SelectListItem { Text = "Rio de Janeiro", Value = "RJ" },
                new SelectListItem { Text = "Rio Grande do Norte", Value = "RN" },
                new SelectListItem { Text = "Rio Grande do Sul", Value = "RS" },
                new SelectListItem { Text = "Rondônia", Value = "RO" },
                new SelectListItem { Text = "Roraima", Value = "RR" },
                new SelectListItem { Text = "Santa Catarina", Value = "SC" },
                new SelectListItem { Text = "São Paulo", Value = "SP" },
                new SelectListItem { Text = "Sergipe", Value = "SE" },
                new SelectListItem { Text = "Tocantins", Value = "TO" },
                new SelectListItem { Text = "Distrito Federal", Value = "DF" }
            };

            return ufs;
        }

        public List<SelectListItem> GetOrgaosExpedicao()
        {
            List<SelectListItem> orgaos = new List<SelectListItem>
            {
                new SelectListItem { Text = "...", Value = "" },
                new SelectListItem { Text = "SSP", Value = "SSP" },
                new SelectListItem { Text = "Cartório Civil", Value = "CC" },
                new SelectListItem { Text = "Polícia Federal", Value = "PF" },
                new SelectListItem { Text = "DETRAN", Value = "DETRAN" },
                new SelectListItem { Text = "Outro", Value = "OUTRO" }
            };

            return orgaos;
        }

        public List<SelectListItem> GetGeneros()
        {
            List<SelectListItem> generos = new List<SelectListItem>
            {
                new SelectListItem { Text = "...", Value = "" },
                new SelectListItem { Text = "Masculino", Value = "Masculino" },
                new SelectListItem { Text = "Feminino", Value = "Feminino" },
                new SelectListItem { Text = "Outro", Value = "Outro" }
            };

            return generos;
        }

        public List<SelectListItem> GetEstadosCivil()
        {
            List<SelectListItem> generos = new List<SelectListItem>
            {
                new SelectListItem { Text = "...", Value = "" },
                new SelectListItem { Text = "Solteiro", Value = "Solteiro" },
                new SelectListItem { Text = "Casado", Value = "Casado" },
                new SelectListItem { Text = "Separado", Value = "Separado" },
                new SelectListItem { Text = "Divorciado", Value = "Divorciado" },
                new SelectListItem { Text = "Viúvo", Value = "Viúvo" },
            };

            return generos;
        }
    }
}