using cinePlus.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace cinePlus.Controllers
{
    public class PeliculaController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:4000/peliculas");
        private readonly HttpClient _httpClient;

        public PeliculaController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<PeliculaModel> listaPeliculas = new List<PeliculaModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                listaPeliculas = JsonConvert.DeserializeObject<List<PeliculaModel>>(data);
            }
            return View(listaPeliculas);
        }
    }
}
