
using MedPos.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedPos.Domain.Data
{
	public class MedPosDbContext: DbContext
	{
		public MedPosDbContext(DbContextOptions<MedPosDbContext> options ):base(options)
		{

		}
		public DbSet<LoginDetail> LoginDetails { get; set; }

		public DbSet<Brand> Brands { get; set; }
	}
}
