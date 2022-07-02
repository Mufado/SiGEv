using Microsoft.AspNetCore.Mvc;
using SiGEv.Models;
using SiGEv.Services;
using System.Collections.Generic;

namespace SiGEv.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsService _eventServices;

        public EventsController(EventsService eventServices)
        {
            _eventServices = eventServices;
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
				return NotFound();
			}

			var obj = _eventServices.FindById(id.Value);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}
	}
}
