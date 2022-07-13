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
		public BillsController(BillsService billServices)
		{
			_billServices = billServices;
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
			return View(bill);
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
