using System;
using Internship.Models;

namespace Internship.Core
{
	public interface IUserRepository : IRepository<User>
	{
		User GetUserById(Guid id);
	}
}
