﻿
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
            Card
        }
        public enum BillType
        {
            InCash = 0,
            Installment3X = 1,
            Installment6X = 2,
            Installment12X = 3
        }
    }
}
