using CS68_MVC01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS68_MVC01.Areas.Database.Controllers
{
	[Area("Database")]
	[Route("/database-manage/[action]")]
	public class DbManageController : Controller
	{
		private readonly AppDbContext _dbContext;
		public DbManageController(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			return View();
		}

		[TempData]
		public string StatusMessage {  get; set; }
		[HttpGet]
		public IActionResult DeleteDb()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> DeleteDbAsync()
		{
			var success = await _dbContext.Database.EnsureDeletedAsync();

			StatusMessage = success ? "Xóa Db thành công" : "Xóa Db không thành công";

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> MigrateDb()
		{
			await _dbContext.Database.MigrateAsync();

			StatusMessage = "Cập nhật Db thành công";

			return RedirectToAction(nameof(Index));
		}
	}
}
