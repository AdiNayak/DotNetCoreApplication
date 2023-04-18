using MedPos.Core;
using MedPos.Domain.Model;
using MedPos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Service
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork unitOfWork;

		public UserService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
		public User CreateUser(User user)
		{
			var _=unitOfWork.UserRepository.Create(user);
			unitOfWork.Save();
			return user;
		}

		public async Task<User> CreateUserAsync(User user)
		{
			var _ = await unitOfWork.UserRepository.CreateAsync(user);
			unitOfWork.Save();
			return user;
		}

		public void DeleteUser(User user)
		{
			unitOfWork.UserRepository.DeleteAsync(user);
		}

		public  IEnumerable<User> GetAllUser()
		{
			return  unitOfWork.UserRepository.GetAll();
		}

		public async Task<IEnumerable<User>> GetAllUserAsync()
		{
			return await unitOfWork.UserRepository.GetAllAsync();
		}

		public User GetUser(int id)
		{
			return unitOfWork.UserRepository.Get( x=> x.UserId == id );
		}

		public Task<User> GetUserAsync(int id)
		{
			return unitOfWork.UserRepository.GetAsync(x => x.UserId == id);
		}

		public User UpdateUser(User user)
		{
			var _ =  unitOfWork.UserRepository.UpdateAsync(user, user.UserId);
			unitOfWork.Save();
			return user;
		}

		public async Task<User> UpdateUserAsync( User user)
		{
			var _ = await unitOfWork.UserRepository.UpdateAsync(user, user.us);
			unitOfWork.Save();
			return user;
		}
	}
}
