using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Internship.Core;
using Internship.Models;
using Microsoft.AspNetCore.Mvc;

namespace Internship.Controllers
{
    [Route("api/users")]
	[ApiController]
	public class UserController : ControllerBase 
	{
        private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
            _userService = userService;
		}
		
		//POST /users
		[HttpPost] 
		public async Task<IActionResult> CreateUser(User user)
		{

			User newUser = _userService.GetUserWithEmailAndPass(user.Email,user.Password);
			if(user != null)
			{
				return BadRequest("User exists");
			}

			Boolean success = _userService.CreateUserAndSendToken(newUser);

			if(success)
			{
				return Ok(newUser);
			}
			else
			{
				return BadRequest("Something went wrong");
			}
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
