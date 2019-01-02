using IT_PROJECT_OnlineStore.Models;
using IT_PROJECT_OnlineStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_PROJECT_OnlineStore.Controllers
{
    public class ShoppingCartController : Controller
    {
		ApplicationDbContext dbStore = new ApplicationDbContext();

		// GET: ShoppingCart
		public ActionResult Index()
        {
			var cart = ShoppingCart.GetCart(this.HttpContext);
			var viewModel = new ShoppingCartView
			{
				CartItems = cart.GetCartItems(),
				CardTotal = cart.GetTotal()
			};

             return View(viewModel);
        }
		public ActionResult AddToCart(int id)
		{
			var addedItem = dbStore.Items.Single(item => item.ItemId == id);

			var cart = ShoppingCart.GetCart(this.HttpContext);
			cart.AddToCart(addedItem);

			return RedirectToAction("Index");
		}
		[HttpPost]
		public ActionResult RemoveFromCart(int id)
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);

			string itemName = dbStore.Carts.Single(item => item.RecordID == id).Item.Title;

			int itemcount = cart.RemoveFromCart(id);

			var result = new ShoppingCartRemove
			{
				message = Server.HtmlEncode(itemName) + " е избришано од вашата шопинг кошничка",
				CartTotal = cart.GetTotal(),
				CartCount = cart.GetCount(),
				ItemCount = itemcount,
				DeleteId = id
			};

			return Json(result);

		}
		[ChildActionOnly]
		public ActionResult CartSummary()
		{
			var cart = ShoppingCart.GetCart(this.HttpContext);
			ViewData["CartCount"] = cart.GetCount();
			return PartialView("CartSummary");
		}
	}
}