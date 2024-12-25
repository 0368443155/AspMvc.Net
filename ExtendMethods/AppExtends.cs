using Microsoft.AspNetCore.Builder;
using System.Net;

namespace CS68_MVC01.ExtendMethods
{
	public static class AppExtends
	{
		public static void AddStatusCodePage(this IApplicationBuilder app)
		{
			app.UseStatusCodePages(appError =>
			{
				appError.Run(async context =>
				{
					var response = context.Response; //lấy về response
					var code = response.StatusCode; //lấy về StatusCode của lỗi

					var content = @$"<html>
<head>
	<meta charset=UTF-8 />
	<title>Lỗi {code}</title>
</head>
	<body>
		<p style='color:red; font-size:30px'>	
			Có lỗi xảy ra: {code} - {(HttpStatusCode)code}
		</p>
	</body>
</html>";
					await response.WriteAsync(content);
				});
			});
		}
	}
}
