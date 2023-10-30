using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDataRepostory
    {
        Task<List<ProductModel>> BuyProductsGetUser(int userId);
        Task<ProductModel> BuyProductsUser(int productId, int userId);
        Task<ProductModel> ExaminedProduct(int productId, int userId);
        Task<List<ProductModel>> ExaminedProductAll(int userId);
        Task<List<ProductModel>> LikeProduct(int userId);
        Task<List<ProductModel>> ProductCard(int Id);
        Task<List<ProductModel>> SimilarProducts(int productId);
        Task<List<ProductModel>> FeaturedProduct();
        Task<List<ProductModel>> BestSellingProducts();
        Task<List<ProductModel>> GetOfferProductById(int id);
        Task<List<ProductModel>> GetBrandById(int id);
        Task<List<ProductModel>> GetCategoryById(int id);
        Task<List<ProductModel>> GetModelsById(int id);
        Task<List<ProductModel>> SimilarReviewedProduct(int productId);
        Task<List<CategoryModel>> GetAllCategoryName();
    }
}
