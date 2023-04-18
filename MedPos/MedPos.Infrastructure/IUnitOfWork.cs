using MedPos.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Infrastructure
{
	public interface IUnitOfWork:IDisposable
	{
		public IUserRepository UserRepository { get; }
		public IBrandRepository BrandRepository { get; }
		public IItemRepository ItemRepository { get; }
		public void Save();
	}
}
