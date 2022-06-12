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
            IdentityRole<int> adminRole = new IdentityRole<int>("Admin");
            IdentityRole<int> employeeRole = new IdentityRole<int>("Employee");
            IdentityRole<int> customerRole = new IdentityRole<int>("Customer");
            IdentityResult result;

            if (!_context.Roles.Any())
            {
                result = _roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
                result = _roleManager.CreateAsync(employeeRole).GetAwaiter().GetResult();
                result = _roleManager.CreateAsync(customerRole).GetAwaiter().GetResult();
            }

            User baseAdminUser = _context.Users.FirstOrDefault(x => x.Type == UserType.Admin);

            if (baseAdminUser == null)
            {
                baseAdminUser = new User
                {
                    Name = "admin",
                    UserName = "admin",
                    Email = "base@admin.com",
                    Type = UserType.Admin,
                };

                result = _userManager.CreateAsync(baseAdminUser, "!admin123").GetAwaiter().GetResult();
            }

            result = _userManager.AddToRoleAsync(baseAdminUser, adminRole.Name).GetAwaiter().GetResult();

            User baseEmployeeUser = _context.Users.FirstOrDefault(x => x.Type == UserType.Employee);

            if (baseEmployeeUser == null)
            {
                baseEmployeeUser = new User
                {
                    Name = "employee",
                    UserName = "employee",
                    Email = "base@employee.com",
                    Type = UserType.Employee
                };

                result = _userManager.CreateAsync(baseEmployeeUser, "!emp123").GetAwaiter().GetResult();
            }

            result = _userManager.AddToRoleAsync(baseEmployeeUser, employeeRole.Name).GetAwaiter().GetResult();
        }
    }
}
