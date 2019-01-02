using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IT_PROJECT_OnlineStore.Models;
namespace IT_PROJECT_OnlineStore.ViewModel
{
	public class ShoppingCartView
	{
		public List<Cart> CartItems { get; set; }
		public decimal CardTotal { get; set; }

	}
}