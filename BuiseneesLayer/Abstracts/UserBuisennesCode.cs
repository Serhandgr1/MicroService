using BuiseneesLayer.Abstracts;
using BuiseneesLayer.Contracts;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Models;

namespace User.Api
{
    public class UserBuisennesCode : IUserBuisennesCode
    {
        private readonly IGenericBuisennesCode<UserModel> _genericBuisennesCode;
        private readonly IUserDataRepostory _userDataRepostory;
        public UserBuisennesCode()
        {
           _userDataRepostory = new UserDataRepostory();
            _genericBuisennesCode = new GenericBuisenessCode<UserModel>();
        }
        public async Task<int> LoginUser(string userName, string password)
        {
            return await _userDataRepostory.LoginUser(userName, password);
            // return context.LoginUser(userName, password);
        }

        public async Task PostUser(UserModel userModel)
        {

             await _genericBuisennesCode.Create(userModel);
          //  await _repository.AddUser(userModel);
            //  context.PostUser(userModel);
        }

        public async Task<UserModel> UpdateUser(UserModel userModel)
        {
             await _genericBuisennesCode.Update(userModel);
             return userModel;
           // return await _repository.UpdateUser(userModel);
            //return context.UpdateUser(userModel);
        }

        public async Task<UserModel> User(int Id)
        {
           return  await _genericBuisennesCode.GetById(Id);
          //  return await _repository.User(Id);
            //return context.User(Id);    
        }

        public async Task UserDelete(int Id)
        {
            var user=await _genericBuisennesCode.GetById(Id);
            await _genericBuisennesCode.Delete(user);
            // context.UserDelete(Id);
        }

        public async Task<string> UserName(int userId)
        {
             UserModel data = await _genericBuisennesCode.GetById(userId);
             return data.UserName;
          //  return await _repository.UserName(userId);
        }
    }
}
