using Microsoft.AspNetCore.Mvc;
using SiGEv.Models;
using SiGEv.Models.ViewModels;
using SiGEv.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace SiGEv.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsService _eventServices;

        public EventsController(EventsService eventServices)
        {
            _eventServices = eventServices;
        }

        public IActionResult Index()
        {
            List<Event> events = _eventServices.GetAllEvents();
            return View(events);
        }

		public IActionResult Create()
		{
			return View();
		}

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new {message= "Id não fornecido" });
			}

			var obj = _eventServices.FindById(id.Value);
			if (obj == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
			}

			return View(obj);
		}

		public IActionResult Buy(int? id)
		{
			if (id == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
			}

			var obj = _eventServices.FindById(id.Value);
			if (obj == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
			}

			return View(obj);
		}

		public IActionResult Error(string message)
		{
			var viewModel = new ErrorViewModel
			{
				Message = message,
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			};

			return View(viewModel);
		}

	}
}
