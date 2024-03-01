using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.DataAccess;
using OrderManagementAPI.Interface;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private readonly OrderManagementSystemDbContext _context;

		public OrderRepository(OrderManagementSystemDbContext context)
		{
			_context = context;
		}

		public List<OrderModel> GetAllOrders()
		{
			var data = _context.Orders.ToList();

			var allOrders = data.Select(o => new OrderModel
			{
				OrderId = o.OrderId,
				CustomerId = o.CustomerId,
				OrderDate = o.OrderDate,
				TotalAmount = o.TotalAmount,
				Status = o.Status
			}).ToList();

			return allOrders;
		}

		public OrderModel GetOrderById(int id)
		{
			var data = _context.Orders.FirstOrDefault(o => o.OrderId == id);
			if (data != null)
			{
				var order = new OrderModel
				{
					OrderId = data.OrderId,
					CustomerId = data.CustomerId,
					OrderDate = data.OrderDate,
					TotalAmount = data.TotalAmount,
					Status = data.Status
				};
				return order;
			}
			else
			{
				return new OrderModel { };
			}
		}

		public bool AddNewOrder(OrderModel order)
		{
			var orderData = new Order
			{
				OrderId = order.OrderId,
				CustomerId = order.CustomerId,
				OrderDate = order.OrderDate,
				TotalAmount = order.TotalAmount,
				Status = order.Status
			};

			_context.Orders.Add(orderData);
			int result = _context.SaveChanges();
			if (result == 0)
			{
				return false;
			}
			return true;
		}

		public bool DeleteOrderById(int id)
		{
			Order order = _context.Orders.Find(id);
			if (order != null)
			{
				_context.Orders.Remove(order);
				int result = _context.SaveChanges();
				if (result > 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool UpdateOrderById(OrderModel order)
		{
			var data = _context.Orders.Find(Convert.ToInt32(order.OrderId));
			if (data != null)
			{
				_context.Entry(data).State = EntityState.Detached;
				Order orderData = new Order
				{
					OrderId = order.OrderId,
					CustomerId = order.CustomerId,
					OrderDate = order.OrderDate,
					TotalAmount = order.TotalAmount,
					Status = order.Status
				};

				_context.Orders.Update(orderData);
				int result = _context.SaveChanges();
				if (result > 0)
				{
					return true;
				}
			}
			return false;
		}
	}

}
