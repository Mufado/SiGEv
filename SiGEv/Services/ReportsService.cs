using SiGEv.Data;
using SiGEv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiGEv.Models.ViewModels;

namespace SiGEv.Services
{
    public class ReportsService
    {
        private readonly SiGEvContext _context;

        public ReportsService(SiGEvContext context)
        {
            _context = context;
        }

        public IQueryable<ReportsFormViewModel> GetProfitByDateAsync(DateTime? dateSearch)
        {
            var billsList = _context.Bills;
            var eventsList = _context.Events;
            var ticketsList = _context.Tickets;
            var sectionsList = _context.Sections;

            var result = from b in billsList
                         join t in ticketsList on b.Id equals t.BillId into table1
                         from t in table1.DefaultIfEmpty()
                         join s in sectionsList on t.SectionId equals s.Id into table2
                         from s in table2.DefaultIfEmpty()
                         join e in eventsList on s.EventId equals e.Id into table3
                         from e in table3.DefaultIfEmpty()
                         select new ReportsFormViewModel { Bill = b, Event = e, Ticket = t, Section = s };

            return result;
        }
    }
}