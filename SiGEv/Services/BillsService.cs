using SiGEv.Data;
using SiGEv.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiGEv.Services
{
	public class BillsService
	{
		private readonly SiGEvContext _context;

		public BillsService(SiGEvContext context)
		{
			_context = context;
		}

		public List<Bill> FindAll()
		{
			return _context.Bills.ToList();
		}

		public Bill FindById(int id)
		{
			return _context.Bills.FirstOrDefault(bill => bill.Id == id);
		}

		public List<Bill> FindByUserId(int id)
		{
			return _context.Bills.Where(bill => bill.UserId == id).ToList();
		}

		public void Insert(Bill obj)
		{
			_context.Add(obj);
			_context.SaveChanges();
		}
	}
}
