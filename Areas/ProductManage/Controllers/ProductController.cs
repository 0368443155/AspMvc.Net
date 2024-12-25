using CS68_MVC01.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS68_MVC01.Areas.ProductManage.Controllers
{
	[Area("ProductManage")]
	public class ProductController : Controller
	{
		// GET: ProductController
		private readonly ProductService _productService;
		private readonly ILogger<ProductController> _logger;

		public ProductController(ProductService productService, ILogger<ProductController> logger)
		{
			_productService = productService;
			_logger = logger;
		}
		public IActionResult Index()
		{
			// /Areas/AreaName/Views/ControllerName/Action.cshtml
			var products = _productService.OrderBy(p => p.Name).ToList();
			return View(products);
		}

	}
}
