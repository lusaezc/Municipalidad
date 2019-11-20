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
                lblinfo1.Text = string.Format("{0}", U1.TipoUsuario);
                lblinfo0.Text = string.Format("{0} {1} {2}", U1.Nombre, U1.ApellidoP, U1.ApellidoM);
                lblinfo2.Text = string.Format("Correo: {0}", U1.Correo);
                lblinfo4.Text = string.Format("Unidad: {0}", U1.TipoUnidad);
                lblinfo3.Text = string.Format("Fecha Contrato: {0}", U1.FechaContrato.ToShortDateString());
            }
        }
    }
}