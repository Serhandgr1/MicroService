using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=E_COMMERCE;TrustServerCertificate=true;Trusted_Connection=True;Max Pool Size=500;");
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProductsInCartModel> ProductsInCart { get; set; }
        public DbSet<BuyProductModel> BuyProduct { get; set; }
        public DbSet<LikeDataModel> LikeData { get; set; }
        public DbSet<KampanyaProductModel> Kampanyalar { get; set; }
        public DbSet<ExaminedModel> Examined { get; set; }
        public DbSet<CategoryModel> Category { get; set; }


        // IConfiguration configuration;
        //public SqlConnection DbSqlConnection()
        //    {

        //       // configuration.GetConnectionString("DefaultConnection");
        //        SqlConnection sqlConnection = new SqlConnection(@"Your ConnectionString");
        //        sqlConnection.Open();
        //        return sqlConnection;

        //    }
        //    public SqlCommand CreateCommand(string query)
        //    {
        //        SqlCommand sqlCommand = new SqlCommand(query, DbSqlConnection());
        //        return sqlCommand;
        //    }
        //public ProductModel ProductsById(int Id)
        //{
        //    ProductModel product = new ProductModel();
        //    string query = "SELECT * FROM Products WHERE ProductId=@ProductId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@ProductId", Id);
        //    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    while (reader.Read())
        //    {
        //        product.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
        //        product.ProductName = reader["ProductName"].ToString();
        //        product.ProductDetail = reader["ProductDetail"].ToString();
        //        product.Price = Convert.ToDecimal(reader["Price"].ToString());
        //        product.BrandId = Convert.ToInt32(reader["BrandId"].ToString());
        //        product.CategoryId = Convert.ToInt32(reader["CategoryId"].ToString());
        //        product.ModelId = Convert.ToInt32(reader["ModelId"].ToString());
        //        product.ProductImage = reader["ProductImage"].ToString();
        //        product.ProductOzet = reader["ProductOzet"].ToString();
        //        product.Stock = Convert.ToInt32(reader["Stock"].ToString());
        //    }
        //    return product;
        //}
        //public ProductModel UpdateProduct(ProductModel productModel) 
        //{
        //    string query = "UPDATE Products SET ProductName=@ProductName , Price=@Price , CategoryId=@CategoryId , BrandId=@BrandId , ModelId=@ModelId , Stock=@Stock , ProductDetail=@ProductDetail, ProductImage=@ProductImage , ProductOzet=@ProductOzet WHERE ProductId=@ProductId";   
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@ProductId", productModel.ProductId);
        //    command.Parameters.AddWithValue("@ProductName" , productModel.ProductName);
        //    command.Parameters.AddWithValue("@Price", productModel.Price);
        //    command.Parameters.AddWithValue("@CategoryId", productModel.CategoryId);
        //    command.Parameters.AddWithValue("@BrandId", productModel.BrandId);
        //    command.Parameters.AddWithValue("@ModelId", productModel.ModelId);
        //    command.Parameters.AddWithValue("@Stock", productModel.Stock);
        //    command.Parameters.AddWithValue("@ProductDetail", productModel.ProductDetail);
        //    command.Parameters.AddWithValue("@ProductImage", productModel.ProductImage);
        //    command.Parameters.AddWithValue("@ProductOzet", productModel.ProductOzet);
        //    command.ExecuteNonQuery();
        //    return productModel;
        //}
        //public UserModel UpdateUser(UserModel userModel)
        //{
        //    string query = "UPDATE Users SET UserName=@UserName , Name=@Name , Surname=@Surname , E_Mail=@E_Mail , Password=@Password , RoleId=@RoleId WHERE UserId=@UserId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@UserId", userModel.UserId);
        //    command.Parameters.AddWithValue("@UserName", userModel.UserName);
        //    command.Parameters.AddWithValue("@Name", userModel.Name);
        //    command.Parameters.AddWithValue("@Surname", userModel.Surname);
        //    command.Parameters.AddWithValue("@E_Mail", userModel.E_Mail);
        //    command.Parameters.AddWithValue("@Password", userModel.Password);
        //    command.Parameters.AddWithValue("@RoleId", userModel.RoleId);
        //    command.ExecuteNonQuery();
        //    return userModel;
        //}
        //public List<ProductModel> Products()
        //{
        //   List<ProductModel> productsModel = new List<ProductModel>();
        //    string query = "SELECT * FROM Products";
        //    SqlCommand command = CreateCommand(query);
        //    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    while (reader.Read())
        //    {
        //        ProductModel product = new ProductModel();
        //        product.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
        //        product.ProductName = reader["ProductName"].ToString();
        //        product.ProductDetail = reader["ProductDetail"].ToString();
        //        product.Price = Convert.ToDecimal(reader["Price"].ToString());
        //        product.BrandId = Convert.ToInt32(reader["BrandId"].ToString());
        //        product.CategoryId = Convert.ToInt32(reader["CategoryId"].ToString());
        //        product.ModelId = Convert.ToInt32(reader["ModelId"].ToString());
        //        product.ProductImage = reader["ProductImage"].ToString();
        //        product.ProductOzet = reader["ProductOzet"].ToString();
        //        product.Stock = Convert.ToInt32(reader["Stock"].ToString());
        //        productsModel.Add(product);
        //    }


        //    //using (var DataContext = new DataContext())
        //    //{
        //    //    productsModel.Add( DataContext. ToList());
        //    //    return productsModel
        //    //}

        //    return productsModel;
        //}

        //public List<ProductModel> ProductsCard(int Id)
        //{
        //    List<ProductModel> productsModel = new List<ProductModel>();
        //    string query = "SELECT ProductId FROM ProductsInCart WHERE UserId=@UserId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@UserId", Id);
        //    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    while (reader.Read())
        //    {
        //        int id = Convert.ToInt32(reader["ProductId"].ToString());
        //        productsModel.Add(ProductsById(id));
        //    }
        //    return productsModel;
        //}
        //public ProductModel BuyProductsUser(int productId, int userId) 
        //{
        //    string query = "INSERT INTO BuyProduct (ProductId , UserId) VALUES (@ProductId, @UserId)";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@ProductId" , productId);
        //    command.Parameters.AddWithValue("@UserId" , userId);
        //    command.ExecuteNonQuery();
        //    ProductDeleteInCard(userId, productId);
        //    return ProductsById(productId);

        //}
        //public List<ProductModel> BuyProductsGetUser(int userId) 
        //{
        //    List<ProductModel> buyProduct = new List<ProductModel>();
        //    string query = "SELECT ProductId FROM BuyProduct WHERE UserId=@UserId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@UserId", userId);
        //    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    while (reader.Read()) 
        //    {
        //        int id = Convert.ToInt32(reader["ProductId"].ToString());
        //        buyProduct.Add(ProductsById(id));
        //    }
        //    return buyProduct;

        //}
        //public ProductModel LikeProduct(int productId, int userId) 
        //{
        //    string query = "INSERT INTO LikeData (UserId , ProductId) VALUES (@UserId , @ProductId)";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@ProductId", productId);
        //    command.Parameters.AddWithValue("@UserId", userId);
        //    command.ExecuteNonQuery();
        //    return ProductsById(productId);

        //}
        //public List<ProductModel> LikeProduct(int Id)
        //{
        //    List<ProductModel> productsModel = new List<ProductModel>();
        //    string query = "SELECT ProductId FROM LikeData WHERE UserId=@UserId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@UserId", Id);
        //    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    while (reader.Read())
        //    {
        //        int id = Convert.ToInt32(reader["ProductId"].ToString());
        //        productsModel.Add(ProductsById(id));
        //    }
        //    return productsModel;
        //}
        //public void LikedDelete(int productId, int userId) 
        //{
        //    string query = "DELETE FROM LikeData WHERE ProductId=@ProductId AND UserId=@UserId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@ProductId", productId);
        //    command.Parameters.AddWithValue("@UserId", userId);
        //    command.ExecuteNonQuery();
        //}
        //public List<ProductModel> KampanyaProduct() 
        //{
        //    List<ProductModel> kampanya = new List<ProductModel>();
        //    string query = "SELECT ProductId FROM Kampanyalar";
        //    SqlCommand command = CreateCommand(query);
        //    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    while (reader.Read()) 
        //    {
        //        int id = Convert.ToInt32(reader["ProductId"].ToString());
        //        kampanya.Add(ProductsById(id));
        //    }
        //    return kampanya;
        //}

        //public List<ProductModel> BuyProducts()
        //{
        //    List<ProductModel> buyProduct = new List<ProductModel>();
        //    string query = "SELECT ProductId FROM BuyProduct";
        //    SqlCommand command = CreateCommand(query);
        //    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    while (reader.Read())
        //    {
        //        int id = Convert.ToInt32(reader["ProductId"].ToString());
        //        buyProduct.Add(ProductsById(id));
        //    }
        //    return buyProduct;
        //}
        //public ProductModel ExaminedProduct(int productId, int userId) 
        //{
        //    string query = "INSERT INTO Examined (ProductId,UserId) VALUES (@ProductId ,@UserId)";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@ProductId" , productId);
        //    command.Parameters.AddWithValue("@UserId" , userId);
        //    command.ExecuteNonQuery();
        //    return ProductsById(productId);
        //}
        //public List<ProductModel> ExaminedProductAll(int userId) 
        //{
        //    List<ProductModel> productModels = new List<ProductModel>();
        //    string query = "SELECT ProductId FROM Examined WHERE UserId=@UserId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@UserId" , userId);
        //    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    while (reader.Read()) 
        //    {
        //        int id = Convert.ToInt32(reader["ProductId"].ToString());
        //        productModels.Add(ProductsById(id)); 
        //    }
        //    return productModels;

        //}
        //public UserModel User(int Id)
        //{
        //    UserModel user = new UserModel();
        //    string query = "SELECT * FROM Users WHERE UserId=@UserId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@UserId", Id);
        //    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    while (reader.Read())
        //    {
        //        user.UserId = Convert.ToInt32(reader["UserId"].ToString());
        //        user.UserName = reader["UserName"].ToString();
        //        user.Name = reader["Name"].ToString();
        //        user.Surname = reader["Surname"].ToString();
        //        user.E_Mail= reader["E_Mail"].ToString();
        //        user.Password = reader["Password"].ToString();
        //        user.RoleId = Convert.ToInt32(reader["RoleId"].ToString());
        //        return user;
        //    }
        //    return user;

        //}
        //public ProductModel ProductDeleteInCard(int userId ,int Id) 
        //{
        //    string query = "DELETE FROM ProductsInCart WHERE UserId=@UserId AND ProductId=@ProductId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@ProductId" , Id);
        //    command.Parameters.AddWithValue("@UserId", userId);
        //    command.ExecuteNonQuery();
        //    return ProductsById(Id);
        //}
        //public int LoginUser(string userName , string password) 
        //{
        //    int userId = 0;
        //    string query = "SELECT UserId FROM Users WHERE UserName=@UserName AND Password=@Password";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@UserName", userName);
        //    command.Parameters.AddWithValue ("@Password", password);
        //    command.ExecuteNonQuery();
        //    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    while (reader.Read())
        //    {
        //        userId= Convert.ToInt32(reader["UserId"].ToString());
        //    }
        //    return userId;
        //}
        //public void PostProduct(ProductModel productModel) 
        //{
        //    string query = "INSERT INTO Products (ProductName , Price , CategoryId , BrandId , ModelId , Stock , ProductDetail, ProductImage , ProductOzet) VALUES (@ProductName,@Price,@CategoryId,@BrandId,@ModelId,@Stock,@ProductDetail,@ProductImage,@ProductOzet)";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@ProductName", productModel.ProductName);
        //    command.Parameters.AddWithValue("@Price", productModel.Price);
        //    command.Parameters.AddWithValue("@CategoryId", productModel.CategoryId);
        //    command.Parameters.AddWithValue("@BrandId", productModel.BrandId);
        //    command.Parameters.AddWithValue("@ModelId", productModel.ModelId);
        //    command.Parameters.AddWithValue("@Stock", productModel.Stock);
        //    command.Parameters.AddWithValue("@ProductDetail", productModel.ProductDetail);
        //    command.Parameters.AddWithValue("@ProductImage", productModel.ProductImage);
        //    command.Parameters.AddWithValue("@ProductOzet", productModel.ProductOzet);
        //    command.ExecuteNonQuery();

        //}
        //public void PostProductInCard(int productId,int userId) 
        //{
        //    string query = "INSERT INTO ProductsInCart (UserId,ProductId) VALUES (@UserId,@ProductId)";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@UserId", userId);
        //    command.Parameters.AddWithValue("@ProductId",productId);
        //    command.ExecuteNonQuery();

        //}
        //public void PostUser(UserModel userModel)
        //{
        //    string query = "INSERT INTO Users (UserName , Name , Surname , E_Mail , Password , RoleId) VALUES (@UserName,@Name,@Surname,@E_Mail,@Password,@RoleId)";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@UserName", userModel.UserName);
        //    command.Parameters.AddWithValue("@Name", userModel.Name);
        //    command.Parameters.AddWithValue("@Surname", userModel.Surname);
        //    command.Parameters.AddWithValue("@E_Mail", userModel.E_Mail);
        //    command.Parameters.AddWithValue("@Password", userModel.Password);
        //    command.Parameters.AddWithValue("@RoleId", userModel.RoleId);
        //    command.ExecuteNonQuery();
        //}
        //public void UserDelete(int Id)
        //{
        //    string query = "DELETE FROM Users WHERE UserId=@UserId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@UserId", Id);
        //    command.ExecuteNonQuery();
        //}
        //public void ProductDelete(int Id)
        //{
        //    string query = "DELETE FROM Products WHERE ProductId=@ProductId";
        //    SqlCommand command = CreateCommand(query);
        //    command.Parameters.AddWithValue("@ProductId", Id);
        //    command.ExecuteNonQuery();
        //}
    }
}

