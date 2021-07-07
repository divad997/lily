using System;
using System.Collections.Generic;
using Internship.Models;

namespace Internship.Core
{
    public interface IUserService
    {
        User Add(User user);        
        User GetUserById(Guid id);
        User GetUserWithEmailAndPass(string email, string password);
        Boolean CreateUserAndSendToken(User user);
        IEnumerable<User> GetAll();
        void Remove(User user);
    }
}