using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Domain.Model
{
	public class LoginDetail
	{
		[Key]
		public int UserId { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string LoginId { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[MaxLength(10)]
		public string Mobile { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
		[DefaultValue(null)]
		public DateTime UpdatedDate { get; set; }
		[DefaultValue(true)]
		public bool IsActive { get; set; }
		[DefaultValue(false)]
		public bool IsDel { get; set; }
	}
}
