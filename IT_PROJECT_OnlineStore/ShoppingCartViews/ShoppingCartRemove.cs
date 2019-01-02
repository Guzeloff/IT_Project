using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_PROJECT_OnlineStore.ViewModel
{
	public class ShoppingCartRemove
	{
		public String message { get; set; }
		public decimal CartTotal { get; set; }
		public int CartCount { get; set; }
		public int ItemCount { get; set; }
		public int DeleteId { get; set; }

	}
}