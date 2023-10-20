using DataAccessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.Concrete
{
    public class ProductDataRepostory : IProductDataRepostory
    {
        public async Task<ProductModel> ProductById(int id)
        {
            using (var db = new DataContext())
            {

                bool kt = await db.Products.AnyAsync(x => x.ProductId == id);
                if (kt) { return await db.Products.FindAsync(id); }
                else {  return new ProductModel(); }
            }
        }
        public async Task<List<ProductModel>> BuyProductsGetUser(int userId)
        {

            using (var db = new DataContext())
            {
                List<ProductModel> productModels = new List<ProductModel>();
                bool kt = await db.Users.AnyAsync(x => x.UserId == userId);
                if (kt)
                {
                    var data = await db.BuyProduct.Where(x => x.UserId == userId).ToListAsync();
                    foreach (BuyProductModel model in data)
                    {
                        productModels.Add(await ProductById(model.ProductId));
                    }

                    return productModels;
                }
                else return productModels;

            }
        }

        public async Task<ProductModel> BuyProductsUser(int productId, int userId)
        {
            BuyProductModel model = new BuyProductModel();
            model.ProductId = productId;
            model.UserId = userId;
            using (var db = new DataContext())
            {
                bool kt = await db.Products.AnyAsync(x => x.ProductId == productId);
                bool kt2 = await db.Users.AnyAsync(x => x.UserId == userId);
                if (kt && kt2)
                {
                    await db.BuyProduct.AddAsync(model);
                    //ürün satıldığında stok kontrolü yap stok 20 den az ise bu ürünü sepetinde bulunduran kullanıcılara mail at stok 10 dan az ise stok güncelle 
                    return await ProductById(productId);
                }
                else
                {
                    ProductModel productModel = new ProductModel();
                    return productModel;
                }

            }
        }

        public async Task<ProductModel> ExaminedProduct(int productId, int userId)
        {
            using (var db = new DataContext())
            {
                ExaminedModel examinedModel = new ExaminedModel();
                bool kt = await db.Products.AnyAsync(x => x.ProductId == productId);
                bool kt2 = await db.Users.AnyAsync(x => x.UserId == userId);
                if (kt && kt2)
                {
                    examinedModel.ProductId = productId;
                    examinedModel.UserId = userId;
                    await db.Examined.AddAsync(examinedModel);
                    await db.SaveChangesAsync();
                    return await ProductById(productId);
                }
                else
                {
                    ProductModel model = new ProductModel();
                    return model;
                }


            }
        }
        public async Task<List<ProductModel>> ExaminedProductAll(int userId)
        {
            using (var db = new DataContext())
            {
                List<ProductModel> productModels = new List<ProductModel>();
                bool kt = await db.Users.AnyAsync(x => x.UserId == userId);
                if (kt)
                {
                    var data = await db.Examined.Where(x => x.UserId == userId).ToListAsync();
                    foreach (ExaminedModel model in data)
                    {
                        productModels.Add(await ProductById(model.ProductId));
                    }
                    return productModels;
                }
                else return productModels;

            }
        }

        public async Task<List<ProductModel>> LikeProduct(int userId)
        {
            using (var db = new DataContext())
            {
                List<LikeDataModel> likeDataModels = new List<LikeDataModel>();
                List<ProductModel> productModels = new List<ProductModel>();
                bool kt = await db.Users.AnyAsync(x => x.UserId == userId);
                if (kt)
                {
                    var data = await db.LikeData.Where(x => x.UserId == userId).ToListAsync();
                    foreach (LikeDataModel model in data)
                    {
                        productModels.Add(await ProductById(model.ProductId));
                    }

                    return productModels;
                }
                else return productModels;
            }

        }

        public async Task<List<ProductModel>> ProductCard(int id)
        {
            using (var db = new DataContext())
            {
                List<ProductModel> productModels = new List<ProductModel>();
                bool kt = await db.Users.AnyAsync(x => x.UserId == id);
                if (kt)
                {
                    var data = await db.ProductsInCart.Where(x => x.UserId == id).ToListAsync();
                    foreach (ProductsInCartModel model in data)
                    {
                        productModels.Add(await ProductById(model.ProductId));
                    }
                    return productModels;
                }
                return productModels;

            }
        }

        public async Task<List<ProductModel>> SimilarProducts(int productId)
        {
            using (var db = new DataContext()) 
            {
                List < ProductModel > returndata = new List<ProductModel>();
               bool control = await db.BuyProduct.AnyAsync(x => x.ProductId == productId);
                if (control) 
                {
                    List<ProductModel> productModel = new List<ProductModel>();
                    var data = await db.BuyProduct.Where(x => x.ProductId == productId).ToListAsync();
                    foreach (BuyProductModel model in data) 
                    {
                        var userdata = await db.BuyProduct.Where(x => x.UserId == model.UserId).ToListAsync();
                        foreach (BuyProductModel productModel1 in userdata) 
                        {
                            var godata=  productModel1.ProductId == productId;
                            if (!godata) 
                            {
                               productModel.Add(await ProductById(productModel1.ProductId)); 
                            }
                        }
                    }
                  returndata=await  ControlProductList(productModel); ///  liste içerisinde aynı id ye sahip birden fazla data var ise tek hale getirecek ve her data 1 defa yer almış olacak
                }
                return returndata;
              
            }
        }

        //listede aynı id den 1den fazla mevcut ise tek hale getirerek listeyi geri döner
        public async Task<List<ProductModel>> ControlProductList(List<ProductModel> product) 
        {
            List<ProductModel> productModels1 = new List<ProductModel>();
            List<ProductModel> productModels2 = new List<ProductModel>(); // silinecekler
            productModels1.AddRange(product);
            foreach (ProductModel productModel in product) 
            {
                int id = productModel.ProductId;
                productModels1.Remove(productModel);
                foreach (ProductModel productModel1 in productModels1) 
                {
                   bool controlId= productModel1.ProductId == id;
                    if (controlId) 
                    {
                        productModels2.Add(productModel1);
                    }
                }
            }
            foreach (ProductModel product1 in productModels2) 
            {

                product.Remove(product1);
            }
           return product;
        }
    }
}
