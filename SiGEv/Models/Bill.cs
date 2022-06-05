using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static SiGEv.Models.Enums.Enums;

namespace SiGEv.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int Protocol { get; set; }
        public BillType Type { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public string ClientDocument { get; set; }
        public string ClientName { get; set; }
        public ICollection<Ticket> SelledTickets { get; set; } = new List<Ticket>();
        public double Value { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }

        public Bill()
        {
        }

        public Bill(int id, int protocol, BillType type, int userId, string clientDocument,
            string clientName,double value, PaymentType paymentType, DateTime paymentDate)
        {
            Id = id;
            Protocol = protocol;
            Type = type;
            UserId = userId;
            ClientDocument = clientDocument;
            ClientName = clientName;
            Value = value;
            PaymentType = paymentType;
            PaymentDate = paymentDate;
        }
    }
}
