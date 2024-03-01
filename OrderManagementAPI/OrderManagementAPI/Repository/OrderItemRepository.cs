using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.DataAccess;
using OrderManagementAPI.Interface;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Repository
{
	public class OrderItemRepository : IOrderItemRepository
	{
		private readonly OrderManagementSystemDbContext _context;

		public OrderItemRepository(OrderManagementSystemDbContext context)
		{
			_context = context;
		}

		public List<OrderItemModel> GetAllOrderItems()
		{
			var data = _context.OrderItems.ToList();

			var allOrderItems = data.Select(oi => new OrderItemModel
			{
				OrderItemId = oi.OrderItemId,
				OrderId = oi.OrderId,
				ProductId = oi.ProductId,
				Quantity = oi.Quantity,
				UnitPrice = oi.UnitPrice
			}).ToList();

			return allOrderItems;
		}

		public OrderItemModel GetOrderItemById(int id)
		{
			var data = _context.OrderItems.FirstOrDefault(oi => oi.OrderItemId == id);
			if (data != null)
			{
				var orderItem = new OrderItemModel
				{
					OrderItemId = data.OrderItemId,
					OrderId = data.OrderId,
					ProductId = data.ProductId,
					Quantity = data.Quantity,
					UnitPrice = data.UnitPrice
				};
				return orderItem;
			}
			else
			{
				return new OrderItemModel { };
			}
		}

		public bool AddNewOrderItem(OrderItemModel orderItem)
		{
			var orderItemData = new OrderItem
			{
				OrderItemId = orderItem.OrderItemId,
				OrderId = orderItem.OrderId,
				ProductId = orderItem.ProductId,
				Quantity = orderItem.Quantity,
				UnitPrice = orderItem.UnitPrice
			};

			_context.OrderItems.Add(orderItemData);
			int result = _context.SaveChanges();
			if (result == 0)
			{
				return false;
			}
			return true;
		}

		public bool DeleteOrderItemById(int id)
		{
			OrderItem orderItem = _context.OrderItems.Find(id);
			if (orderItem != null)
			{
				_context.OrderItems.Remove(orderItem);
				int result = _context.SaveChanges();
				if (result > 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool UpdateOrderItemById(OrderItemModel orderItem)
		{
			var data = _context.OrderItems.Find(Convert.ToInt32(orderItem.OrderItemId));
			if (data != null)
			{
				_context.Entry(data).State = EntityState.Detached;
				OrderItem orderItemData = new OrderItem
				{
					OrderItemId = orderItem.OrderItemId,
					OrderId = orderItem.OrderId,
					ProductId = orderItem.ProductId,
					Quantity = orderItem.Quantity,
					UnitPrice = orderItem.UnitPrice
				};

				_context.OrderItems.Update(orderItemData);
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
