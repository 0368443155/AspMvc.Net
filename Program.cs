using CS68_MVC01.ExtendMethods;
using CS68_MVC01.Models;
using CS68_MVC01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CS68_MVC01
{
	public class Program
	{
		public static string _contentRootPath { get; set; } //lấy đường dẫn đến thư mục gốc
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Connect to database
			builder.Services.AddDbContext<AppDbContext>(options =>
			{
				var connectionString = builder.Configuration.GetConnectionString("AppMvcConnectionString");
				options.UseSqlServer(connectionString);
			});

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			//builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>)); //logger đã được tự động đăng kí nên ta chỉ cần inject
			builder.Services.AddRazorPages();
			_contentRootPath = builder.Environment.ContentRootPath;//lấy đường dẫn đến thư mục gốc
			builder.Services.Configure<RazorViewEngineOptions>(options =>
			{
				//Mặc định: Views/Controller/Action.cshtml
				//MyView/Controller/Action.cshtml
				//{0} -> tên Action		{1} -> tên Controller		{2}-> Tên Area
				options.ViewLocationFormats.Add("/MyViews/{1}/{0}" + RazorViewEngine.ViewExtension);//lấy phần mở rộng gắn vào đề phòng thay đổi định dạng
			});
			builder.Services.AddSingleton<ProductService>(); //đăng kí dịch vụ ProductService
															 //builder.Services.AddSingleton<ProductService, ProductService>();//đăng kí dịch vụ ProductService có đối tượng triển khai là ProductService hoặc các đối tượng con được triển khai từ ProductService
															 //builder.Services.AddSingleton(typeof(ProductService));//đăng kí dịch vụ ProductService có đối tượng triển khai là ProductService
															 //builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));
			builder.Services.AddSingleton<PlanetService>();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseRouting();

			app.AddStatusCodePage(); //tạo các Response với các lỗi có code từ 400 - 599

			app.UseAuthentication(); // xác định danh tính
			app.UseAuthorization(); //xác thực quyền truy cập

			app.MapStaticAssets();

			app.MapControllerRoute(
				name: "first",
				pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}", //nếu là pattern: "{url}/{controller=First}/{action=ViewProduct}/{id=1}"
																						//thì với bất kì đường link url nào đặt ở trước đều có thể thi hành được và mở ViewProduct kể cả Home/Index vì pipeline đi qua Map <-> first trước
				defaults: new
				{
					controller = "First",
					action = "ViewProduct"
				}
				//constraints: new
				//{
					//url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct))$"),
					//"xemsanpham", //StringRouteConstraint(string)
					//RegexRouteConstraint(@"^((string1)|(string2))$") = regex(^((xemsanpham)|(viewproduct))$)
					//id = new RangeRouteConstraint(2, 4)//khi đưa lên trực tiếp trên pattern: range(min,max)
				//}
				);

			//[Area(area)]
			app.MapAreaControllerRoute(
				name: "default",
				areaName: "ProductManage",
				pattern: "{controller}/{action=Index}/{id?}"
				);

			app.MapControllerRoute(
				//Url: /{Controller}/{Action}/{id?}
				//      Abc/Xyz/id? => Gọi controller Abc -> gọi action Xyz
				//nếu không có action thì mặc định là index
				//nếu không có controller thì mặc định là home
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}")
				.WithStaticAssets();

			//Url = start-here
			//Các key: controller, action, area
			//app.MapControllerRoute(
			//	name: "firstRoute",
			//	//nếu trên url: http://<gate>/start-here thì mặc định sẽ là http://<gate>/start-here/First/ViewProduct/3
			//	pattern: "start-here/{controller=First}/{action=ViewProduct}/{id=3}"
			//	);

			app.MapGet("/sayhi", async (context) =>
				{
					await context.Response.WriteAsync($"Hello Asp.MVC {DateTime.Now}");
				});


			app.MapRazorPages();

			app.Run();
		}
	}
}
