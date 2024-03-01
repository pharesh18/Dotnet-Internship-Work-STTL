using OrderManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.DataAccess
{
	public class CustomerModel
	{
		public int CustomerId { get; set; }
		[Required]
		public string Name { get; set; } = null!;
		[Required]
		public string Email { get; set; } = null!;
		[Required]
		public string Address { get; set; } = null!;

		//public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
	}
}
