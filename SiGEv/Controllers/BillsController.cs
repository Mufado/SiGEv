using Microsoft.AspNetCore.Mvc;

namespace SiGEv.Controllers
{
	public class BillsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
