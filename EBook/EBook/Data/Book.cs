using System;

namespace EBook.Data
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }	
		public string Description { get; set; }
		public string Category { get; set; }
		public string Language { get; set; }
		public string TotalPages { get; set; }
		public DateTime? CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
