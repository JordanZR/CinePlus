using cinePlus.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace cinePlus.Controllers
{
    public class PeliculaController : Controller
    {
        Uri getPeliculas = new Uri("http://localhost:4000/peliculas");
        Uri getPoints, updatePuntos;
        int nuevosPuntos;

        private readonly HttpClient _httpClient;

        public PeliculaController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = getPeliculas;
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

        [HttpPost]
        public IActionResult SubirPunto([FromRoute] int id)
        {
            //Primero obtenemos la cantidad de puntos de esa pelicula con su ID
            getPoints = new Uri("http://localhost:4000/peliculas/puntos/" + id);
            _httpClient.BaseAddress = getPoints;
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                PeliculaModel pelicula = JsonConvert.DeserializeObject<PeliculaModel>(data);
                nuevosPuntos = pelicula.Puntos + 1;
            }

            //Subimos los puntos
            updatePuntos = new Uri("http://localhost:4000/peliculas/update/" + id + "/" + nuevosPuntos);
            HttpClient _httpClient2 = new HttpClient();
            _httpClient2.BaseAddress = updatePuntos;

            response = _httpClient2.GetAsync(_httpClient2.BaseAddress).Result;
            return RedirectToAction("Index");
        }
    }
}
