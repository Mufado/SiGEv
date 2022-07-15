using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SiGEv.Models.Enums.Enums;

namespace SiGEv.Models
{
    public class Bill
    {
        public int Id { get; set; }

		[Display(Name = "Protocolo")]
		public string Protocol { get; set; }

		[Display(Name = "Número de Parcelas")]
		public BillType Type { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }

		[Display(Name = "Usuário")]
		public User User { get; set; }

		[Display(Name = "Número do Documento")]
		public string ClientDocument { get; set; }

		[Display(Name = "Nome do Cliente")]
		public string ClientName { get; set; }

		[Display(Name = "Tipo do Documento")]
		public DocumentType DocumentType { get; set; }

		public ICollection<Ticket> SelledTickets { get; set; } = new List<Ticket>();

		[Display(Name = "Valor Total")]
		public double Value { get; set; }

		[Display (Name="Tipo de Pagamento")]
        public PaymentType PaymentType { get; set; }

		[Display(Name = "Data de Pagamento")]
		public DateTime PaymentDate { get; set; }

        public Bill()
        {
        }

        public Bill(int id, string protocol, BillType type, int userId, User user, string clientDocument,
            DocumentType documentType, string clientName,double value, PaymentType paymentType, DateTime paymentDate)
        {
            Id = id;
            Protocol = protocol;
            Type = type;
            UserId = userId;
            User = user;
            ClientDocument = clientDocument;
			DocumentType = documentType;
			ClientName = clientName;
            Value = value;
            PaymentType = paymentType;
            PaymentDate = paymentDate;
        }
    }
}
