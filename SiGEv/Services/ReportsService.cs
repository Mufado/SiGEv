using SiGEv.Data;
using SiGEv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SiGEv.Services
{
    public class ReportsService
    {
        private readonly SiGEvContext _context;

        public ReportsService(SiGEvContext context)
        {
            _context = context;
        }

        public async Task<List<Bill>> GetProfitByDatesAsync(DateTime? dateSearch)
        {
            var result = from obj in _context.Bills select obj;

            if (dateSearch.HasValue)
            {
                result = result.Where(x => x.PaymentDate >= dateSearch.Value);
            }

            return await result
                .Include(x => x.SelledTickets)
                .OrderByDescending(x => x.PaymentDate)
                .ToListAsync();
        }
    }
}