using Microsoft.AspNetCore.Mvc;

namespace SiGEv.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
