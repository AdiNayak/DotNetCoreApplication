using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Domain.Model
{
	public class Item
	{
		[Key]
		public int ItemId { get; set; }
		[Required]
		public string ItemName { get; set; }
		public int BrandId { get; set; }
		public string ItemDescription { get; set; }

		[DefaultValue(null)]
		public int? CreatedBy { get; set; }
		[DefaultValue(null)]
		public int? UpdatedBy { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
		[DefaultValue(null)]
		public DateTime UpdatedDate { get; set; }
		[DefaultValue(true)]
		public bool IsActive { get; set; }
		[DefaultValue(false)]
		public bool IsDel { get; set; }
		public virtual Brand Brand { get; set; }
	}
}
