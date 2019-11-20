using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Muni.Negocio
{
    public class Correo
    {

        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);

        public Correo()
        {
            server.Credentials = new System.Net.NetworkCredential("camilo.saez999@gmail.com", "03911404");
            server.EnableSsl = true;
        }

        public void MandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }
    }
}
