using System;
using static SiGEv.Models.Enums.Enums;

namespace SiGEv.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int SeatNumber { get; set; }
        public TicketType Type { get; set; }
        public int SectionId { get; set; }
        public Venue Venue { get; set; }
        public double Price { get; set; }
    }
}
