using F23L034_SingletonToDependencyInjection.Demo.Models;
using F23L034_SingletonToDependencyInjection.Demo.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace F23L034_SingletonToDependencyInjection.Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingleton _singleton;
        private readonly IScoped _scoped;
        private readonly ITransient _transient;

        public HomeController(ILogger<HomeController> logger, ISingleton singleton, IScoped scoped, ITransient transient)
        {
            _logger = logger;
            _singleton = singleton;
            _scoped = scoped;
            _transient = transient;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = _singleton.GetHashCode();
            ViewBag.Scoped = _scoped.GetHashCode();
            ViewBag.Transient = _transient.GetHashCode();
            return View();
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