using OrderManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.DataAccess
{
	public class OrderItemModel
	{
		public int OrderItemId { get; set; }
		[Required]
		public int OrderId { get; set; }
		[Required]
		public int ProductId { get; set; }
		[Required]
		public int Quantity { get; set; }
		[Required]
		public decimal UnitPrice { get; set; }

		//public virtual Order Order { get; set; } = null!;

		//public virtual Product Product { get; set; } = null!;
	}
}
