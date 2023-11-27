using cinePlus.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace cinePlus.Controllers
{
    public class UsuarioController : Controller
    {
        Uri baseAddress = new Uri("https://jsonplaceholder.typicode.com/users");
        private readonly HttpClient _httpClient;

        public UsuarioController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UsuarioModel> listaUsuario = new List<UsuarioModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress).Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listaUsuario = JsonConvert.DeserializeObject<List<UsuarioModel>>(data);
            }
            return View(listaUsuario);
        }
    }
}
