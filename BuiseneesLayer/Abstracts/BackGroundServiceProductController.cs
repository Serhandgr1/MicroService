using BuiseneesLayer.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BuiseneesLayer.Abstracts
{
    public class BackGroundServiceProductController : IBackGroundServiceProduct
    {
        private readonly Channel<int> product;
        private readonly Channel<List<int>> buy;
        public BackGroundServiceProductController(IConfiguration configuration)
        {

            int.TryParse(configuration["Capacity"], out int capacty);
            BoundedChannelOptions options = new(capacty)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            product = Channel.CreateBounded<int>(options);
            buy = Channel.CreateBounded<List<int>>(options);
        }
        public async ValueTask ProductStokController(int Id)
        {
            ArgumentNullException.ThrowIfNull(nameof(Id));
            await product.Writer.WriteAsync(Id);
        }
        public ValueTask<int> ProductStockRead(CancellationToken cancellationToken)
        {
            var productControl = product.Reader.ReadAsync(cancellationToken);
            return productControl;
        }
        public async ValueTask BuyProductMail(int productId, int userId)
        {
            List<int> buyMail = new List<int>();
            buyMail.Add(productId);
            buyMail.Add(userId);
            await buy.Writer.WriteAsync(buyMail);
        }
        public ValueTask<List<int>> BuyProductMailRead(CancellationToken cancellationToken)
        {
            var buyMail = buy.Reader.ReadAsync(cancellationToken);
            return buyMail;
        }
    }
}
