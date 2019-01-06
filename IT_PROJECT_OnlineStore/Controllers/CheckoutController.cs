using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_PROJECT_OnlineStore.Models;

namespace IT_PROJECT_OnlineStore.Controllers
{
	[Authorize]
    public class CheckoutController : Controller
    {
		ApplicationDbContext dbstore = new ApplicationDbContext();
		const string PromoCode = "50Popust";
		// get method
        public ActionResult AddressAndPayment()
        {

			
            return View();
        }

		// post method
		[HttpPost]
		public ActionResult AdressAndPayment(FormCollection values)
		{
			var order = new Order();
			TryUpdateModel(order); // koga go loadirame userto od bazata
								   // i ako ima izmeni od negova strana gi updetire

			try
			{
				if (string.Equals(values["Промокод"], PromoCode,
					StringComparison.OrdinalIgnoreCase) == false )
				{
					return View(order);
				}

				else
				{
					// gi zimame podatocite za narcaka od usero
					order.UserName = User.Identity.Name;
					order.OrderDate = DateTime.Now;
					dbstore.Orders.Add(order);
					dbstore.SaveChanges();

					var cart = ShoppingCart.GetCart(this.HttpContext); // ja procesirame naracakta
					cart.CreateOrder(order); // kreirame naracka
					return RedirectToAction("Complete","Checkout", new { id = order.OrderId });  // i redirektira na complete akcijata
																								 
					
				}
			}
			catch
			{
				dbstore.SaveChanges();
				return View(order);
			}
		}
		public ActionResult Complete (int id) // ke se pokaze posle od ka uspesno ke go zavrse porackata
			// ni pomaga da ga zemam ID-na narackata za sekoj user
		{
			bool isValid = dbstore.Orders.Any(
				o => o.OrderId == id && o.UserName == User.Identity.Name);
			if(isValid)
			{
				return View(id);
			}
			else
			{
				return View("Error");
			}
		}
    }
}