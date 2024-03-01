using OrderManagementAPI.DataAccess;

namespace OrderManagementAPI.Interface
{
	public interface IOrderRepository
	{
		List<OrderModel> GetAllOrders();
		OrderModel GetOrderById(int id);
		bool AddNewOrder(OrderModel order);
		bool DeleteOrderById(int id);
		bool UpdateOrderById(OrderModel order);
	}
}
