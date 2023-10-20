using DataAccessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UserDataRepostory : IUserDataRepostory
    {
        public async Task<int> LoginUser(string userName, string password)
        {
            using (var db = new DataContext())
            {
                int id = 0;
                var data = await db.Users.Where(x => x.UserName == userName && x.Password == password).ToListAsync();
                foreach (UserModel model in data)
                {
                    id = model.UserId;
                }
                return id;
            }
        }
    }
}
