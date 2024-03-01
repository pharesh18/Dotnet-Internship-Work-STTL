using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.DataAccess;
using OrderManagementAPI.Interface;
using OrderManagementAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderManagementAPI.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly OrderManagementSystemDbContext _context;

		public CustomerRepository(OrderManagementSystemDbContext context)
		{
			_context = context;
		}

		public List<CustomerModel> GetAllCustomers()
		{
			var data = _context.Customers.ToList();

			var allCustomers = data.Select(c => new CustomerModel
			{
				CustomerId = c.CustomerId,
				Name = c.Name,
				Email = c.Email,
				Address = c.Address,
			}).ToList();

			return allCustomers;
		}

		public CustomerModel GetCustomerById(int id)
		{
			var data = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
			if (data != null)
			{
				var customer = new CustomerModel
				{
					CustomerId = data.CustomerId,
					Name = data.Name,
					Email = data.Email,
					Address = data.Address,
				};
				return customer;
			}
			else
			{
				return new CustomerModel { };
			}
		}

		public bool AddNewCustomer(CustomerModel customer)
		{
			var customerData = new Customer
			{
				CustomerId = customer.CustomerId,
				Name = customer.Name,
				Email = customer.Email,
				Address = customer.Address,
			};

			_context.Customers.Add(customerData);
			int result = _context.SaveChanges();
			if (result == 0)
			{
				return false;
			}
			return true;
		}

		public bool DeleteCustomerById(int id)
		{
			Customer customer = _context.Customers.Find(id);
			if (customer != null)
			{
				_context.Customers.Remove(customer);
				int result = _context.SaveChanges();
				if (result > 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool UpdateCustomerById(CustomerModel customer)
		{
			var data = _context.Customers.Find(Convert.ToInt32(customer.CustomerId));
			if (data != null)
			{
				_context.Entry(data).State = EntityState.Detached;
				Customer customerData = new Customer
				{
					CustomerId = customer.CustomerId,
					Name = customer.Name,
					Email = customer.Email,
					Address = customer.Address
				};

				_context.Customers.Update(customerData);
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
