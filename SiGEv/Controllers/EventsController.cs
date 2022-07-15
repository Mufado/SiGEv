using Microsoft.AspNetCore.Authorization;
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
        private readonly UsersService _usersService;

        public EventsController(EventsService eventServices, VenuesService venueServices, SectionsService sectionsServices,
            BillsService billServices, TicketsService ticketServices, UsersService usersService)
        {
            _eventServices = eventServices;
            _venueServices = venueServices;
            _sectionsServices = sectionsServices;
            _billServices = billServices;
            _ticketServices = ticketServices;
            _usersService = usersService;
        }

        public IActionResult Index()
        {
            List<Event> events = _eventServices.GetAllEvents();
            return View(events);
        }

        [Authorize(Policy = "EmployeeAccess")]
        public IActionResult Create()
        {
            var venues = _venueServices.FindAll();
            var viewModel = new EventFormViewModel { Venues = venues };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
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
            var viewModel = new EventFormViewModel { Event = ev, Venue = venue, Sections = sections, Protocol = protocol };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(EventFormViewModel obj)
        {
            Section section = _sectionsServices.FindById(obj.SectionId);
            Event @event = _eventServices.FindById(section.Id);

            double billValue = section.CommonPrice * obj.TicketsQuantity;
            billValue += billValue * 5.0 / 100.0;

            User currentUser = _usersService.GetCurrentUser(this.User);

            Bill bill = new Bill
            {
                ClientName = obj.Bill.ClientName,
                ClientDocument = obj.Bill.ClientDocument,
                PaymentType = obj.Bill.PaymentType,
                DocumentType = obj.Bill.DocumentType,
                Type = obj.Bill.Type,
                Value = billValue,
                PaymentDate = DateTime.Now,
                Protocol = obj.Bill.Protocol,
                User = currentUser,
                UserId = currentUser.Id
            };

            _billServices.Insert(bill);

            List<Ticket> tickets = new List<Ticket>();
            for (int i = 0; i < obj.TicketsQuantity; i++)
            {
                tickets.Add(new Ticket
                {
                    BillId = bill.Id,
                    Bill = bill,
                    Price = section.CommonPrice,
                    VenueId = @event.VenueId,
                    Venue = @event.Venue,
                    SectionId = section.Id,
                    Section = section
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

        [HttpPost]
        [Authorize(Policy = "EmployeeAccess")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventFormViewModel ev)
        {
            _eventServices.Insert(ev.Event);
            return RedirectToAction(nameof(Index));
        }
    }
}
