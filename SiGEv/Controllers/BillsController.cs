using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiGEv.Models;
using SiGEv.Models.ViewModels;
using SiGEv.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;

namespace SiGEv.Controllers
{
    public class BillsController : Controller
    {
        private readonly BillsService _billServices;
        private readonly SectionsService _sectionServices;
        private readonly VenuesService _venueServices;
        private readonly EventsService _eventServices;
        private readonly UsersService _userServices;

        public BillsController(BillsService billServices, SectionsService sectionServices,
            VenuesService venueServices, EventsService eventServices, UsersService userServices)

		{
            _billServices = billServices;
            _venueServices = venueServices;
            _sectionServices = sectionServices;
            _eventServices = eventServices;
			_userServices = userServices;

		}

        [Authorize(Policy = "CustomerAccess")]
        public IActionResult Index()
        {
            List<Bill> bills = new List<Bill>();
			if (User.IsInRole("Admin") || User.IsInRole("Employee"))
			{
				bills = _billServices.FindAll();
			} else if (User.IsInRole("Customer"))
			{
				User currentUser = _userServices.GetCurrentUser(this.User);
				bills = _billServices.FindByUserId(currentUser.Id);
			}
			return View(bills);
        }

        [Authorize(Policy = "CustomerAccess")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var bill = _billServices.FindById((int)id);
            if (bill == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            var tickets = bill.SelledTickets;
            int evId = 0;
            foreach (var item in tickets)
            {
                item.Venue = _venueServices.FindById(item.VenueId);
                item.Section = _sectionServices.FindById(item.SectionId);
                evId = item.SectionId;
            }
            var ev = _eventServices.FindById(evId);
            var viewModel = new DetailsViewModel { Bill = bill, Tickets = bill.SelledTickets, Event = ev };
            return View(viewModel);
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
