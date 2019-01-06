using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_PROJECT_OnlineStore.Models
{
	public class Item
	{
		public int ItemId { get; set; }
		public string Title { get; set; }
		public int Price { get; set; }
		public string ItemUrl { get; set; }
		public int CategoryId { get; set; }
		public int ProducerID { get; set; }

		public virtual List<OrderDetail> OrderDetails { get; set; }
		public virtual Producer Producer { get; set; }
		public virtual Category Category { get; set; }
	}
}