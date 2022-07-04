
using System.ComponentModel.DataAnnotations;

namespace SiGEv.Models.Enums
{
    public class Enums
    {
        public enum UserType
        {
            Customer = 0,
            Employee = 1,
            Admin = 2 
        }
        public enum PersonGender
        {
            [Display(Name = "Masculino")]
            Male = 0,
            [Display(Name = "Feminino")]
            Female = 1,
            [Display(Name = "Outro")]
            Another = 2
        }
        public enum EventType
        {
            Show = 0,
            Movie = 1,
            Theater = 2,
            Other = 3
        }
        public enum TicketType
        {
            Common = 0,
            HalfCost = 1,
            Preferred = 2,
            VIP = 3
        }
        public enum PaymentType
        {
			Money,
            CreditCard,
			DebitCard,
        }
        public enum BillType
        {
			[Display (Name = "A vista")]
            InCash,
			[Display(Name = "3x vezes")]
			Installment3X,
			[Display(Name = "6x vezes")]
			Installment6X,
			[Display(Name = "12x vezes")]
			Installment12X,
        }
    }
}
