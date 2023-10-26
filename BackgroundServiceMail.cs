using DataAccessLayer;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BuiseneesLayer.Contracts;

    public class BackgroundServiceMail : BackgroundService
    {
        private readonly IBackGroundServiceProduct _backGroundServiceProduct;
        public BackgroundServiceMail(IBackGroundServiceProduct backGroundServiceProduct)
        {
            _backGroundServiceProduct = backGroundServiceProduct;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                var buyMail = await _backGroundServiceProduct.BuyProductMailRead(stoppingToken);
                var productId = buyMail[0];
                var userId = buyMail[1];
                var db = new DataContext();
                var user = await db.Users.FindAsync(userId);
                var mailUser = user.E_Mail;
                var product = await db.Products.FindAsync(productId);
                var productName = product.ProductName;
                //   MailSender mailSender = new MailSender();
                // mailSender.SendMail(mailUser, "Satın alma işlemin başarılı", $"Satın aldığın {productName} ürünü hazırlanıyor kargoya varildiğinde sizlere bilgilendirme sağlayacağız bizleri tercih ettiğin için teşekkür ederiz:)");
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
