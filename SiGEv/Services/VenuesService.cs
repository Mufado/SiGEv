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

		public Venue GetVenueById(int id)
		{
			return _context.Venues.FirstOrDefault(x => x.Id == id);
		}
	}
}
