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
		public BillsController(BillsService billServices, SectionsService sectionServices,
			VenuesService venueServices)
		{
			_billServices = billServices;
			_venueServices = venueServices;
			_sectionServices = sectionServices;
		}

		[Authorize(Policy = "EmployeeAccess")]
		public IActionResult Index()
		{
			List<Bill> bills;
			bills = _billServices.FindAll();
			/* if (User.IsInRole("Administrator") || User.IsInRole("Employee"))
			{
				
			}*/
			return View(bills);
		}

		[Authorize(Policy = "CustomerAccess")]
		public IActionResult Details(int ? id)
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

			foreach (var item in tickets)
			{
				item.Venue = _venueServices.FindById(item.VenueId);
				item.Section = _sectionServices.FindById(item.SectionId);
			}

			var viewModel= new DetailsViewModel { Bill = bill, Tickets= bill.SelledTickets};
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
