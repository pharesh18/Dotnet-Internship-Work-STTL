using OrderManagementAPI.DataAccess;

namespace OrderManagementAPI.Interface
{
	public interface IProductRepository
	{
		List<ProductModel> GetAllProducts();
		ProductModel GetProductById(int id);
		bool AddNewProduct(ProductModel product);
		bool DeleteProductById(int id);
		bool UpdateProductById(ProductModel product);
	}
}
