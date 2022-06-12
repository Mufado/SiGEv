using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using static SiGEv.Models.Enums.Enums;

namespace SiGEv.Models
{
    public class User : IdentityUser<int>
    {
        [PersonalData]
        public string Name { get; set; }
        
        [PersonalData]
        public string TaxNumber { get; set; }

        [PersonalData]
        public string NationalIdentity { get; set; }
        public PersonGender Sex { get; set; }
        
        [PersonalData]
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
        
        public DateTime BirthDate { get; set; }
        public UserType Type { get; set; }

        public User()
        {
        }

        public User(string name, string taxNumber,
            string nationalIdentity, PersonGender sex, string email,
            string phoneNumber, DateTime birthDate)
        {
            Name = name;
            TaxNumber = taxNumber;
            NationalIdentity = nationalIdentity;
            Sex = sex;
            Email = email;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
        }
    }
}
