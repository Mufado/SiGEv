using Microsoft.AspNetCore.Mvc;
using SiGEv.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Threading.Tasks;
using SiGEv.Services;
using SiGEv.Models.ViewModels;
using SiGEv.Models;

namespace SiGEv.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ReportsService _reportsService;

        private readonly EventsService _eventsService;

        public ReportsController(ReportsService reportsService, EventsService eventsService)
        {
            _reportsService = reportsService;
            _eventsService = eventsService;
        }

        public async Task<IActionResult> Index(DateTime? date)
        {
			List<Event> events = _eventsService.GetAllEvents();
            List<Bill> bills = await _reportsService.GetProfitByDateAsync(date);

            ReportsFormViewModel viewModel = new ReportsFormViewModel { ListBills = bills, ListEvents = events };

            return View(viewModel);
        }

        public async Task<IActionResult> EventReport()
        {
            return View();
        }
    }
}
