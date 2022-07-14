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
        private readonly TicketsService _ticketServices;

        public EventsController(EventsService eventServices, VenuesService venueServices,
			SectionsService sectionsServices, BillsService billServices, TicketsService ticketServices)
        {
            _eventServices = eventServices;
			_venueServices = venueServices;
			_sectionsServices = sectionsServices;
			_billServices = billServices;
			_ticketServices = ticketServices;

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
			var venue = _venueServices.FindById(ev.VenueId);
			var protocol = StringProtocol.RandomString();
			var viewModel = new EventFormViewModel {Event = ev, Venue = venue, Sections = sections , Protocol=protocol};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Buy(EventFormViewModel obj)
		{
			Section section = _sectionsServices.FindById(obj.SectionId);
			Event ev = _eventServices.FindById(section.Id);

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

			var tickets= new List<Ticket>();
			for (int i = 0; i < obj.TicketsQuantity; i++)
			{
				tickets.Add(new Ticket {
					BillId = bill.Id,
					Bill = bill,
					Price = section.CommonPrice,
					VenueId = ev.VenueId,
					Venue = ev.Venue,
					SectionId=section.Id,
					Section=section
				});
			}
			_ticketServices.InsertAll(tickets);
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
