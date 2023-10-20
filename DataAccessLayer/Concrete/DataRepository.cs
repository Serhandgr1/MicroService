using DataAccessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class DataRepository : IDataRepository
    {
        //public async Task<ProductModel> ProductById(int id)
        //{
        //    using (var db = new DataContext())
        //    {

        //        bool kt = await db.Products.AnyAsync(x => x.ProductId == id);
        //        if (kt) { return await db.Products.FindAsync(id); }
        //        else { ProductModel productModel = new ProductModel(); return productModel; }
        //    }
        //}

        //public async Task<List<ProductModel>> Products()
        //{
        //    using (var db = new DataContext()) { return await db.Products.ToListAsync(); }
        //}
        //public async Task<List<ProductModel>> ProductInCart(int id)
        //{
        //    using (var db = new DataContext())
        //    {
        //        List<ProductModel> productModels = new List<ProductModel>();
        //        bool kt = await db.Users.AnyAsync(x => x.UserId == id);
        //        if (kt)
        //        {
        //            var data = await db.ProductsInCart.Where(x => x.UserId == id).ToListAsync();
        //            foreach (ProductsInCartModel model in data)
        //            {
        //                productModels.Add(await ProductById(model.ProductId));
        //            }
        //            return productModels;
        //        }
        //        return productModels;

        //    }
        //}
        //public async Task<ProductModel> BuyProductsUser(int productId, int userId)
        //{
        //    BuyProductModel model = new BuyProductModel();
        //    model.ProductId = productId;
        //    model.UserId = userId;
        //    using (var db = new DataContext())
        //    {
        //        bool kt = await db.Products.AnyAsync(x => x.ProductId == productId);
        //        bool kt2 = await db.Users.AnyAsync(x => x.UserId == userId);
        //        if (kt && kt2)
        //        {
        //            await db.BuyProduct.AddAsync(model);
        //            //ürün satıldığında stok kontrolü yap stok 20 den az ise bu ürünü sepetinde bulunduran kullanıcılara mail at stok 10 dan az ise stok güncelle 
        //            return await ProductById(productId);
        //        }
        //        else
        //        {
        //            ProductModel productModel = new ProductModel();
        //            return productModel;
        //        }

        //    }
        //}
        //public async Task<List<ProductModel>> BuyProductsGetUser(int userId)
        //{

        //    using (var db = new DataContext())
        //    {
        //        List<ProductModel> productModels = new List<ProductModel>();
        //        bool kt = await db.Users.AnyAsync(x => x.UserId == userId);
        //        if (kt)
        //        {
        //            var data = await db.BuyProduct.Where(x => x.UserId == userId).ToListAsync();
        //            foreach (BuyProductModel model in data)
        //            {
        //                productModels.Add(await ProductById(model.ProductId));
        //            }

        //            return productModels;
        //        }
        //        else return productModels;

        //    }
        //}
        //public async Task<ProductModel> UpdateProduct(ProductModel productModel)
        //{
        //    using (var db = new DataContext())
        //    {
        //        bool kt = await db.Products.AnyAsync(x => x.ProductId == productModel.ProductId);
        //        if (kt)
        //        {
        //            db.Products.Update(productModel);
        //            await db.SaveChangesAsync();
        //            return productModel;
        //        }
        //        else return productModel;
        //    }
        //}
        //public async Task<ProductModel> AddProduct(ProductModel productModel)
        //{
        //    using (var db = new DataContext()) { await db.Products.AddAsync(productModel); return productModel; }
        //}

        //public async Task<UserModel> User(int id)
        //{
        //    using (var db = new DataContext())
        //    {

        //        bool kt = await db.Users.AnyAsync(x => x.UserId == id);
        //        if (kt)
        //        {
        //            return await db.Users.FindAsync(id);
        //        }
        //        else
        //        {
        //            UserModel userModel = new UserModel();
        //            return userModel;
        //        }

        //    }
        //}

        //public async Task<UserModel> UpdateUser(UserModel userModel)
        //{
        //    using (var db = new DataContext())
        //    {

        //        bool kt = await db.Users.AnyAsync(x => x.UserId == userModel.UserId);
        //        if (kt)
        //        {
        //            db.Users.Update(userModel); return userModel;
        //        }
        //        else
        //        {
        //            UserModel user = new UserModel();
        //            return user;
        //        }

        //    }
        //}

        //public async Task AddUser(UserModel userModel)
        //{
        //    using (var db = new DataContext()) { await db.Users.AddAsync(userModel); }
        //}
        //public async Task DeleteUser(int id)
        //{
        //    using (var db = new DataContext())
        //    {
        //        bool kt = await db.Users.AnyAsync(x => x.UserId == id);
        //        if (kt)
        //        {
        //            var deleteUser = await User(id);
        //            db.Users.Remove(deleteUser);
        //            await db.SaveChangesAsync();
        //        }
        //    }
        //}

        //public async Task DeleteProduct(int id)
        //{
        //    using (var db = new DataContext())
        //    {
        //        bool kt = await db.Products.AnyAsync(x => x.ProductId == id);
        //        if (kt)
        //        {
        //            var deleteProduct = await ProductById(id);
        //            db.Products.Remove(deleteProduct);
        //            await db.SaveChangesAsync();
        //        }
        //    }
        //}

        //public async Task<ProductModel> LikeData(int productId, int userId)
        //{
        //    using (var db = new DataContext())
        //    {
        //        LikeDataModel likeData = new LikeDataModel();
        //        bool kt = await db.Products.AnyAsync(x => x.ProductId == productId);
        //        bool kt2 = await db.Users.AnyAsync(x => x.UserId == userId);
        //        if (kt && kt2)
        //        {
        //            likeData.ProductId = productId;
        //            likeData.UserId = userId;
        //            await db.LikeData.AddAsync(likeData);
        //            await db.SaveChangesAsync();
        //            return await ProductById(likeData.ProductId);
        //        }
        //        else { ProductModel productModel = new ProductModel(); return productModel; }

        //    }
        //}
        //public async Task<List<ProductModel>> LikeProduct(int userId)
        //{
        //    using (var db = new DataContext())
        //    {
        //        List<LikeDataModel> likeDataModels = new List<LikeDataModel>();
        //        List<ProductModel> productModels = new List<ProductModel>();
        //        bool kt = await db.Users.AnyAsync(x => x.UserId == userId);
        //        if (kt)
        //        {
        //            var data = await db.LikeData.Where(x => x.UserId == userId).ToListAsync();
        //            foreach (LikeDataModel model in data)
        //            {
        //                productModels.Add(await ProductById(model.ProductId));
        //            }

        //            return productModels;
        //        }
        //        else return productModels;
        //    }

        //}
        //public async Task LikedDelete(int productId, int userId)
        //{
        //    using (var db = new DataContext())
        //    {

        //        bool kt = await db.Products.AnyAsync(x => x.ProductId == productId);
        //        bool kt2 = await db.Users.AnyAsync(x => x.UserId == userId);
        //        if (kt && kt2)
        //        {
        //            var data= await db.LikeData.Where(x => x.ProductId == productId && x.UserId == userId).ToListAsync();
        //            foreach (LikeDataModel model in data) 
        //            {
        //                db.LikeData.Remove(model);
        //                await db.SaveChangesAsync();
        //            }
        //        }

        //    }
        //}
        //public async Task<ProductModel> ProductDeleteInCard(int userId, int productId)
        //{
        //    using (var db = new DataContext())
        //    {
        //        bool kt = await db.Products.AnyAsync(x => x.ProductId == productId);
        //        bool kt2 = await db.Users.AnyAsync(x => x.UserId == userId);
        //        if (kt && kt2)
        //        {
        //            var data= await db.ProductsInCart.Where(x => x.UserId==userId && x.ProductId==productId).ToListAsync();
        //            foreach (ProductsInCartModel model in data) 
        //            {
        //                db.ProductsInCart.Remove(model);
        //                await db.SaveChangesAsync();
        //            }

        //            return await ProductById(productId);
        //        }
        //        else
        //        {
        //            ProductModel productModel = new ProductModel();
        //            return productModel;
        //        }
        //    }
        //}
        //public async Task PostProductInCard(int productId, int userId)
        //{
        //    using (var db = new DataContext())
        //    {
        //        bool kt = await db.Products.AnyAsync(x => x.ProductId == productId);
        //        bool kt2 = await db.Users.AnyAsync(x => x.UserId == userId);
        //        if (kt && kt2)
        //        {
        //            ProductsInCartModel productsInCartModel = new ProductsInCartModel();
        //            productsInCartModel.ProductId = productId;
        //            productsInCartModel.UserId = userId;
        //            await db.ProductsInCart.AddAsync(productsInCartModel);
        //            await db.SaveChangesAsync();
        //        }
        //    }
        //}
        //public async Task<List<ProductModel>> BuyProducts()
        //{
        //    using (var db = new DataContext())
        //    {
        //        List<ProductModel> productModels = new List<ProductModel>();
        //        var data = await db.BuyProduct.ToListAsync();
        //        foreach (BuyProductModel pro in data)
        //        {
        //            productModels.Add(await ProductById(pro.ProductId));
        //        }
        //        return productModels;
        //    }
        //}
        //public async Task<List<ProductModel>> KampanyaProduct()
        //{
        //    using (var db = new DataContext())
        //    {
        //        List<ProductModel> productModels = new List<ProductModel>();
        //        var data = await db.Kampanyalar.ToListAsync();
        //        foreach (KampanyaProductModel pro in data)
        //        {
        //            productModels.Add(await ProductById(pro.ProductId));
        //        }
        //        return productModels;
        //    }
        //}
        //public async Task<ProductModel> ExaminedProduct(int productId, int userId)
        //{
        //    using (var db = new DataContext())
        //    {
        //        ExaminedModel examinedModel = new ExaminedModel();
        //        bool kt = await db.Products.AnyAsync(x => x.ProductId == productId);
        //        bool kt2 = await db.Users.AnyAsync(x => x.UserId == userId);
        //        if (kt && kt2)
        //        {
        //            examinedModel.ProductId = productId;
        //            examinedModel.UserId = userId;
        //            await db.Examined.AddAsync(examinedModel);
        //            await db.SaveChangesAsync();
        //            return await ProductById(productId);
        //        }
        //        else
        //        {
        //            ProductModel model = new ProductModel();
        //            return model;
        //        }


        //    }
        //}
        //public async Task<List<ProductModel>> ExaminedProductAll(int userId)
        //{
        //    using (var db = new DataContext())
        //    {
        //        List<ProductModel> productModels = new List<ProductModel>();
        //        bool kt = await db.Users.AnyAsync(x => x.UserId == userId);
        //        if (kt)
        //        {
        //            var data = await db.Examined.Where(x => x.UserId == userId).ToListAsync();
        //            foreach (ExaminedModel model in data)
        //            {
        //                productModels.Add(await ProductById(model.ProductId));
        //            }
        //            return productModels;
        //        }
        //        else return productModels;

        //    }
        //}
        //public async Task<int> LoginUser(string userName, string password)
        //{
        //    using (var db = new DataContext())
        //    {
        //        int id = 0;
        //        var data = await db.Users.Where(x => x.UserName == userName && x.Password == password).ToListAsync();
        //        foreach (UserModel model in data)
        //        {
        //            id = model.UserId;
        //        }
        //        return id;
        //    }
        //}
        //public async Task<string> UserName(int userId)
        //{
        //    using (var db = new DataContext())
        //    {
        //        string name = "Kullanıcı bulunamadı";
        //        var data = await db.Users.Where(x => x.UserId == userId).ToListAsync();
        //        foreach (UserModel model in data)
        //        {
        //            return model.Name;
        //        }
        //        return name;
        //    }
        //}
    }
}
