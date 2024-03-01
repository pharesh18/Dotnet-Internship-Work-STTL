using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.DataAccess;
using OrderManagementAPI.Interface;

namespace OrderManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerController(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		[HttpGet]
		public List<CustomerModel> GetAllCustomerData()
		{
			return _customerRepository.GetAllCustomers();
		}

		[HttpGet("{id}")]
		public CustomerModel GetCustomerDataById(int id)
		{
			return _customerRepository.GetCustomerById(id);
		}

		[HttpPost]
		public object AddNewCustomer(CustomerModel customer)
		{
			try
			{
				bool result = _customerRepository.AddNewCustomer(customer);
				if (result)
				{
					return new { error = false, status = 200, message = "Customer Inserted Successfully!!" };
				}
				else
				{
					return new { error = false, status = 200, message = "Customer Not Inserted" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}

		[HttpDelete]
		public object DeleteCustomerById(int id)
		{
			try
			{
				bool result = _customerRepository.DeleteCustomerById(id);
				if (result)
				{
					return new { error = false, status = 200, message = "Customer Deleted Successfully!!" };
				}
				else
				{
					return new { error = false, status = 404, message = "Customer Not Found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}

		[HttpPut]
		public object UpdateCustomerById(CustomerModel customer)
		{
			try
			{
				bool result = _customerRepository.UpdateCustomerById(customer);
				if (result)
				{
					return new { error = false, status = 200, message = "Customer Updated Successfully!!" };
				}
				else
				{
					return new { error = false, status = 404, message = "Customer Not Found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}
	}
}
