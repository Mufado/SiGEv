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
        private readonly VenuesService _venueServices;
        private readonly SectionsService _sectionsServices;
        private readonly BillsService _billServices;

        public EventsController(EventsService eventServices, VenuesService venueServices,
			SectionsService sectionsServices, BillsService billServices)
        {
            _eventServices = eventServices;
			_venueServices = venueServices;
			_sectionsServices = sectionsServices;
			_billServices = billServices;

		}

        public IActionResult Index()
        {
            List<Event> events = _eventServices.GetAllEvents();
            return View(events);
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

		 	var ev = _eventServices.FindById(id.Value);
			if (ev == null)
			{
				return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
			}

			var sections = _sectionsServices.FindAllEventsById(ev.Id);
			var venue = _venueServices.FindById(ev.VenueId);
			var viewModel = new EventFormViewModel {Event = ev, Venue = venue, Sections = sections };
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Buy(Bill ?obj)
		{
			//_billServices.Insert(obj);
			
			return RedirectToAction("Details", "Bills", new { id = 1 });
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
