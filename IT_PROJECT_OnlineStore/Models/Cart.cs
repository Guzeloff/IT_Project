using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_PROJECT_OnlineStore.Models
{
	public class Cart
	{
		[Key]
		public int RecordID { get; set; }
		public string CartID { get; set; }
		public int ItemID { get; set; }
		public int count { get; set; }
		public System.DateTime DateCreated { get; set; }
		public virtual Item Item { get; set; }
	}
}