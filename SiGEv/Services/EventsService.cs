using SiGEv.Data;
using SiGEv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _context.Events.ToList();
        }
    }
}
