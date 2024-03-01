using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.DataAccess;
using OrderManagementAPI.Interface;

namespace OrderManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpGet]
		public List<ProductModel> GetAllProductData()
		{
			return _productRepository.GetAllProducts();
		}

		[HttpGet("{id}")]
		public ProductModel GetProductDataById(int id)
		{
			return _productRepository.GetProductById(id);
		}

		[HttpPost]
		public object AddNewProduct(ProductModel product)
		{
			try
			{
				bool result = _productRepository.AddNewProduct(product);
				if (result)
				{
					return new { error = false, status = 200, message = "Product Inserted Successfully!!" };
				}
				else
				{
					return new { error = false, status = 200, message = "Product Not Inserted" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}

		[HttpDelete("{id}")]
		public object DeleteProductById(int id)
		{
			try
			{
				bool result = _productRepository.DeleteProductById(id);
				if (result)
				{
					return new { error = false, status = 200, message = "Product Deleted Successfully!!" };
				}
				else
				{
					return new { error = false, status = 404, message = "Product Not Found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}

		[HttpPut]
		public object UpdateProductById(ProductModel product)
		{
			try
			{
				bool result = _productRepository.UpdateProductById(product);
				if (result)
				{
					return new { error = false, status = 200, message = "Product Updated Successfully!!" };
				}
				else
				{
					return new { error = false, status = 404, message = "Product Not Found" };
				}
			}
			catch (Exception ex)
			{
				return new { error = true, status = 500, message = ex.Message };
			}
		}
	}

}
