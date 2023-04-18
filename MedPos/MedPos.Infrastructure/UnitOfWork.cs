using MedPos.Domain.Data;
using MedPos.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MedPosDbContext _context;
		public UnitOfWork(MedPosDbContext context)
		{
			this._context = context;
		}
		public ILoginDetailRepository LoginDetailRepository { get; private set; }

		public IBrandRepository BrandRepository  { get; private set; }

		public IItemRepository ItemRepository { get; private set; }

		public void Commit()
		{
			_context.SaveChanges();
		}
	}
}
