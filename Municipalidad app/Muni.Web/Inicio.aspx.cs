using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Muni.Negocio;


namespace MuniWeb
{
    public partial class Inicio : System.Web.UI.Page
    {
        public Funcionario U1 { get { return (Funcionario)Session["_funcionario"]; } set { Session["_funcionario"] = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Solicitud> solicitudes = new SolicitudCollection().ReadAll().Where(p => p.Rut == U1.Rut && p.FechaFin <= DateTime.Today.AddDays(1)).ToList();
                List<Permiso> permisos = new PermisoCollection().ReadAll().Where(p => p.Rut == U1.Rut && p.Pendiente == 1).ToList();
                lblinfo1.Text = string.Format("{0}", U1.TipoUsuario);
                lblinfo0.Text = string.Format("{0} {1} {2}", U1.Nombre, U1.ApellidoP, U1.ApellidoM);
                lblinfo2.Text = string.Format("Correo: {0}", U1.Correo);
                lblinfo4.Text = string.Format("Unidad: {0}", U1.TipoUnidad);
                lblinfo3.Text = string.Format("Fecha Contrato: {0}", U1.FechaContrato.ToShortDateString());
                if (solicitudes.Count() > 0 && U1.Moroso == 0 && permisos.Count() > 0)
                {
                    U1.Moroso = 1;
                }
                if (permisos.Count() > 0 && solicitudes.Count() > 0)
                {
                    lblAdvertencia.Text = string.Format("Usted tiene {0} permiso pendiente",permisos.Count());
                    btnVerif.Visible = true;
                }
            }
        }

        protected void btnVerif_Click(object sender, EventArgs e)
        {
            Permiso permiso = new PermisoCollection().ReadAll().First(a => a.Pendiente == 1);
                permiso.Pendiente = 0;
                if (permiso.Update())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alertarme()", true);
                }
            }
        }
    }