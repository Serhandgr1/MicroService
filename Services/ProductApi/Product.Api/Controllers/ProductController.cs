using BuiseneesLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly ILogger<ProductController> logger;
        private readonly IProductBuisennesCode _productBuisennesCode;
        //    private readonly IBackGroundServiceProduct _backGroundServiceProduct;
        public ProductController(ILogger<ProductController> _logger)
        {
            _logger = logger;
            _productBuisennesCode = new ProductBuisennesCode();
     //       _backGroundServiceProduct = backGroundServiceProduct;
        }

        [HttpGet("{id}")] //"{id}"
        public async Task<ProductModel> GetProductsById(int Id)
        {
            ILogger logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<ProductController>();
            logger.LogInformation(1, "About page visited at {DT}", DateTime.UtcNow.ToLongTimeString());
            return await _productBuisennesCode.ProductsById(Id);
            //   return await _genericBuisennesCode.GetById(Id);
            //  IProduct product = new BuiseneesCodes();
            //  return await _product.ProductsById(Id);
        }

        [HttpGet("productslike/{id}")]
        public async Task<List<ProductModel>> LikeProduct(int Id)
        {
        return  await  _productBuisennesCode.LikeProduct(Id);
         // return await _genericLikeDataBuisennesCode.GetById(Id);
         //  return await _product.LikeProduct(Id);
        }
        [HttpGet("products-buy")]
        public async Task<List<ProductModel>> BuyProduct()
        {
        return  await _productBuisennesCode.BuyProduct();
          //var buyModel= await _genericBuyDataBuisennesCode.GetAllData();
          //List<ProductModel> products = new List<ProductModel>();
          //  foreach (BuyProductModel buy in buyModel) 
          //  {
          //      products.Add(await _genericBuisennesCode.GetById(buy.ProductId));
          //  }
          //  return products;
        }
        [HttpGet("products-buy-user/{userId}")]
        public async Task<List<ProductModel>> BuyProductsGetUser(int userId)
        {
         return await  _productBuisennesCode.BuyProductsGetUser(userId);
       //     return await _product.BuyProductsGetUser(userId);
        }
        [HttpGet("products-kampanya")]
        public async Task<List<ProductModel>> KampanyaProduct()
        {
         return  await _productBuisennesCode.KampanyaProduct();
          //  return await _product.KampanyaProduct();
        }
        [HttpGet("get-all-products")]
        public async Task<List<ProductModel>> GetProducts()
        {
            return  await _productBuisennesCode.Products();
         // return await _genericBuisennesCode.GetAllData();
          //  return await _product.Products();
        }
        [HttpGet("products-examined/{userId}")]
        public async Task<List<ProductModel>> ExaminedProductAll(int userId)
        {
         return  await _productBuisennesCode.ExaminedProductAll(userId);
          //  return await _product.ExaminedProductAll(userId);
        }
        [HttpGet("card/{Id}")]
        public async Task<List<ProductModel>> GetCard(int Id)
        {
        return await   _productBuisennesCode.ProductCard(Id);
          //  return await _product.ProductCard(Id);

        }
        [HttpPost("products-post")]
        public async Task<string> PostProduct(ProductModel productModel)
        {
           await _productBuisennesCode.PostProduct(productModel);
          //  await _product.PostProduct(productModel);
            return "KAYIT BAŞARILI";
        }
        [HttpPost("products-post-card/{productId}/{userId}")]
        public async Task<List<ProductModel>> PostProductInCard(int productId, int userId)
        {
           // await  _productBuisennesCode.PostProductInCard(productId, userId);
             return await _productBuisennesCode.SimilarProducts(productId);
          //  await _product.PostProductInCard(productId, userId);
           // return "Ürün Sepere Eklendi";
        }
        [HttpPost("products-post-liked/{productId}/{userId}")]
        public async Task<ProductModel> LikeProduct(int productId, int userId)
        {
          return await _productBuisennesCode.LikeData(productId, userId);
         //   return await _product.LikeData(productId, userId);
        }
        [HttpPost("products-examined-last/{productId}/{userId}")]
        public async Task<ProductModel> ExaminedProduct(int productId, int userId)
        {
         return await  _productBuisennesCode.ExaminedProduct(productId, userId);
         //   return await _product.ExaminedProduct(productId, userId);
        }
        [HttpPost("products-buy/{productId}/{userId}")]
        public async Task<ProductModel> BuyProductsUser(int productId, int userId)
        {
          return await  _productBuisennesCode.BuyProductsUser(productId, userId);
          //  await _backGroundServiceProduct.BuyProductMail(productId, userId);
           // await _backGroundServiceProduct.ProductStokController(productId);
         //   return await _product.BuyProductsUser(productId, userId);
        }
        [HttpPut("products-uptade")]
        public async Task<ProductModel> UpdateProduct(ProductModel productModel)
        {
          return await _productBuisennesCode.UpdateProduct(productModel);
           // return await _product.UpdateProduct(productModel);
        }
        [HttpDelete("{id}")]
        public async Task<string> ProductDelete(int Id)
        {
             await _productBuisennesCode.ProductDelete(Id);
          //  await _product.ProductDelete(Id);
            return "Product silindi";
        }
        [HttpDelete("product-delete-card/{userId}/{Id}")]
        public async Task<ProductModel> ProductDeleteInCard(int userId, int Id)
        {
          return await _productBuisennesCode.ProductDeleteInCard(userId, Id);  

          //  return await _product.ProductDeleteInCard(userId, Id);
        }
        [HttpDelete("product-delete-liked/{productId}/{userId}")]
        public async Task<string> LikedDelete(int productId, int userId)
        {
            await _productBuisennesCode.LikedDelete(productId, userId);
        //    await _product.LikedDelete(productId, userId);
            return "Beğeniden silindi";
        }
    }
}
