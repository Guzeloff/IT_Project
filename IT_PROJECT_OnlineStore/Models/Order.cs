using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_PROJECT_OnlineStore.Models
{
	public class Order
	{
		[ScaffoldColumn(false)]
		public int  OrderId { get; set; }
		[ScaffoldColumn(false)]
		public string  UserName { get; set; }

		[Required(ErrorMessage = "Полето е задолжително")]
		[DisplayName("Име")]
		[StringLength(160)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Полето е задолжително")]
		[DisplayName("Презиме")]
		[StringLength(160)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Полето е задолжително")]
		[StringLength(70)]
		[DisplayName("Адреса")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Полето е задолжително")]
		[StringLength(40)]
		[DisplayName("Град")]
		public string City { get; set; }

		[Required(ErrorMessage = "Полето е задолжително")]
		[DisplayName("Поштенски број")]
		[StringLength(10)]
		public string PostalCode { get; set; }

		[Required(ErrorMessage = "Полето е задолжително")]
		[StringLength(40)]
		[DisplayName("Држава")]
		public string Country { get; set; }

		[Required(ErrorMessage = "Полето е задолжително")]
		[StringLength(24)]
		[DisplayName("Телефон")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Полето е задолжително")]
		[DisplayName("Е-маил")]

		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
			ErrorMessage = "Погрешен формат.")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[ScaffoldColumn(false)]
		public decimal Total { get; set; }
		[ScaffoldColumn(false)]
		public System.DateTime OrderDate { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
	}
}