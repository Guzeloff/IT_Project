using IT_PROJECT_OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_PROJECT_OnlineStore.Controllers
{
	public class HomeController : Controller
	{
		ApplicationDbContext dbstore = new ApplicationDbContext();

		/*private List<Item> TopSelling (int count) // gi zimamte od narackite najprodavaite itemi
		{
			return dbstore.Items.OrderByDescending(i => i.OrderDetails.Count()).Take(count).ToList();
		}
		*/
		public ActionResult Index() // gi listame naprodavanite 5 itemi od TopSeling funkcijata
		{
			
			return View();
		}
		
		/*
			public ActionResult Index()
		{
			var items = TopSelling(5);
			return View(items);
		}
*/
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}