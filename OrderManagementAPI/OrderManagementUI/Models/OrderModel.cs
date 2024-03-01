using System.ComponentModel.DataAnnotations;

namespace OrderManagementUI.Models
{
	public class OrderModel
	{
		public int OrderId { get; set; }
		[Required]
		public int CustomerId { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public decimal TotalAmount { get; set; } = 0;
		public string Status { get; set; } = "Pending";
		//public virtual Customer Customer { get; set; } = null!;
		//public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
