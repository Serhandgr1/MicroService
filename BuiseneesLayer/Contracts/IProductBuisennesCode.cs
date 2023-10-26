using DataAccessLayer.Models;

namespace Product.Api
{
    public interface IProductBuisennesCode
    {
        Task<ProductModel> LikeData(int productId, int userId);
        Task<ProductModel> BuyProductsUser(int productId, int userId);
        Task<List<ProductModel>> BuyProductsGetUser(int userId);
        Task<List<ProductModel>> ExaminedProductAll(int userId);
        Task<List<ProductModel>> LikeProduct(int userId);
        Task<List<ProductModel>> KampanyaProduct();
        Task<List<ProductModel>> Products();
        Task<List<ProductModel>> BuyProduct();
        Task<ProductModel> PostProduct(ProductModel productModel);
        Task PostProductInCard(int productId, int userId);
        Task<List<ProductModel>> ProductCard(int Id);
        Task LikedDelete(int productId, int userId);
        Task ProductDelete(int Id);
        Task<ProductModel> ProductsById(int Id);
        Task<ProductModel> ExaminedProduct(int productId, int userId);
        Task<ProductModel> UpdateProduct(ProductModel productModel);
        Task<ProductModel> ProductDeleteInCard(int userId, int Id);
        Task<List<ProductModel>> SimilarProducts(int productId);
        Task<List<ProductModel>> FeaturedProduct();
        Task<List<ProductModel>> BestSellingProducts();
        Task<List<ProductModel>> GetOfferProductById(int id);
        Task<List<ProductModel>> GetBrandById(int id);
        Task<List<ProductModel>> GetCategoryById(int id);
        Task<List<ProductModel>> GetModelsById(int id);
        Task<List<ProductModel>> SimilarReviewedProduct(int productId);
    }
}
