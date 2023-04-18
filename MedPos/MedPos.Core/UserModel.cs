using MedPos.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Core
{
	public class UserModel
	{
        public User User { get; set; }= new User();
		public IEnumerable<User> Users { get; set; }= Enumerable.Empty<User>();
    }
}
