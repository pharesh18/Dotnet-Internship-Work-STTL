using OrderManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.DataAccess
{
	public class OrderModel
	{
		public int OrderId { get; set; }
		[Required]
		public int CustomerId { get; set; }
		[Required]
		public DateTime OrderDate { get; set; }
		[Required]
		public decimal TotalAmount { get; set; }
		[Required]
		public string Status { get; set; } = null!;
		//public virtual Customer Customer { get; set; } = null!;
		//public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
