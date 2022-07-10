using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiGEv.Models.ViewModels
{
    public class ReportsFormViewModel
    {
        public Event Event { get; set; }

        public Bill Bill { get; set; }

        public Ticket Ticket { get; set; }

        public Section Section { get; set; }
    
        public List<Bill> ListBills { get; set; }
        public List<Event> ListEvents { get; set; }
        public List<Ticket> ListTickets { get; set; }
    }
}
