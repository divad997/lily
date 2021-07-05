using System;
using System.Linq;
using Internship.Core;
using Internship.Models;
using Internship.Repositories;

namespace Internship.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{

		public UserRepository(Context context) : base(context)
		{
		}

		public User GetUserById(Guid id)
		{
			return context.Users.Where(x => x.Id == id).FirstOrDefault();
		}
    }
}