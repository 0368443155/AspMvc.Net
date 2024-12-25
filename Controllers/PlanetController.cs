using CS68_MVC01.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS68_MVC01.Controllers
{
    public class PlanetController : Controller
    {
        // GET: Planet
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;
        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _logger = logger;
            _planetService = planetService;
        }

		//[Route(url)]: thiết lập url cho action
		//Ví dụ [Route(danhsachhanhtinh.html)
        public IActionResult Index()
        {
            return View();
        }

        //route action
        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name {  get; set; } //khi ta truy cập vào 1 action thì name sẽ nhận giá trị là tên của action đó
        public IActionResult Mecury()
        {
             var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Details", planet); 
        }
		public IActionResult Venus()
		{
			var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
			return View("Details", planet);
		}
		public IActionResult Earth()
		{
			var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
			return View("Details", planet);
		}
		public IActionResult Mars()
		{
			var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
			return View("Details", planet);
		}
		[HttpGet("/saomoc")] //nếu là HttpPost thì sẽ gặp lỗi 405 MethodNotAllowed
		public IActionResult Jupiter()
		{
			var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
			return View("Details", planet);
		}
		public IActionResult Saturn()
		{
			var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
			return View("Details", planet);
		}
		public IActionResult Uranus()
		{
			var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
			return View("Details", planet);
		}

		[Route("hanhtinh-[controller]-[action]", Order = 3, Name = "neptune3")]
		[Route("hanhtinh/[action]", Order = 2, Name = "neptune2")]
		[Route("hanhtinh/[controller]/[action]", Order = 1, Name = "neptune1")] //hanhtinh/Planet/Neptune hoặc cũng có thể thay dấu / bằng dấu - đều được
		public IActionResult Neptune()
		{
			var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
			return View("Details", planet);
		}

		[Route("hanhtinh/{id:int}")]
		public IActionResult PlanetInfo(int id)
		{
			var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
			return View("Details", planet);
		}
	}
}
