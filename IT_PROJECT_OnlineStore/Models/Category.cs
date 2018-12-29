using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_PROJECT_OnlineStore.Models
{
	public class Category
	{
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual List<Item> Items { get; set; }	
	}
}