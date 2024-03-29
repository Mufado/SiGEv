using SiGEv.Data;
using SiGEv.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiGEv.Services
{
	public class VenuesService
	{
		private readonly SiGEvContext _context;

		public VenuesService(SiGEvContext context)
		{
			_context = context;
		}

		public List<Venue> FindAll()
		{
			return _context.Venues.OrderBy(x=> x.Adress).ToList();

		}

		public Venue FindById(int id)
		{
			return _context.Venues.FirstOrDefault(ev => ev.Id == id);
		}

		public void Insert(Venue obj)
		{
			_context.Add(obj);
			_context.SaveChanges();
		}
	}
}
