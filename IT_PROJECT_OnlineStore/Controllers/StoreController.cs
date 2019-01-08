using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_PROJECT_OnlineStore.Models;

namespace IT_PROJECT_OnlineStore.Controllers
{
    public class StoreController : Controller
    {
		ApplicationDbContext dbStore = new ApplicationDbContext();
        // GET: Store
        public ActionResult Index()
        {
			var category = dbStore.Categories.ToList();
            return View(category);
        }

		[ChildActionOnly]
		public ActionResult CategoryMenu()
		{
			var category = dbStore.Categories.ToList();

			return PartialView(category);
		}

		public ActionResult Browse(string category) // listanje po kategorii
		{
			var categoryModel = dbStore.Categories.Include("Items").Single(c => c.Name == category);
			return View(categoryModel);
			}
		public ActionResult Details (int id)
		{
			var item = dbStore.Items.Find(id);
			return View(item);
		} 

		public PartialViewResult getProducerList()
		{
			var prodlist = dbStore.Producers.ToList();
			return PartialView("getProducerList", prodlist);
		}

		public ActionResult BrowseBrand(string prod)
		{
			 
			var prodModel = dbStore.Producers.Include("Items").Single(c => c.Name == prod);

				return View(prodModel);
		}
    }
}