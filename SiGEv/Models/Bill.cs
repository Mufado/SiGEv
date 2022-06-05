using System;
using System.Collections.Generic;
using static SiGEv.Models.Enums.Enums;

namespace SiGEv.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int Protocol { get; set; }
        public BillType Type { get; set; }
        public int UserId { get; set; }
        public string ClientDocument { get; set; }
        public string ClientName { get; set; }
        public List<Ticket> SelledTickets { get; set; }
        public double Value { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
