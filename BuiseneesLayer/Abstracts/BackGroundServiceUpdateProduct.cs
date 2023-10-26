using BuiseneesLayer.Contracts;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiseneesLayer.Abstracts
{
    public class BackGroundServiceUpdateProduct : BackgroundService
    {
        private readonly IBackGroundServiceProduct _product;
        public BackGroundServiceUpdateProduct(IBackGroundServiceProduct product)
        {
            _product = product;
        }
        // ürün güncellendiğinde bu ürünün stok durumunu ve fiyatını kontrol eden eğer stok min stok altına düştü ise yada fiyat indirime girdi ise bu ürünü sepetinde bulunduran yada beğenen kullanıcılara mail gönderecek olan bg service yazılacak

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           while (!stoppingToken.IsCancellationRequested) 
            {
              var product= await _product.UpdateProductRead(stoppingToken);
                if (product != null) 
                {
                    
                }
            }
        }
    }
}
