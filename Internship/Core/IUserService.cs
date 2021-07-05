using System;
using System.Collections.Generic;
using Internship.Models;

namespace Internship.Core
{
    public interface IUserService
    {
        User Add(User user);        
        User GetUserById(Guid id);
        IEnumerable<User> GetAll();
        void Remove(User user);
    }
}