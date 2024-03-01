using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.DataAccess;
using OrderManagementAPI.Interface;

namespace OrderManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderItemController : ControllerBase
	{
		private readonly IOrderItemRepository _orderItemRepository;

		public OrderItemController(IOrderItemRepository orderItemRepository)
		{
			_orderItemRepository = orderItemRepository;
		}

		[HttpGet]
		public List<OrderItemModel> GetAllOrderItemData()
		{
			return _orderItemRepository.GetAllOrderItems();
		}

		[HttpGet("{id}")]
		public OrderItemModel GetOrderItemDataById(int id)
		{
			return _orderItemRepository.GetOrderItemById(id);
		}

		[HttpPost]
		public object AddNewOrderItem(OrderItemModel orderItem)
		{
			try
			{
				bool result = _orderItemRepository.AddNewOrderItem(orderItem);
				if (result)
				{
					return new { error = false, status = 200, message = "OrderItem Inserted Successfully!!" };
				}
				else
				{
					return new { error = false, status = 200, message = "OrderItem Not Inserted" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}

		[HttpDelete("{id}")]
		public object DeleteOrderItemById(int id)
		{
			try
			{
				bool result = _orderItemRepository.DeleteOrderItemById(id);
				if (result)
				{
					return new { error = false, status = 200, message = "OrderItem Deleted Successfully!!" };
				}
				else
				{
					return new { error = false, status = 404, message = "OrderItem Not Found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}

		[HttpPut]
		public object UpdateOrderItemById(OrderItemModel orderItem)
		{
			try
			{
				bool result = _orderItemRepository.UpdateOrderItemById(orderItem);
				if (result)
				{
					return new { error = false, status = 200, message = "OrderItem Updated Successfully!!" };
				}
				else
				{
					return new { error = false, status = 404, message = "OrderItem Not Found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}
	}
}
