using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Domain.Model
{
	[Table("Brand")]
	public class Brand
	{
		public Brand() => Items = new HashSet<Item>();
		[Key]
		public int BrandId { get; set; }
		[Required]
		public string BrandName { get; set; }		
		public string BrandDescription { get; set;}
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
		public virtual ICollection<Item> Items { get; set; }
	}
}
