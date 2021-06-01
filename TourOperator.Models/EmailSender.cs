using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator.Models
{
    public class EmailSender : IEmailSender
    {






        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "test@gmail.com",  // replace with valid value
                    Password = "ASA"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                var message = new MailMessage();
                message.To.Add(email);
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = true;
                message.From = new MailAddress("test@gmail.com");
                await smtp.SendMailAsync(message);
            }
        }



    }
}
