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
		public ActionResult Browse(string category)
		{
			var categoryModel = dbStore.Categories.Include("Items").Single(c => c.Name == category);
			return View(categoryModel);
			}
		public ActionResult Details (int id)
		{
			var item = dbStore.Items.Find(id);
			return View(item);
		} 
    }
}