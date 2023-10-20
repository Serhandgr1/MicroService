using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string E_Mail { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
