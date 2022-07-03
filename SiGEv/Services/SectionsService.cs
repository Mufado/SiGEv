using SiGEv.Data;
using SiGEv.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiGEv.Services
{
	public class SectionsService
	{
		private readonly SiGEvContext _context;

		public SectionsService(SiGEvContext context)
		{
			_context = context;
		}

		public List<Section> FindAll()
		{
			return _context.Sections.ToList();
		}

		public List<Section> FindAllEventsById(int eventId)
		{
			var x = _context.Sections.Where(x => x.Id == eventId);
			return x.ToList();
		}
	}
}
