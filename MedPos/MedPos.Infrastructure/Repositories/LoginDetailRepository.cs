using MedPos.Domain.Data;
using MedPos.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPos.Infrastructure.Repositories
{
	internal class LoginDetailRepository:Repository<LoginDetail>, ILoginDetailRepository
	{
		public LoginDetailRepository(MedPosDbContext context) : base(context)
		{

		}
	}
}
