using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class BuyProductModel
    {
        [Key]
        public int BuyId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
