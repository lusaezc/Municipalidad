using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Muni.Negocio;

namespace Muni.Web
{
    public partial class MostrarSolicitud : System.Web.UI.Page
    {
        public Funcionario U1 { get { return (Funcionario)Session["_funcionario"]; } set { Session["_funcionario"] = value; } }
        public int buscado { get { return (int)Session["_buscado"]; } set { Session["_buscado"] = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDataTable();
            }
            //lblTitulo.Text = string.Format("Mis solicitudes en la Unidad {0} ", U1.TipoUnidad);

        }

        [WebMethod]
        public static object CargarDataTable()
        {
            MostrarSolicitud ms = new MostrarSolicitud();
            List<Solicitud> ls = new SolicitudCollection().ReadAll().Where(e => e.Rut == ms.U1.Rut).OrderBy(s => s.IdSolicitud).ToList();
            object json = new { data = ls };
            return json;
        }




        //protected void btncorreo_Command(object sender, CommandEventArgs e)
        //{
        //    Correo Cr = new Correo();
        //    MailMessage mnsj = new MailMessage();

        //    mnsj.Subject = "Registro de usuario";
        //    mnsj.To.Add(new MailAddress(U1.CorreoUsuario));
        //    mnsj.From = new MailAddress("camilo.saez999@gmail.com", "Administrador BLD");
        //    mnsj.Attachments.Add(new Attachment("C:/Users/Luchito/Downloads/OrdenSolicitud.pdf"));
        //    mnsj.Body = string.Format("Se le ha enviado la siguiente solicitud");

        //    Cr.MandarCorreo(mnsj);

        //    MsgBox("Correo Enviado Exitosamente", this.Page, this);

        //}

    }
}
