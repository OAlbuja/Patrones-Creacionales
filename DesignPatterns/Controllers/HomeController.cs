using DesignPatterns.Creators;
using DesignPatterns.Models;
using DesignPatterns.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IVehicleRepository _vehicleRepository;

        public HomeController(IVehicleRepository vehicleRepository,ILogger<HomeController> logger)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.Vehicles = _vehicleRepository.GetVehicles();
            string error = Request.Query.ContainsKey("error") ? Request.Query["error"].ToString() : null;
            ViewBag.ErrorMessage = error;

            return View(model);
        }

		//      [HttpGet]
		//      public IActionResult AddMustang() //aplicando cambios para usar el patrón builder
		//      {
		//          var builder = new CarModelBuilder();
		//          _vehicleRepository.AddVehicle(builder.Build());
		//          return Redirect("/");
		//      }

		//      [HttpGet]
		//      public IActionResult AddExplorer() //aplicando cambios para usar el patrón builder
		//{
		//          var builder = new CarModelBuilder()
		//              .SetModel("Explorer")
		//              .SetColor("blue");
		//	_vehicleRepository.AddVehicle(builder.Build());
		//	return Redirect("/");
		//      }

		[HttpGet]
		public IActionResult AddMustang() //aplicando cambios para usar el patrón Factory
		{
			Creator creator = new FordMustangCreator();
			_vehicleRepository.AddVehicle(creator.Create());
			return Redirect("/");
		}

		[HttpGet]
		public IActionResult AddExplorer() //aplicando cambios para usar el patrón Factory
		{
            Creator creator = new FordExplorerCreator();
			_vehicleRepository.AddVehicle(creator.Create());
			return Redirect("/");
		}

		[HttpGet]
		public IActionResult AddEscape() //aplicando cambios para usar el patrón Factory
		{
			Creator creator = new FordEscapeCreator();
			_vehicleRepository.AddVehicle(creator.Create());
			return Redirect("/");
		}

		[HttpGet]
        public IActionResult StartEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StartEngine();
                return Redirect("/");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
          
        }

        [HttpGet]
        public IActionResult AddGas(string id)
        {

            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.AddGas();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult StopEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StopEngine();
                return Redirect("/");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return Redirect($"/?error={ex.Message}");
            }
           
           
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
