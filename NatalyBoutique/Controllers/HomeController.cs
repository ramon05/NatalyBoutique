using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NatalyBoutique.Models;
using NatalyBoutique.Repository;

namespace NatalyBoutique.Controllers
{
	public class HomeController : Controller
	{
		//private readonly ProcedureRepository _procedureRepository;
		private readonly ProcedureRepository _context;

		public HomeController(ProcedureRepository context)
		{
			_context = context;
		}

		public async Task<ActionResult> Index()
		{
			var result = await _context.GetAll();

			return View(result);
		}

		//public IActionResult Index()
		//{
		//	var result =  _context.OdtenerTodo();
		//	return View(result);
		//}

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
