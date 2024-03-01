using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.DataAccess;
using OrderManagementAPI.Interface;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly OrderManagementSystemDbContext _context;

		public ProductRepository(OrderManagementSystemDbContext context)
		{
			_context = context;
		}

		public List<ProductModel> GetAllProducts()
		{
			var data = _context.Products.ToList();

			var allProducts = data.Select(p => new ProductModel
			{
				ProductId = p.ProductId,
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
				StockQuantity = p.StockQuantity
			}).ToList();

			return allProducts;
		}

		public ProductModel GetProductById(int id)
		{
			var data = _context.Products.FirstOrDefault(p => p.ProductId == id);
			if (data != null)
			{
				var product = new ProductModel
				{
					ProductId = data.ProductId,
					Name = data.Name,
					Description = data.Description,
					Price = data.Price,
					StockQuantity = data.StockQuantity
				};
				return product;
			}
			else
			{
				return new ProductModel { };
			}
		}

		public bool AddNewProduct(ProductModel product)
		{
			var productData = new Product
			{
				ProductId = product.ProductId,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				StockQuantity = product.StockQuantity
			};

			_context.Products.Add(productData);
			int result = _context.SaveChanges();
			if (result == 0)
			{
				return false;
			}
			return true;
		}

		public bool DeleteProductById(int id)
		{
			Product product = _context.Products.Find(id);
			if (product != null)
			{
				_context.Products.Remove(product);
				int result = _context.SaveChanges();
				if (result > 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool UpdateProductById(ProductModel product)
		{
			var data = _context.Products.Find(Convert.ToInt32(product.ProductId));
			if (data != null)
			{
				_context.Entry(data).State = EntityState.Detached;
				Product productData = new Product
				{
					ProductId = product.ProductId,
					Name = product.Name,
					Description = product.Description,
					Price = product.Price,
					StockQuantity = product.StockQuantity
				};

				_context.Products.Update(productData);
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
