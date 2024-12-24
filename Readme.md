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