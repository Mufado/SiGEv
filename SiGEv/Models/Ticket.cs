using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SiGEv.Models.Enums.Enums;

namespace SiGEv.Models
{
    public class Ticket
    {
        public int Id { get; set; }
		public int SeatNumber { get; set; }
		public TicketType Type { get; set; }
		[Display(Name = "Preço")]
		public double Price { get; set; }

        [ForeignKey("Bill")]
		[Display(Name = "Id do Recibo")]
		public int BillId { get; set; }
		
        public Bill Bill { get; set; }

        [ForeignKey("Section")]
		[Display(Name = "Id da Seção")]
		public int SectionId { get; set; }
        public Section Section { get; set; }

        [ForeignKey("Venue")]
        public int VenueId { get; set; }
		[Display(Name = "Endereço")]
		public Venue Venue { get; set; }

        public Ticket()
        {
        }

        public Ticket(int id, int seatNumber, TicketType type, double price, int billId,
            Bill bill, int sectionId, Section section, int venueId, Venue venue)
        {
            Id = id;
            SeatNumber = seatNumber;
            Type = type;
            Price = price;
            BillId = billId;
            Bill = bill;
            SectionId = sectionId;
            Section = section;
            VenueId = venueId;
            Venue = venue;
        }
    }
}
