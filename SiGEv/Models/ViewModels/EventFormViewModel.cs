using System.Collections.Generic;

namespace SiGEv.Models.ViewModels
{
	public class EventFormViewModel
	{
		public Event Event { get; set; }
		public Venue Venue { get; set; }
		public ICollection<Section> Sections { get; set; }
		public Bill Bill { get; set; }
        public int SectionId { get; set; }
        public int TicketsQuantity { get; set; }
		public string Protocol { get; set; }
	}
}
