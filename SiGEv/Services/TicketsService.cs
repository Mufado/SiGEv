using Microsoft.EntityFrameworkCore;
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
			return _context.Tickets
				.Include(ticket=> ticket.Event)
				.Include(ticket=>ticket.Venue)
				.Include(ticket=>ticket.Section).ToList();
		}

		public void Insert(Ticket ticket)
		{
			_context.Add(ticket);
			_context.SaveChanges();
		}
		public void InsertAll(List<Ticket> tickets)
		{
			_context.AddRange(tickets);
			_context.SaveChanges();
		}

		public int CountTicketsBySectionId(int id)
		{
			return _context.Tickets.Where(x => x.SectionId == id).ToList().Count();
		}
	}
}
