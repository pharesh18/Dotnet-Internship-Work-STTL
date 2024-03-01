using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.DataAccess;
using OrderManagementAPI.Interface;

namespace OrderManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderRepository _orderRepository;

		public OrderController(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		[HttpGet]
		public List<OrderModel> GetAllOrderData()
		{
			return _orderRepository.GetAllOrders();
		}

		[HttpGet("{id}")]
		public OrderModel GetOrderDataById(int id)
		{
			return _orderRepository.GetOrderById(id);
		}

		[HttpPost]
		public object AddNewOrder(OrderModel order)
		{
			try
			{
				bool result = _orderRepository.AddNewOrder(order);
				if (result)
				{
					return new { error = false, status = 200, message = "Order Inserted Successfully!!" };
				}
				else
				{
					return new { error = false, status = 200, message = "Order Not Inserted" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}

		[HttpDelete("{id}")]
		public object DeleteOrderById(int id)
		{
			try
			{
				bool result = _orderRepository.DeleteOrderById(id);
				if (result)
				{
					return new { error = false, status = 200, message = "Order Deleted Successfully!!" };
				}
				else
				{
					return new { error = false, status = 404, message = "Order Not Found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}

		[HttpPut]
		public object UpdateOrderById(OrderModel order)
		{
			try
			{
				bool result = _orderRepository.UpdateOrderById(order);
				if (result)
				{
					return new { error = false, status = 200, message = "Order Updated Successfully!!" };
				}
				else
				{
					return new { error = false, status = 404, message = "Order Not Found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}
	}
}
