using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ProductsInCartModel
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
