using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_PROJECT_OnlineStore.Models;

namespace IT_PROJECT_OnlineStore.Models
{
	public class ShoppingCart
	{
		ApplicationDbContext dbStore = new ApplicationDbContext();
		string ShoppingCartID { get; set; }
		public const string CartSessionKey = "CartID";
		public static ShoppingCart GetCart(HttpContextBase context)
		{
			var cart = new ShoppingCart();
			cart.ShoppingCartID = cart.GetCartID(context);
			return cart;
		}
		// pomosen method za da se simplificira shopping cart calls 
		public static ShoppingCart GetCart(Controller controller)
		{
			return GetCart(controller.HttpContext);

		}

		//dodavanje na item vo koscincata
		public void AddToCart(Item item)
		{
			var cartItem = dbStore.Carts.SingleOrDefault(
				c => c.CartID == ShoppingCartID && c.ItemID == item.ItemId);

			if (cartItem == null)
			{
				// ako e prazno se pravi nova kosnicka
				cartItem = new Cart
				{
					ItemID = item.ItemId,
					CartID = ShoppingCartID,
					count = 1,
					DateCreated = DateTime.Now
				};
				dbStore.Carts.Add(cartItem);
			}
			else
			// ako nee e null se dodava vo postoeckata
			{
				cartItem.count++;
			}
			dbStore.SaveChanges();
		}

		// brisenje na item od kosnickata
		public int RemoveFromCart(int id)
		{

			var cartItem = dbStore.Carts.Single(
				cart => cart.CartID == ShoppingCartID
				&& cart.RecordID == id);

			int itemCount = 0;

			if (cartItem != null)
			{
				if (cartItem.count > 1)
					// ako ima poveke od 1 item se brise samo toj od kosicnata
				{
					cartItem.count--;
					itemCount = cartItem.count;
				}
				else
				// ako ima tocno 1 se brise cela karticka
				{
					dbStore.Carts.Remove(cartItem);
				}

				dbStore.SaveChanges();
			}
			return itemCount;
		}

		public void EmptyCart()
			// se prazne kartickata na celo so eden klik
		{
			var cartItems = dbStore.Carts.Where(
				cart => cart.CartID == ShoppingCartID);

			foreach (var cartItem in cartItems)
			{
				dbStore.Carts.Remove(cartItem);
			}

			dbStore.SaveChanges();
		}
		public List<Cart> GetCartItems()
		{
			return dbStore.Carts.Where(
				cart => cart.CartID == ShoppingCartID).ToList();
		}
		public int GetCount()
		{
			

			int? count = (from cartItems in dbStore.Carts
						  where cartItems.CartID == ShoppingCartID
						  select (int?)cartItems.count).Sum();

			return count ?? 0;
		}

		public decimal GetTotal()
		{
			// se mnozi cena na item * count(kolicina naracana)
			// za da se dobie vkupna cena sekoj item
			// i na kraj suma na site za da se dobie vkupna suma na kartickata

			decimal? total = (from cartItems in dbStore.Carts
							  where cartItems.CartID == ShoppingCartID
							  select (int?)cartItems.count *
							  cartItems.Item.Price).Sum();

			return total ?? decimal.Zero;
		}

		// pravenje na narackata 
		public int CreateOrder(Order order)
		{
			decimal orderTotal = 0;

			var cartItems = GetCartItems();

			foreach (var item in cartItems)
			{
				var orderDetail = new OrderDetail
				{
					ItemId = item.ItemID,
					OrderId = order.OrderId,
					UnitPrice = item.Item.Price,
					Quantity = item.count
				};

				orderTotal += (item.count * item.Item.Price);

				dbStore.OrderDetails.Add(orderDetail);

			}

			order.Total = orderTotal;


			dbStore.SaveChanges();

			EmptyCart();

			return order.OrderId;
		}

		public string GetCartID(HttpContextBase context)
		{
			if (context.Session[CartSessionKey] == null)
			{
				if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
				{
					context.Session[CartSessionKey] =
						context.User.Identity.Name;
				}
				else
				{

					Guid tempCartId = Guid.NewGuid();

					context.Session[CartSessionKey] = tempCartId.ToString();
				}
			}
			return context.Session[CartSessionKey].ToString();
		}
		public void MigrateCart(string Email)
			// pri checkout
		{
			var shoppingCart = dbStore.Carts.Where(
				c => c.CartID == ShoppingCartID);

			foreach (Cart item in shoppingCart)
			{
				item.CartID = Email;
			}
			dbStore.SaveChanges();
		}
	}

}
