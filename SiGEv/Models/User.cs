using System;
using static SiGEv.Models.Enums.Enums;

namespace SiGEv.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string NationalIdentity { get; set; }
        public PersonGender Sex { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public UserType Type { get; set; }
    }
}
