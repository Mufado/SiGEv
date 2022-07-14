using Microsoft.AspNetCore.Mvc;
using SiGEv.Models;
using SiGEv.Models.ViewModels;
using SiGEv.Services;
using SiGEv.Utils;
using System;
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

			var sections = _sectionsServices.GetSectionListByEventId(ev.Id);
			var venue = _venueServices.GetVenueById(ev.VenueId);
			var protocol = StringProtocol.RandomString();
			var viewModel = new EventFormViewModel {Event = ev, Venue = venue, Sections = sections , Protocol=protocol};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Buy(EventFormViewModel obj)
		{
			Section section = _sectionsServices.GetSectionById(obj.SectionId);

			double billValue = section.CommonPrice * obj.TicketsQuantity;

			Bill bill = new Bill
			{
				ClientName = obj.Bill.ClientName,
				ClientDocument = obj.Bill.ClientDocument,
				PaymentType = obj.Bill.PaymentType,
				DocumentType = obj.Bill.DocumentType,
				Type = obj.Bill.Type,
				Value = billValue,
				PaymentDate = DateTime.Now,
				Protocol=obj.Bill.Protocol,
				UserId=2
			};

			_billServices.Insert(bill); //Não descomenta ainda pq tá faltando pegar o User

			return RedirectToAction("Details", "Bills", new { id = bill.Id });
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
