using Microsoft.AspNetCore.Mvc;
using SiGEv.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Threading.Tasks;
using SiGEv.Services;
using SiGEv.Models.ViewModels;

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
			var events = _eventsService.GetAllEvents();
            var bills = await _reportsService.GetProfitByDatesAsync(date);
            var viewModel = new ReportsFormViewModel { ListBills = bills, ListEvents =events };

            return View(viewModel);
        }
    }
}
