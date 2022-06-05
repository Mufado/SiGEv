using System;
using System.Collections.Generic;
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
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public UserType Type { get; set; }

        public User()
        {
        }

        public User(int id, string name, string taxNumber,
            string nationalIdentity, PersonGender sex, string email,
            string phoneNumber, string login, string password, DateTime birthDate, UserType type)
        {
            Id = id;
            Name = name;
            TaxNumber = taxNumber;
            NationalIdentity = nationalIdentity;
            Sex = sex;
            Email = email;
            PhoneNumber = phoneNumber;
            Login = login;
            Password = password;
            BirthDate = birthDate;
            Type = type;
        }
    }
}
