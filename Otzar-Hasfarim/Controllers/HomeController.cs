using Microsoft.AspNetCore.Mvc;
using Otzar_Hasfarim.Data;
using Otzar_Hasfarim.Models;
using System.Diagnostics;

namespace Otzar_Hasfarim.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;
		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
