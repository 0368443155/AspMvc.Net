using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS68_MVC01.Models
{
	public class Contact
	{
		[Key]
		public int Id {  get; set; }

		[Column(TypeName = "nvarchar")]
		[StringLength(50)]
		[Required(ErrorMessage = "Phải nhập {0}")]
		[Display(Name = "Họ Tên")]
		public string FullName { get; set; }

		[StringLength(100)]
		[Required(ErrorMessage = "Phải nhập {0}")]
		[EmailAddress(ErrorMessage = "Email không đúng định dạng")]
		public string Email { get; set; }
		public DateTime DateSent { get; set; }
		[DisplayName("Nội dung")]
		public string Message {  get; set; }

		[StringLength(10)]
		[DisplayName("Số điện thoại")]
		[Phone(ErrorMessage = "Phải là {0}")]
		public string Phone { get; set; }
	}
}
//dotnet aspnet-codegenerator controller -name ContactController -namespace CS68_MVC01.Areas.Contact.Controllers -m CS68_MVC01.Models.Contact -udl -dc CS68_MVC01.Models.AppDbContext -outDir Areas/Contact/Controllers/