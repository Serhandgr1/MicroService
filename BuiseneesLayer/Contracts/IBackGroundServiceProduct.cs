using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiseneesLayer.Contracts
{
    public interface IBackGroundServiceProduct
    {
        ValueTask ProductStokController(int Id);
        ValueTask<int> ProductStockRead(CancellationToken cancellationToken);
        ValueTask BuyProductMail(int productId, int userId);
        ValueTask<List<int>> BuyProductMailRead(CancellationToken cancellationToken);
    }
}
