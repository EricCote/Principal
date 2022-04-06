using Microsoft.AspNetCore.Mvc;
using Principal.Models;
using Principal.Services;
using System.Diagnostics;

namespace Principal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICompteur _compteur;
        public HomeController(ILogger<HomeController> logger, ICompteur compteur)
        {
            _logger = logger;
            _compteur = compteur;
        }

        public IActionResult Index()
        {
            ICompteur model = _compteur;
            //model.Visite();
            //Créer un midddleware qui fait deux choses:
            //1. Obtenir une référence au service compteur
            //2. Incrémente celui-ci avec visite
            //3. Ajouter une entête à la réponse, qui sera "x-compteur: 4"
            return View(model);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}