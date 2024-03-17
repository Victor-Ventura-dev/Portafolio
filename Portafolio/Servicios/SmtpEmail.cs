using Portafolio.Models;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;

namespace Portafolio.Servicios
{
    public interface ISmtpEmail
    {
        Task Enviar(ContactoDTO contacto);
    }
    public class SmtpEmail : ISmtpEmail
    {
        private readonly IConfiguration configuration;
        public SmtpEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar (ContactoDTO contacto) 
        {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(contacto.Email);
                    
                    mail.To.Add("victorventurarivas@gmail.com");
                    mail.Subject = "Notificación portfolio por "+contacto.Nombre;
                    mail.Body = contacto.Mensaje+"<br/>Enviado por "+contacto.Email ;
                    mail.IsBodyHtml = true;
                    
                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("ventura11j@gmail.com", "yohy jifz gojq baze");
                        smtp.EnableSsl = true;
                        string userState = "testMessage";
                        smtp.SendAsync(mail,userState);
                       
                    }
                }
            
        }


        
    }

}
