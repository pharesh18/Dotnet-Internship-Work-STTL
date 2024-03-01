using OrderManagementAPI.DataAccess;

namespace OrderManagementAPI.Interface
{
	public interface ICustomerRepository
	{
		List<CustomerModel> GetAllCustomers();
		CustomerModel GetCustomerById(int id);
		bool AddNewCustomer(CustomerModel customer);
		bool DeleteCustomerById(int id);
		bool UpdateCustomerById(CustomerModel customer);
	}
}
