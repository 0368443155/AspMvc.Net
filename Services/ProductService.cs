using CS68_MVC01.Models;

namespace CS68_MVC01.Services
{
	public class ProductService : List<ProductModel>
	{
		public ProductService()
		{
			this.AddRange(new ProductModel[]
			{
				new ProductModel() {Id = 1, Name = "Iphone", Price = 1000 },
				new ProductModel() {Id = 2, Name = "Xiaomi", Price = 800 },
				new ProductModel() {Id = 3, Name = "Samsung", Price = 1200 },
				new ProductModel() {Id = 4, Name = "Huawei", Price = 500 }
			});
		}
	}
}
