using System;
using System.Collections.Generic;
using Internship.Core;
using Internship.Models;
using Internship.Repositories;

namespace Internship.Service
{
	public class UserService : IUserService
	{
        public UserService(){}
		public User Add(User user)
		{
			if(user == null)
			{
				return null;
			}
			try
			{
				using(var unitOfWork = new UnitOfWork(new Context()))
				{
					unitOfWork.Users.Add(user);
					unitOfWork.Complete();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return user;
		}

		public User GetUserById(Guid id)
		{
			try
			{
				using(var unitOfWork = new UnitOfWork(new Context()))
				{
					var user = unitOfWork.Users.GetUserById(id);
					if(user == null)
					{
						return null;
					}
					return user;
				}
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public User GetUserWithEmailAndPass(string email, string password)
		{
			try
			{
				using(var unitOfWork = new UnitOfWork(new Context()))
				{
					return unitOfWork.Users.GetUserByEmailAndPass(email, password);
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public Boolean CreateUserAndSendToken(User user)
		{
			if(user == null)
			{
				return false;
			}
			try
			{
				using(var unitOfWork = new UnitOfWork(new Context()))
				{

					unitOfWork.Users.Add(user);
					unitOfWork.Complete();
				}
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
			return true;
		}

		public IEnumerable<User> GetAll()
		{
			try
			{
				using(var unitOfWork = new UnitOfWork(new Context()))
				{
					var users = unitOfWork.Users.GetAll();
					if(users == null)
					{
						return null;
					}
					return users;
				}
			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}

		}

		public void Remove(User user)
		{
			try
			{
				using(var unitOfWork = new UnitOfWork(new Context()))
				{
					unitOfWork.Users.Remove(user);
					unitOfWork.Complete();
				}
			}
			catch( Exception e)
			{
				throw new Exception(e.Message);
			}
		}
    }
}