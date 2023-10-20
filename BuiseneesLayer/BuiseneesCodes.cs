using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Models;

namespace BuiseneesLayer
{
    public class BuiseneesCodes : IProduct, IUser
    {
        private IDataRepository _repository;
        //private IGenericDataRepostory<UserModel> _genericUserRepository;
        //private IGenericDataRepostory<ProductModel> _genericProductRepository;

        public BuiseneesCodes()
        {
            //_genericUserRepository = new GenericDataRepostiry<UserModel>();
            //_genericProductRepository = new GenericDataRepostiry<ProductModel>();
            _repository = new DataRepository();
        }

        DataContext context = new DataContext();
        //public async Task< string> UserName(int userId)
        //{
        //    return await _repository.UserName(userId);
        //}
        //public async Task<ProductModel> ProductsById(int Id)
        //{
        // // return await _genericProductRepository.GetById(Id);
        //   return await _repository.ProductById(Id);
        //  //  return context.ProductsById(Id);
        //}
        //public async Task<List<ProductModel>> Products()
        //{
        //    return await _repository.Products();
        //    //return context.Products();
        //}
        //public async Task<ProductModel> UpdateProduct(ProductModel productModel)
        //{
        //    return await _repository.UpdateProduct(productModel);
        //   // return _repository.Products();
        //    //return context.Products();
        //}
        //public async Task<ProductModel> PostProduct(ProductModel productModel) {
        //    return await _repository.AddProduct(productModel);
        //}
        //public async Task<List<ProductModel>> ProductCard(int Id)
        //{    
        //    return await _repository.ProductInCart(Id);
        //    //return context.ProductsCard(Id);
        //}
        //public ProductModel UpdateProduct(ProductModel productModel) 
        //{
        //    return context.UpdateProduct(productModel);
        //}
        //public async  Task<UserModel> UpdateUser(UserModel userModel)
        //{
        //    return await _repository.UpdateUser(userModel);
        //    //return context.UpdateUser(userModel);
        //}
        //public async Task<UserModel> User(int Id)
        //{
        //    return await _repository.User(Id);
        //    //return context.User(Id);    
        //}
        //public async  Task<int> LoginUser(string userName, string password)
        //{
        //    return  await _repository.LoginUser(userName, password);
        //   // return context.LoginUser(userName, password);
        //}
        //public async Task<List<ProductModel>> LikeProduct(int userId) 
        //{
        //  return  await _repository.LikeProduct(userId);    
        // //   return context.LikeProduct(userId);
        //}
        //public async Task<List<ProductModel>> KampanyaProduct()
        //{
        //    return await _repository.KampanyaProduct();
        //  //  return context.KampanyaProduct();
        //}
        //public async Task<List<ProductModel>> BuyProduct() 
        //{
        //    return await _repository.BuyProducts();
        ////    return context.BuyProducts();
        //}
        //public async Task<ProductModel> ExaminedProduct(int productId, int userId) 
        //{
        //    return await _repository.ExaminedProduct(productId, userId);
        //   // return context.ExaminedProduct(productId,userId);
        //}
        //public async Task<List<ProductModel>> ExaminedProductAll(int userId) 
        //{
        //    return await _repository.ExaminedProductAll(userId);
        //   // return context.ExaminedProductAll(userId);
        //}
        //public async Task<ProductModel> LikeData(int productId, int userId) 
        //{
        //   return await _repository.LikeData(productId, userId);
        //   // return context.LikeProduct(productId, userId);
        //}
        //public async Task LikedDelete(int productId, int userId) 
        //{
        //    await _repository.LikedDelete(productId, userId); 
        //   // context.LikedDelete(productId,userId);
        //}
        //public void PostProduct(ProductModel productModel)
        //{
        //    context.PostProduct(productModel);
        //}
        //public async Task PostProductInCard(int productId , int userId) 
        //{
        //   await _repository.PostProductInCard(productId, userId);
        //  //  context.PostProductInCard(productId, userId);
        //}
        //public async Task<ProductModel> ProductDeleteInCard(int userId, int Id) 
        //{
        //   return await _repository.ProductDeleteInCard(userId, Id);
        //    // return context.ProductDeleteInCard(userId, Id);
        //}
        //public async Task<ProductModel> BuyProductsUser(int productId, int userId)
        //{
        //    return await _repository.BuyProductsUser(productId, userId);
        //   // return context.BuyProductsUser(productId, userId);
        //}
        //public async Task<List<ProductModel>> BuyProductsGetUser(int userId) 
        //{
        //   return await _repository.BuyProductsGetUser(userId); 
        //   // return context.BuyProductsGetUser(userId);
        //}
        //public async Task PostUser(UserModel userModel)
        //{
        //   await _repository.AddUser(userModel);
        //  //  context.PostUser(userModel);
        //}
        //public async Task UserDelete(int Id)
        //{
        //    await _repository.DeleteUser(Id);
        //   // context.UserDelete(Id);
        //}
        //public async Task ProductDelete(int Id)
        //{
        //  await  _repository.DeleteProduct(Id);
        //   // context.ProductDelete(Id);
        //}

    }
}
