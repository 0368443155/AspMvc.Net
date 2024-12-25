## Controller
- Là một lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller
- Được thiết lập các thuộc tính của asp net
- Trong controller có đầy đủ thông tin mà HttpRequest gửi đến
- 1 Phương Thức/Action có thể không trả về một giá trị/đối tượng nào cả
- Và 1 phương thưc/action cũng có thể trả về bất kì giá trị/đối tượng nào đó
## Logger
- Được chia làm 6 cấp độ
	- Trace: lời nhắn
	- Debug: thông tin viết ra trong quá trình phát triển
	- Infomation: thông tin theo tiến trình ứng dụng
	- Warning: cảnh báo
	- Error: lỗi
	- Critical: nguy cơ crash
	- None: không làm gì cả
## IActionResult
    Kiểu trả về                 | Phương thức
    ------------------------------------------------
    ContentResult               | Content()             trả về content
    EmptyResult                 | new EmptyResult()     không trả về gì cả
    FileResult                  | File()                trả về 1 file
    ForbidResult                | Forbid()
    JsonResult                  | Json()
    LocalRedirectResult         | LocalRedirect()
    RedirectResult              | Redirect()
    RedirectToActionResult      | RedirectToAction()
    RedirectToRouteResult       | RedirectToRoute()
    RedirectToPageResult        | RedirectToPage()
    PartialViewResult           | PartialView()
    ViewComponentResult         | ViewComponent()
    StatusCodeResult            | StatusCode()
    ViewResult                  | View()

## Ánh xạ vào các Controller
    - MapController             : cấu hình để tạo ra các endpoint đến Controller, sau đó đến cái ep được định nghĩa
    - MapControllerRoute
    - MapDefaultControllerRoute
    - MapAreaControllerRoute    : tạo các endp trong các Area

## Các Attribute để thiết lập các thuộc tính của MapControllerRoute
- [AcceptVerbs("POST", "GET")]: thiết lập phương thức truy cập cho các Action tùy vào POST hoặc GET
- [Route(url)]: khi các Controller hoặc các Action có thiết lập ánh xạ thông qua MapControllerRoute/MapController
            các Action của Controller có thể tạo ra các Route
            -> khi đã thiết lập các route thì ta chỉ có thể truy cập vào các action thông qua url được thiết lập trong route
               mà không thể truy cập theo đường dẫn từ MapController
            - ta cũng có thể thiết lập các token action, controller, area trong url của [Route]
                    [Route("[area]/[controller]/[action]")]
    + [Route] có thể khai báo nhiều lần, tức là với 1 action ta có thể dùng nhiều url đã được khai báo để truy cập vào action đó
    + thiết lập độ ưu tiên khi thiết lập bằng Order
    + thiết lập Name để sử dụng Url.RouteUrl lấy ra url của action đó
- [HttpGet(url)]: tương tự như [Route] nhưng HttpGet chỉ cho phép truy cập bằng phương thức get theo url đã thiết lập
- [HttpPost(url)]: tương tự như [Route] nhưng HttpGet chỉ cho phép truy cập bằng phương thức get theo url đã thiết lập
- [Area(area)]: thiết lập Area của Controller và phải sử dụng MapAreaController, cần thiết lập thêm thuộc tính areaName tương ứng với area đã khai báo

## UrlHelpers: phát sinh url theo Action
- Url.ActionLink() : phát sinh url bao gồm cả host
- Url.Action() : không bao gồm host, chỉ có đường dẫn controller đến action đó
- Url.Route() hoặc Url.Link();
    Các phương thức này có thể thiế lập các thuộc tính như action,controller,area bằng cách tạo đối tượng vô danh
    hoặc truyền các tham số tương ứng với kiểu của dữ liệu bên trong phương thức
- Cũng có thể sử dụng tagHelper: 
    + asp-arae 
    + asp-action 
    + asp-controller 
    + asp-route...(id,name,...) 
    + asp-route