
using BuiseneesLayer;
using BuiseneesLayer.Abstracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBuisennesCode _userBuisennesCode;
        public UserController()
        {
            _userBuisennesCode = new UserBuisennesCode();   
        }
        [HttpGet("user-name/{Id}")]
        public async Task<string> GetUserByName(int Id)
        {
            return await _userBuisennesCode.UserName(Id);
        }
        [HttpGet("{id}")] // "{id}"
        public async Task<UserModel> GetUser(int Id)
        {
            return await _userBuisennesCode.User(Id);
        }
        [HttpPost("user-post")]
        public async Task<string> UserPost(UserModel userModel)
        {
            await _userBuisennesCode.PostUser(userModel);
            return "USER KAYIT BAŞARILI";
        }
        [HttpPost("login-user/{userName}/{password}")]
        public async Task<int> LoginUser(string userName, string password)
        {
            return await _userBuisennesCode.LoginUser(userName, password);
        }
        [HttpPut("user-update")]
        public async Task<UserModel> UpdateUser(UserModel userModel)
        {
            return await _userBuisennesCode.UpdateUser(userModel);
        }

        [HttpDelete("{id}")]
        public async Task<string> UserDelete(int Id)
        {
            await _userBuisennesCode.UserDelete(Id);
            return "USER silindi";
        }
    }
}
