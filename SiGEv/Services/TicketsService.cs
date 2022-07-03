using SiGEv.Data;
using SiGEv.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiGEv.Services
{
	public class TicketsService
	{
		private readonly SiGEvContext _context;

		public TicketsService(SiGEvContext context)
		{
			_context = context;
		}

		public List<Ticket> FindAll()
		{
			return _context.Tickets.ToList();
		}
	}
}
