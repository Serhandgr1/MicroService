using AutoMapper;
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
        private readonly IMapper _mapper;
        public ProductDataRepostory(IMapper mapper)
        {
            _mapper = mapper;   
        }
        public async Task<ProductModel> ProductById(int id)
        {
            using (var db = new DataContext())
            {

                bool kt = await db.Products.AnyAsync(x => x.ProductId == id);
                if (kt) { return await db.Products.FindAsync(id); }
                else {  return new ProductModel(); }
            }
        }

        public async Task<List<CategoryModel>> GetAllCategoryName() {

            using (var db = new DataContext())
            {
                var data = await db.Category.ToListAsync();
                return data;
            }
           }
        //Kişinin satın aldığı ürünleri döner
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
        //Kişi ürün satın aldığında BuyProduct tablosuna kaydı atar
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
                    await db.SaveChangesAsync();  
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
        //Kişi ürün incelediğinde  Examined tablosuna kayıt atar
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
        public async Task<LikeDataModel> GetLikeDataUser(int userId  , int productId) 
        {
            using(var db = new DataContext()) 
            {
                 LikeDataModel data =  await db.LikeData.Where(x => x.UserId == userId && x.ProductId == productId).FirstAsync();
                return data;
            }
        }
        //Kişinin incelediği ürünleri döner
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
        //Gelen id li ürünü inceleyenlerin aynı katagoride inceledikleri diğer ürünleri döner
        public async Task<List<ProductModel>> SimilarReviewedProduct(int productId) 
        {
            using(var db = new DataContext()) 
            {
                List<ProductModel> reviewedProduct = new List<ProductModel>();
              ProductModel product=await ProductById(productId);
              var data = await db.Examined.Where(x => x.ProductId == productId).ToListAsync();
                foreach (ExaminedModel examinedModel in data) 
                {
                    int userId = examinedModel.UserId;
                    List<ProductModel> productModels=await ExaminedProductAll(userId);
                    foreach (ProductModel model in productModels) 
                    {
                       bool control= model.CategoryId == product.CategoryId;
                       bool control2 = model.ProductId == productId;
                        if (control && !control2) 
                        {
                            reviewedProduct.Add(model);
                        }
                    }
                }
                List<ProductModel> godata=await ControlProductList(reviewedProduct);
                return godata;
            }
            
        }
        //Kişinin beğendiği ürünleri döner
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
        //Kategorye göre ürünleri listeler (Teknoloji kategorisinde bulunan ürünleri getir gibi)
        public async Task<List<ProductModel>> GetCategoryById(int id) 
        {
            using (var db = new DataContext()) 
            {
                List<ProductModel> categoryModels = new List<ProductModel>();   
                bool control = await db.Products.AnyAsync(x=>x.CategoryId == id);
                if (control) 
                {
                    var data = await db.Products.Where(x => x.CategoryId == id).ToListAsync();
                    categoryModels.AddRange(data);
                }
                return categoryModels;
            }
        }
        // Modele göre ürünlerin listesini döner
        public async Task<List<ProductModel>> GetModelsById(int id) 
        {
            using (var db = new DataContext())
            {
                List<ProductModel> modelsData = new List<ProductModel>();
                bool control = await db.Products.AnyAsync( x=>x.ModelId == id);
                if (control) 
                {
                    var data = await db.Products.Where(x => x.ModelId == id).ToListAsync();
                    modelsData.AddRange(data);
                }
                return modelsData;
            }
        }
        //Markaya göre ürünleri listeler
        public async Task<List<ProductModel>> GetBrandById(int id) 
        {
            using (var db = new DataContext())
            {
                List<ProductModel> brandData = new List<ProductModel>();
                bool control = await db.Products.AnyAsync (x=>x.BrandId == id);
                if (control) 
                {
                    var data = await db.Products.Where(x => x.BrandId == id).ToListAsync();
                    brandData.AddRange(data);
                }
                return brandData;
            }
        }
        // Kategorye göre kampanyalı ürünleri döndürür 
        public async Task<List<ProductModel>> GetOfferProductById(int id) 
        {
            using (var db = new DataContext()) 
            {
                List<ProductModel> offerData = new List<ProductModel>();
                List<ProductModel> product = new List<ProductModel>();
                bool control = await db.Products.AnyAsync(x => x.CategoryId == id);
                if (control) 
                {
                    var data = await db.Kampanyalar.ToListAsync();
                    foreach (KampanyaProductModel kampanya in data) 
                    {
                        product.Add(await ProductById(kampanya.ProductId));
                    }
                    foreach (ProductModel productModel in product) 
                    {
                        if (productModel.CategoryId == id) 
                        {
                            //KT
                           // var kampanya= _mapper.Map<KampanyaProductModel>(productModel);
                            offerData.Add(productModel);
                        }
                    }
                }
                return offerData;   
            }
        
        }
        //Kişinin sepetini döner
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
        // Gelen Ürünü satın alanların satın aldığı diğer ürünleri döner
        public async Task<List<ProductModel>> SimilarProducts(int productId)
        {
            using (var db = new DataContext()) 
            {
                List <ProductModel> returndata = new List<ProductModel>();
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
        //buyproduct , likedata , examined tablolarında bulunan ürünleri bir araya getirip tekrar eden idleri teke düşürerek öne çıkan ürünleri bulmamızı sağlar
        public async Task<List<ProductModel>> FeaturedProduct() 
        {
            using (var db = new DataContext())
            {
                List<ProductModel> productModels = new List<ProductModel>();
                List<int> productId= new List<int>();
                var examined = await db.Examined.ToListAsync();
                foreach (ExaminedModel model in examined) 
                {
                    productId.Add(model.ProductId);
                }
                var buyproduct = await db.BuyProduct.ToListAsync();
                foreach (BuyProductModel model in buyproduct)
                {
                    productId.Add(model.ProductId);
                }
                var likedata = await db.LikeData.ToListAsync();
                foreach (LikeDataModel model in likedata)
                {
                    productId.Add(model.ProductId);
                }
                List<int> donus = await ControlProductIdList(productId);
                foreach (int id in donus) 
                {
                    productModels.Add(await ProductById(id));
                }
                //  ProductModel data =  _mapper.Map<ProductModel>(likedata);
                // var godata =  await RepeatedProduct(data);
                return productModels;
            }
        }
        // liste içerisinde 1den fazla tekrarlanan elemanların listesini döner
        public async Task<List<ProductModel>> RepeatedProduct(List<ProductModel> product) 
        {
            List<ProductModel> productModels1 = new List<ProductModel>();
            List<ProductModel> productModels2 = new List<ProductModel>(); // tekrarlananlar
            productModels1.AddRange(product);
            foreach (ProductModel productModel in product)
            {
                int id = productModel.ProductId;
                productModels1.Remove(productModel);
                foreach (ProductModel productModel1 in productModels1)
                {
                    bool controlId = productModel1.ProductId == id;
                    if (controlId)
                    {
                        productModels2.Add(productModel1);
                    }
                }
            }

            return productModels2;
        }
        //Çok satan ürünleri döner // buyproduct tablosunda 1den fazla kez satın alınmış ürünlerin listesini döner
        public async Task<List<ProductModel>> BestSellingProducts() 
        {
            using (var db = new DataContext()) 
            {
                List<int> buylistId = new List<int>();
                List<ProductModel> productModels = new List<ProductModel>();
                var buylis= await db.BuyProduct.ToListAsync();
                foreach (BuyProductModel productModel in buylis) 
                {
                    buylistId.Add(productModel.ProductId);
                }
                foreach (int id in buylistId)
                {
                    productModels.Add(await ProductById(id));
                }
                List<ProductModel> controlmodel= await RepeatedProduct(productModels);
                List<ProductModel> productModels1= await ControlProductList(controlmodel);
                //List<int> datalist = await RepeatedProductLikedata(buylistId);
                //List<int> data=await ControlProductIdList(datalist);
               
                return productModels1;
            }
        }
        public async Task<List<int>> RepeatedProductLikedata(List<int> product)
        {
            List<int> productModels1 = new List<int>();
            List<int> productModels2 = new List<int>(); // tekrarlananlar
            productModels1.AddRange(product);
            foreach (int productModel in product)
            {
                int id = productModel;
                productModels1.Remove(productModel);
                foreach (int productModel1 in productModels1)
                {
                    bool controlId = productModel1 == id;
                    if (controlId)
                    {
                        productModels2.Add(productModel1);
                    }
                }
            }

            return productModels2;
        }

        //listede aynı id den 1den fazla mevcut ise tek hale getirerek listeyi geri döner
        public async Task<List<ProductModel>> ControlProductList(List<ProductModel> product) 
        {
            List <ProductModel> productModels2 = await RepeatedProduct(product);
            foreach (ProductModel product1 in productModels2) 
            {

                product.Remove(product1);
            }
           return product;
        }
        public async Task<List<int>> ControlProductIdList(List<int> productId)
        {
            List<int> data = await RepeatedProductLikedata(productId);
            List<int> productModels2 = new List<int>();
            productModels2.AddRange(data);
            foreach (int product1 in productModels2)
            {

                productId.Remove(product1);
            }
            return productId;
        }
    }
}
