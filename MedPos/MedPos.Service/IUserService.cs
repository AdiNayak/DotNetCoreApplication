using MedPos.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Service
{
	public interface IUserService
	{
		IEnumerable<User> GetAllUser();
		Task< IEnumerable<User>> GetAllUserAsync();
		User GetUser(int id);
		Task<User> GetUserAsync(int id);
		User CreateUser(User user);
		Task<User> CreateUserAsync(User user);
		User UpdateUser(User user);
		Task<User> UpdateUserAsync(User user);
		void DeleteUser(User user);
	}
}
