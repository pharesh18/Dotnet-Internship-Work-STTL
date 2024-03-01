using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.DataAccess
{
	public class ProductModel
	{
		public int ProductId { get; set; }
		[Required]
		public string Name { get; set; } = null!;
		[Required]
		public string? Description { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int StockQuantity { get; set; }

		//public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
