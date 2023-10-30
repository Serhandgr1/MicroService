using AutoMapper;
using BuiseneesLayer;
using BuiseneesLayer.Abstracts;
using BuiseneesLayer.Contracts;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Models;

namespace Product.Api
{
    public class ProductBuisennesCode : IProductBuisennesCode
    {
        private readonly IProductDataRepostory _productDataRepostory;
        private readonly IGenericBuisennesCode<ProductModel> _genericProductRepostory;
        private readonly IGenericBuisennesCode<BuyProductModel> _genericBuyProductRepostory;
        private readonly IGenericBuisennesCode<KampanyaProductModel> _genericKampanyaProductRepostory;
        private readonly IGenericBuisennesCode<ProductsInCartModel> _genericProductInCardRepostory;
        private readonly IGenericBuisennesCode<LikeDataModel> _genericLikeDataRepostory;
        private readonly IMapper _mapper;
        public ProductBuisennesCode()
        {
            _genericProductRepostory = new GenericBuisenessCode<ProductModel>();
            _genericBuyProductRepostory = new GenericBuisenessCode<BuyProductModel>();
            _genericKampanyaProductRepostory = new GenericBuisenessCode<KampanyaProductModel>();
            _genericProductInCardRepostory = new GenericBuisenessCode<ProductsInCartModel>();
            _genericLikeDataRepostory= new GenericBuisenessCode<LikeDataModel>();
            _productDataRepostory = new ProductDataRepostory(_mapper);
        }
        public async Task<List<ProductModel>> BuyProduct()
        {
          var data = await  _genericBuyProductRepostory.GetAllData();
            List<ProductModel> productModels = new List<ProductModel>();
            foreach (BuyProductModel model in data) 
            {
                var product =  await _genericProductRepostory.GetById(model.ProductId);
                productModels.Add(product);
            }
           return productModels;
        }
        public async Task<List<CategoryModel>> GetAllCategoryName() {
            return await _productDataRepostory.GetAllCategoryName();
        }

        public async Task<List<ProductModel>> BuyProductsGetUser(int userId)
        {  

            return await _productDataRepostory.BuyProductsGetUser(userId);
            // return context.BuyProductsGetUser(userId);
        }

        public async Task<ProductModel> BuyProductsUser(int productId, int userId)
        {
        
            return await _productDataRepostory.BuyProductsUser(productId, userId);
            // return context.BuyProductsUser(productId, userId);
        }

        public async Task<ProductModel> ExaminedProduct(int productId, int userId)
        {
            return await _productDataRepostory.ExaminedProduct(productId, userId);
            // return context.ExaminedProduct(productId,userId);
        }

        public async Task<List<ProductModel>> ExaminedProductAll(int userId)
        {
            return await _productDataRepostory.ExaminedProductAll(userId);
            // return context.ExaminedProductAll(userId);
        }

        public async Task<List<ProductModel>> KampanyaProduct()
        {
        var data=   await  _genericKampanyaProductRepostory.GetAllData();
            List<ProductModel> products = new List<ProductModel>(); 
            foreach (KampanyaProductModel kampanya in data) 
            {
                var product=  await  _genericProductRepostory.GetById(kampanya.ProductId);
                products.Add(product);  
            }
            return products;
            //  return context.KampanyaProduct();
        }

        public async Task<ProductModel> LikeData(int productId, int userId)
        {
            LikeDataModel likeDataModel = new LikeDataModel();
            likeDataModel.UserId = userId;
            likeDataModel.ProductId = productId;
            await _genericLikeDataRepostory.Create(likeDataModel);
            var data=await  _genericProductRepostory.GetById(productId);
            return data;
            // return context.LikeProduct(productId, userId);
        }

        public async Task LikedDelete(int productId, int userId)
        {
            LikeDataModel likeDataModel = new LikeDataModel();
            likeDataModel.UserId = userId;
            likeDataModel.ProductId = productId;
            await _genericLikeDataRepostory.Delete(likeDataModel);
            // await _repository.LikedDelete(productId, userId);
            // context.LikedDelete(productId,userId);
        }

        public async Task<List<ProductModel>> LikeProduct(int userId)
        {
            return await _productDataRepostory.LikeProduct(userId);
            //   return context.LikeProduct(userId);
        }

        public async Task<ProductModel> PostProduct(ProductModel productModel)
        {
            await _genericProductRepostory.Create(productModel);
            return productModel;
           // return await _repository.AddProduct(productModel);
        }

        public async Task PostProductInCard(int productId, int userId)
        {   ProductsInCartModel productsInCartModel = new ProductsInCartModel();
            productsInCartModel.ProductId = productId;
            productsInCartModel.UserId = userId;
           await   _genericProductInCardRepostory.Create(productsInCartModel);
          //  await _repository.PostProductInCard(productId, userId);
            //  context.PostProductInCard(productId, userId);
        }
        public async Task<List<ProductModel>> SimilarProducts(int productId)  /// sepete eklenen ürünü satın alanların aldığı diğer ürünlerin listesi
        {
           return await _productDataRepostory.SimilarProducts(productId);
        }
        public async Task<List<ProductModel>> ProductCard(int Id)
        { 
            return await _productDataRepostory.ProductCard(Id);
            //return context.ProductsCard(Id);
        }

        public async Task ProductDelete(int Id)
        {
            ProductModel data = await _genericProductRepostory.GetById(Id);
            await _genericProductRepostory.Delete(data);
            // context.ProductDelete(Id);
        }

        public async Task<ProductModel> ProductDeleteInCard(int userId, int Id)
        {
            ProductsInCartModel productsInCartModel = new ProductsInCartModel();
            productsInCartModel.ProductId = Id;
            productsInCartModel.UserId = userId;
            await  _genericProductInCardRepostory.Delete(productsInCartModel);
            return  await _genericProductRepostory.GetById(Id);
           // return await _repository.ProductDeleteInCard(userId, Id);
            // return context.ProductDeleteInCard(userId, Id);
        }

        public async Task<List<ProductModel>> Products()
        {
           return await _genericProductRepostory.GetAllData();
           // return await _repository.Products();
            //return context.Products();
        }

        public async Task<ProductModel> ProductsById(int Id)
        {
          return await _genericProductRepostory.GetById(Id);
            // return await _genericProductRepository.GetById(Id);
          //  return await _repository.ProductById(Id);
            //  return context.ProductsById(Id);
        }

        public async Task<ProductModel> UpdateProduct(ProductModel productModel)
        {
            await _genericProductRepostory.Update(productModel);
            return productModel;
            // return _repository.Products();
            //return context.Products();
        }

        public async Task<List<ProductModel>> FeaturedProduct()
        {
        return await _productDataRepostory.FeaturedProduct();
        }

        public async Task<List<ProductModel>> BestSellingProducts()
        {
         return await _productDataRepostory.BestSellingProducts();
        }

        public async Task<List<ProductModel>> GetOfferProductById(int id)
        {
          return await  _productDataRepostory.GetOfferProductById(id);
        }

        public async Task<List<ProductModel>> GetBrandById(int id)
        {
        return await _productDataRepostory.GetBrandById(id);
        }

        public async Task<List<ProductModel>> GetCategoryById(int id)
        {
           return await _productDataRepostory.GetCategoryById(id);
        }

        public async Task<List<ProductModel>> GetModelsById(int id)
        {
          return await _productDataRepostory.GetModelsById(id);
        }

        public async Task<List<ProductModel>> SimilarReviewedProduct(int productId)
        {
            return await _productDataRepostory.SimilarReviewedProduct(productId);
        }
    }
}
