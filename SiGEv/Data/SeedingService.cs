using Microsoft.AspNetCore.Identity;
using SiGEv.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using static SiGEv.Models.Enums.Enums;

namespace SiGEv.Data
{
    public class SeedingService
    {
        private readonly SiGEvContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public SeedingService(SiGEvContext context, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Seed()
        {
            SeedIdentity();
            SeedDatabase();
        }

        private void SeedIdentity()
        {
            IdentityResult result;

            if (!_context.Roles.Any())
            {
                IdentityRole<int> adminRole = new IdentityRole<int>("Admin");
                IdentityRole<int> employeeRole = new IdentityRole<int>("Employee");
                IdentityRole<int> customerRole = new IdentityRole<int>("Customer");

                result = _roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
                result = _roleManager.CreateAsync(employeeRole).GetAwaiter().GetResult();
                result = _roleManager.CreateAsync(customerRole).GetAwaiter().GetResult();
            }

            User baseAdminUser = _context.Users.FirstOrDefault(x => x.Type == UserType.Admin);

            if (baseAdminUser == null)
            {
                baseAdminUser = new User{ Name = "admin", UserName = "admin", Email = "base@admin.com", Type = UserType.Admin, };

                result = _userManager.CreateAsync(baseAdminUser, "!admin123").GetAwaiter().GetResult();
            }

            result = _userManager.AddToRoleAsync(baseAdminUser, "Admin").GetAwaiter().GetResult();

            User baseEmployeeUser = _context.Users.FirstOrDefault(x => x.Type == UserType.Employee);

            if (baseEmployeeUser == null)
            {
                baseEmployeeUser = new User{ Name = "employee", UserName = "employee", Email = "base@employee.com", Type = UserType.Employee };

                result = _userManager.CreateAsync(baseEmployeeUser, "!emp123").GetAwaiter().GetResult();
            }

            result = _userManager.AddToRoleAsync(baseEmployeeUser, "Employee").GetAwaiter().GetResult();
        }

        private void SeedDatabase()
        {
            Venue venue1 = new Venue { Id = 1, Adress = "Rua 1, 01, Centro", Description = "Local1", TotalSeats = 50 };
            Venue venue2 = new Venue { Id = 2, Adress = "Rua 2, 02, Centro", Description = "Local2", TotalSeats = 60 };
            Venue venue3 = new Venue { Id = 3, Adress = "Rua 3, 03, Centro", Description = "Local3", TotalSeats = 70 };

            Event event1 = new Event { Id = 1, Date = new DateTime(2022, 08, 08), Title = "Evento1", Type = EventType.Movie, Venue = venue1, VenueId = 1 };
            Event event2 = new Event { Id = 2, Date = new DateTime(2022, 12, 25), Title = "Evento2", Type = EventType.Show, Venue = venue2, VenueId = 2 };
            Event event3 = new Event { Id = 3, Date = new DateTime(2023, 01, 01), Title = "Evento3", Type = EventType.Theater, Venue = venue3, VenueId = 3 };

            Section section1 = new Section { Id = 1, Event = event1, EventId = 1, CommonPrice = 10.00, StartTime = event1.Date, EndTime = event1.Date.AddHours(2) };
            Section section2 = new Section { Id = 2, Event = event2, EventId = 2, CommonPrice = 20.00, StartTime = event2.Date, EndTime = event2.Date.AddHours(3) };
            Section section3 = new Section { Id = 3, Event = event3, EventId = 3, CommonPrice = 30.00, StartTime = event3.Date, EndTime = event3.Date.AddHours(4) };

			Bill bill1 = new Bill { Id = 1, UserId = 1, Value = 2150.59, PaymentDate = DateTime.Now };
			Bill bill2 = new Bill { Id = 2, UserId = 2, Value = 470.29, PaymentDate = DateTime.Now };
			Bill bill3 = new Bill { Id = 3, UserId = 1, Value = 150.89, PaymentDate = DateTime.Now };

			Ticket ticket1 = new Ticket { Id = 1, BillId = 1, SeatNumber = 45, Type = TicketType.Common, SectionId = 1, VenueId = 1, Price = 75.0 };
			Ticket ticket2 = new Ticket { Id = 2, BillId = 2, SeatNumber = 85, Type = TicketType.VIP, SectionId = 2, VenueId = 2, Price = 105.0 };
			Ticket ticket3 = new Ticket { Id = 3, BillId = 3, SeatNumber = 50, Type = TicketType.HalfCost, SectionId = 3, VenueId = 3, Price = 25.0 };

			event1.Sections.Add(section1);
            event2.Sections.Add(section2);
            event3.Sections.Add(section3);

            if (!_context.Venues.Any())
            {
                _context.Venues.AddRange(venue1, venue2, venue3);
            }

            if (!_context.Events.Any())
            {
                _context.Events.AddRange(event1, event2, event3);
            }

            if (!_context.Sections.Any())
            {
                _context.Sections.AddRange(section1, section2, section3);
            }

            _context.SaveChanges();
        }
    }
}
