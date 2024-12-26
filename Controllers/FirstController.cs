using CS68_MVC01.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS68_MVC01.Controllers
{
	public class FirstController : Controller //kế thừa Controller để xác định đây là 1 controller
	{
		private readonly ILogger<FirstController> _logger;
		private readonly ProductService _productService;
		public FirstController(ILogger<FirstController> logger, ProductService productService)
		{
			_logger = logger;
			_productService = productService;
		}
		public string Index()
		{
			//1 Controller nhận đầy đủ thông tin của HttpContext gửi về
			//this.HttpContext;
			//this.Request;
			//this.Response;
			//this.RouteData;

			//Có cả các thuộc tinh giống như khi sử dụng pageModels
			//this.User;
			//this.ModelState;
			//this.ViewData;
			//this.ViewBag
			//this.Url;
			//this.TempData;


			_logger.Log(LogLevel.Warning, "Cảnh báo");
			_logger.LogWarning("Cảnh báo 2");
			_logger.LogError("Cảnh báo lỗi");
			_logger.LogCritical("Cảnh báo crash");
			_logger.LogInformation("Index Action");
			//SeriLog

			return "Phương thức Index của FirstController";
		}
		//có thể không trả về gì
		public void Nothing()
		{
			_logger.LogInformation("Nothing");
			Response.Headers.Add("Hi","Phuong thuc cua Nothing"); //khi tác động lên các thành phần của HttpContext thì phải dùng kí tự không dấu
		}
		//hoặc cũng có thể trả về bất kì thứ gì
		public object Anything() => new int[] {1,2,3};

		public IActionResult Content_Demo()
		{
			var content = "Asp Mvc 01";
			return Content(content, "text/plain");
		}

		public IActionResult File_Demo()
		{
			string filePath = Path.Combine(Program._contentRootPath, "Files", "1.png"); //nối đường dẫn từ thư mục gốc đến file
			var bytes = System.IO.File.ReadAllBytes(filePath);

			return File(bytes, "image/png");
		}

		public IActionResult Json_Demo()
		{
			return Json(
				new
				{
					productName = "Iphone 15",
					price = 1000
				}
			);
		}

		public IActionResult LocalRedirect_Demo()
		{
			var url = Url.Action("Privacy", "Home"); //gọi 1 Action nội bộ trong 1 Controller
			//ở đây gọi đến Action Privacy trong Controller Home
			//khi truy cập vào LocalRedirect_Demo thì sẽ chuyển hướng đến /Home/Privacy
			_logger.LogInformation("Chuyển hướng đến " + url);
			return LocalRedirect(url);
		}

		public IActionResult Redirect_Demo()
		{
			//khi muốn chuyển hướng đến 1 trang ngoài chứ không phải nội bộ thì ta gọi phương thức Redirect
			var url = "https://google.com";
			_logger.LogInformation("Chuyển hướng đến " + url);
			return Redirect(url);
		}

		//ViewResult -> View
		public IActionResult View_Demo(string userName)
		{
			if (string.IsNullOrEmpty(userName))
			{
				userName = "Khách";
			}
			//View() sử dụng Razor Engine, đọc file cshtml lưu trong ViewResult
			//Để truyền dữ liệu controller sang View(template, model) với template là đường dẫn tuyệt đối đến View, Model là dữ liệu sẽ truyền cho View
			//nếu không có đường dẫn tuyệt đối thì nó sẽ gọi đến các đường dẫn:
				//Views/<Tên Controller>/<Tên view>
				//Pages/Shared/<Tên View> hoặc View/Shared/<Tên view>
			//return View("/MyViews/ViewDemo.cshtml", userName);
			//return View("ViewDemo2.cshtml", userName);
			//return View((object)userName); //gọi đến file View trùng tên với tên phương thức (View_Demo) với đường dẫn tương tự ở trường hợp 2
			//vì đã gọi trực tiếp đến view nên sẽ không truyền vào Path, nhưng chương trình vẫn xem tham số đầu tiên là Path, nên ta convert sang object để ctr hiểu là model
		
			//cấu hình mặc định sẽ tìm kiếm view theo /Views/Controller/Action.cshtml, nếu không thấy thì sẽ tìm theo Path đã thiết lập

			return View("ViewDemo3", userName);
		}

		[TempData]
		public string StatusMessage {  get; set; }
		[AcceptVerbs("POST", "GET")]
		public IActionResult ViewProduct(int? id)
		{
			var product = _productService.Where(p => p.Id == id).FirstOrDefault();
			if (product == null)
			{
				//TempData["StatusMessage"] = $"Không tìm thấy sản phẩm có ID là {id}";
				StatusMessage = $"Không tìm thấy sản phẩm có ID là {id}"; //khai báo Property với Attribute là TempData sau đó truyền dữ liệu cũng tương dương với việc sử dụng Tempdata và thiết lập theo Key-Value
				return Redirect(Url.Action("Index", "Home"));
				//return Content($"Không tìm thấy sản phẩm có ID là {id}");
			}
			//Views/First/ViewProduct.cshtml
			//hoặc trong MyViews
			//return View(product);

			//sử dụng ViewData thay cho return View
			//this.ViewData["key"] = "value";
			//this.ViewData["product"] = product;
			//this.ViewData["Title"] = product.Name;
			//return View("ViewProduct2");

			//ViewBag: tương tự ViewData nhưng ta có thể thiết lập các thuộc tính tại thời điểm thực thi thay vì quy định trước như ViewData
			ViewBag.product = product;
			return View("ViewProduct3");

			//TempData: sử dụng session của hệ thống để lưu dữ liệu và các trang khác có thể đọc được dữ liệu này
			//Nếu được trang khác đọc ra lần đầu tiên thì dữ liệu đấy được xóa luôn
		}
	}
}
