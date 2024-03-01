using OrderManagementAPI.DataAccess;

namespace OrderManagementAPI.Interface
{
	public interface IOrderItemRepository
	{
		List<OrderItemModel> GetAllOrderItems();
		OrderItemModel GetOrderItemById(int id);
		bool AddNewOrderItem(OrderItemModel orderItem);
		bool DeleteOrderItemById(int id);
		bool UpdateOrderItemById(OrderItemModel orderItem);
	}
}
