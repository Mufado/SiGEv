using SiGEv.Data;
using SiGEv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SiGEv.Services
{
    public class EventsService
    {
        private readonly SiGEvContext _context;

        public EventsService(SiGEvContext context)
        {
            _context = context;
        }

        public List<Event> GetAllEvents()
        {
            return _context.Events.Include(ev => ev.Venue).ToList();
        }

		public Event FindById(int id)
		{
			return _context.Events.Include(obj=>obj.Venue).FirstOrDefault(ev=> ev.Id == id);
		}

		[Authorize(Policy = "Employee")]
		public void Insert(Event obj)
		{
			_context.Add(obj);
			_context.SaveChanges();
		}
    }
}
