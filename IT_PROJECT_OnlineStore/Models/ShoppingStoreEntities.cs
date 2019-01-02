using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT_PROJECT_OnlineStore.Models
{
	public class ShoppingStoreEntities : DbContext
	{

		public ShoppingStoreEntities() : base("ShoppingStoreEntities") { }


	}
}