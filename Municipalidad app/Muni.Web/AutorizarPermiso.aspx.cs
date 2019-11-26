using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Muni.Negocio;

namespace Muni.Web
{
    public partial class AutorizarPermiso : System.Web.UI.Page
    {
        public Funcionario U1 { get { return (Funcionario)Session["_funcionario"]; } set { Session["_funcionario"] = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (U1.IdRol != 2)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alertarme()", true);
                }
                else
                {
                    lblTitulo.Text = string.Format("Solicitudes actuales en la unidad: {0}", U1.TipoUnidad);
                    CargarDataTable();
                }
            }
        }

        [WebMethod]
        public static object CargarDataTable()
        {
            MostrarSolicitud ms = new MostrarSolicitud();
            List<Solicitud> ls = new SolicitudCollection().ReadAll().Where(e => e.TipoUsuario == ms.U1.IdTipoUsuario && e.EstadoStr == "solicitado").OrderBy(s => s.IdSolicitud).ToList();
            object json = new { data = ls };
            return json;
        }


        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            {

                Permiso p = new Permiso();
                string numS = txtcod.Text;
                int num = int.Parse(numS);
                Solicitud s = new SolicitudCollection().ReadAll().First(sc => sc.IdSolicitud == num);

                List<Permiso> ls = new PermisoCollection().ReadAll().ToList();



                p.IdPermiso = s.IdSolicitud;
                p.Observaciones = txtObservaciones.Text;
                p.CantidadDias = s.FechaFin.Day - s.FechaInicio.Day;
                p.Pendiente = 1;
                p.IdSolicitud = num;
                p.CodVerificacion = new Random().Next(10000, 100000);

                if (p.Create())
                {
                    s.Estado = 2;
                    s.Update();
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacion(true)", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacion(false)", true);
                }
            }
        }
    }
}