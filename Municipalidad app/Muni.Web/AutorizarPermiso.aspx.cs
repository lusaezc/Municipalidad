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
                    CargarGv();
                }
            }



        }
        private void CargarGv()
        {
            List<Solicitud> ls = new SolicitudCollection().ReadAll().Where(s => s.TipoUsuario == U1.IdTipoUsuario).OrderBy(s => s.IdSolicitud).ToList();
            gvSCurso.DataSource = ls;
            gvSCurso.DataBind();
        }

        protected void gvCola_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSCurso.PageIndex = e.NewPageIndex;
            CargarGv();
        }

        protected void gvCola_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static void Busqueda(int buscar)
        {

            Solicitud s = new Solicitud();
            Permiso p = new Permiso();
            int num;
            num = buscar;
            List<Permiso> ls = new PermisoCollection().ReadAll().Where(l => l.IdSolicitud == num).ToList();

            if (ls.Count() == 0)
            {
                p.IdPermiso = 0;
            }
            else
            {
                p.IdPermiso = ls.Max(q => q.IdSolicitud) + 1;
            }
            p.Estado = 0;
            p.Observaciones = "dsadas";
            //p.CantidadDias = s.FechaInicio.Day - s.FechaFin.Day;
            p.Pendiente = 0;
            p.IdSolicitud = num;
            p.CodVerificacion = new Random().Next(10000, 100000);
            
            p.Create();

        }

        protected void btnAutorizar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "autorizar()", true);
        }
    }
}