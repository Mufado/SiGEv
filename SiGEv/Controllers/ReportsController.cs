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
using Microsoft.AspNetCore.Authorization;

namespace SiGEv.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        private readonly ReportsService _reportsService;

        private readonly EventsService _eventsService;

        public ReportsController(ReportsService reportsService, EventsService eventsService)
        {
            _reportsService = reportsService;
            _eventsService = eventsService;
        }

        public IActionResult Index(DateTime? date)
        {
			var list = _reportsService.GetProfitByDateAsync(date);

            return View(list);
        }
    }
}
