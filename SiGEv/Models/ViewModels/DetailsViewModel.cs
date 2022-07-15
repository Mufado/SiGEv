using System;
using System.Collections.Generic;

namespace SiGEv.Models.ViewModels
{
	public class DetailsViewModel
	{
		public Bill Bill { get; set; }

		public ICollection<Ticket> Tickets { get; set; }
		public Event? Event { get; set; }
	}
}
