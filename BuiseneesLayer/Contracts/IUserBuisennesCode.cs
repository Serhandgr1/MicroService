using DataAccessLayer.Models;

namespace User.Api
{
    public interface IUserBuisennesCode
    {
        Task<string> UserName(int userId);
        Task<UserModel> User(int Id);
        Task PostUser(UserModel userModel);
        Task UserDelete(int Id);
        Task<UserModel> UpdateUser(UserModel userModel);
        Task<int> LoginUser(string userName, string password);
    }
}
