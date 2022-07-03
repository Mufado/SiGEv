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
	}
}
