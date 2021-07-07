using System;
using Internship.Models;

namespace Internship.Core
{
	public interface IUserRepository : IRepository<User>
	{
		User GetUserById(Guid id);
		User GetUserByEmailAndPass(string email, string password);
	}
}
