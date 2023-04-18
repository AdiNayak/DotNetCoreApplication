using MedPos.Core;
using MedPos.Domain.Model;
using MedPos.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Net;

namespace MedPos.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUnitOfWork unitOfWork;

		public UserController(IUnitOfWork unitOfWork )
		{
			this.unitOfWork = unitOfWork;
		}
		[HttpGet,Route("AllUsers")]
		public async Task<IActionResult> Get()
		{
			UserModel userModel = new UserModel();
			userModel.Users = await unitOfWork.UserRepository.GetAllAsync();
			if (userModel.Users.Count() == 0)
			{
				return NotFound("Users are not found.");
			}
			else
			{
				return Ok(userModel.Users);
			}
		}
		[HttpGet, Route("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			if (id == 0)
			{
				return BadRequest("User id not found" + id);
			}

			UserModel userModel = new UserModel();
			userModel.User = await unitOfWork.UserRepository.GetAsync(x => x.UserId == id);

			if (userModel.User == null)
			{
				return NotFound("User is not found.");
			}
			else
			{
				return Ok(userModel.User);
			}
		}

		[HttpPost, Route("Create")]
		public async Task< IActionResult> Post([FromBody] UserModel userModel)
		{
			if (userModel == null)
			{
				return BadRequest("User content not found");
			}
			if (ModelState.IsValid)
			{
				var user = await unitOfWork.UserRepository.CreateAsync(userModel.User);
				unitOfWork.Save();
				return Ok(user);
			}
			else
			{
				return BadRequest("User content not found");
			}
		}

		[HttpPut, Route("Update")]
		public async Task<IActionResult> Put([FromBody] UserModel userModel)
		{
			if (userModel == null)
			{
				return BadRequest("User content not found");
			}
			if (ModelState.IsValid)
			{
				var user = await unitOfWork.UserRepository.UpdateAsync(userModel.User, userModel.User.UserId);
				unitOfWork.Save();
				return Ok(user);
			}
			else
			{
				return BadRequest("User content not found");
			}
		}

		//[HttpDelete, Route("Delete/{id}")]
		//public async Task<IActionResult> Delete(int id)
		//{
		//	if (id == 0)
		//	{
		//		return BadRequest("User id not found" + id);
		//	}
		//	UserModel userModel = new UserModel();
		//	userModel.User = await unitOfWork.UserRepository.GetAsync(x => x.UserId == id);
		//	if (userModel.User != null)
		//	{
		//		unitOfWork.ItemRepository.Delete(userModel.User);
		//		unitOfWork.Save();
		//		return Ok();
		//	}
		//	else
		//	{
		//		return BadRequest("User id not found");
		//	}
			
		//}
	}
}
