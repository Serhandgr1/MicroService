using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int Stock { get; set; }
        public string ProductDetail { get; set; }
        public string ProductImage { get; set; }
        public string ProductOzet { get; set; }
    }
}
