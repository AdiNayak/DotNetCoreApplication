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
		private bool disposedValue;

		public UnitOfWork(MedPosDbContext context)
		{
			this._context = context;
			UserRepository= new UserRepository(context);
			BrandRepository = new BrandRepository(context);
			ItemRepository = new ItemRepository(context);
		}
		public IUserRepository UserRepository { get; private set; }
		public IBrandRepository BrandRepository  { get; private set; }
		public IItemRepository ItemRepository { get; private set; }
		public void Save()
		{
			_context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~UnitOfWork()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
