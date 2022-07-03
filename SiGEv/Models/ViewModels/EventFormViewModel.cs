using System.Collections.Generic;

namespace SiGEv.Models.ViewModels
{
	public class EventFormViewModel
	{
		public Event Event { get; set; }
		public Venue Venue { get; set; }
		public ICollection<Section> Sections { get; set; }
	}
}
