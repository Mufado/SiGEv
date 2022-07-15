using Microsoft.AspNetCore.Identity;
using SiGEv.Data;
using SiGEv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SiGEv.Services
{
    public class UsersService
    {
        private readonly SiGEvContext _context;

        private readonly UserManager<User> _userManager;

        public UsersService(SiGEvContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<User> GetUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _userManager.GetUserAsync(claimsPrincipal);
        }

        public User GetCurrentUser(ClaimsPrincipal claimsPrincipal)
        {
            string userId = _userManager.GetUserId(claimsPrincipal);

            return _context.Users.FirstOrDefault(x => x.Id == int.Parse(userId));
        }
    }
}
