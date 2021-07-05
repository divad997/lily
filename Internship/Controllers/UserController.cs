using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Core;
using Internship.Models;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase 
	{
        private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
            _userService = userService;
		}


		//POST /user
		
		[HttpPost]  
		public ActionResult<User> Register(User user)
		{
			User newUser = _userService.Add(user);

			return Ok(user);
		}

		[HttpGet("{id}")] //R
		public ActionResult<User> GetUserById(Guid id)
		{
			var userModel = _userService.GetUserById(id);
			if (userModel != null)
			{
				return Ok(userModel);
			}
			return NotFound();
		}

		[HttpGet]  //R A
		public ActionResult<IEnumerable<User>> GetAll()
		{
			var users = _userService.GetAll();
			if(users != null)
			{
				return Ok(users);
			}
			return NotFound();
		}

		[HttpDelete("{id}")] //D
		public void DeleteUser(Guid id)
		{
			User user = _userService.GetUserById(id);
			_userService.Remove(user);
		}
	}
}
