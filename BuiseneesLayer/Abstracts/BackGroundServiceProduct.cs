using DataAccessLayer;
using DataAccessLayer.Abstract;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuiseneesLayer.Contracts;

namespace BuiseneesLayer
{
    public class BackGroundServiceProduct : BackgroundService
    {
        private readonly IBackGroundServiceProduct _product;
        public BackGroundServiceProduct(IBackGroundServiceProduct product)
        {
            _product = product;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) 
            {
                var productControl = await _product.ProductStockRead(stoppingToken);
                var db = new DataContext();
                var control = await db.Products.FindAsync(productControl);
                if (control.Stock <= 20) 
                {
                    if (control.Stock<=10)
                    { 
                        // tedarikçiye mail gönder stok talep et
                    }
                    var buy = await db.ProductsInCart.Where(x => x.ProductId == control.ProductId).ToListAsync();
                    if (buy != null) 
                    {
                        foreach (var item in buy)
                        {
                            var user = await db.Users.FindAsync(item.UserId);
                            var mail = user.E_Mail;
                           // MailSender mailSender = new MailSender();
                          //  mailSender.SendMail(mail, "Fırtsatı Kaçırma!", $"Sepetinizde bulunan {control.ProductName} ürünün stoğu tükeniyor bu fırsatı kaçırma satın almak için hemen sepetini kontrol et!");

                        }
                    }
                }
            }
        }
        public class MailSender
        {
            private static string senderEmail = "mail göndercek hesap";
            private static string senderPassword = "hesap şifresi";
            //private static string senderEmail = "baj.mezir@gmail.com";
            //private static string senderPassword = "xyja doun coip qwai";
            public async void SendMail(string receiver, string subject, string message)
            {
                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    var mail = new MailMessage(senderEmail, receiver, subject, message);

                    try
                    {
                        client.Send(mail);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
    }
}
