using CS68_MVC01.Services;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CS68_MVC01
{
	public class Program
	{
		public static string _contentRootPath { get; set; } //lấy đường dẫn đến thư mục gốc
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

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

			app.UseAuthentication(); // xác định danh tính
			app.UseAuthorization(); //xác thực quyền truy cập

			app.MapStaticAssets();

			app.MapControllerRoute(
				//Url: /{Controller}/{Action}/{id?}
				//      Abc/Xyz/id? => Gọi controller Abc -> gọi action Xyz
				//nếu không có action thì mặc định là index
				//nếu không có controller thì mặc định là home
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}")
				.WithStaticAssets();

			app.MapRazorPages();

			app.Run();
		}
	}
}
