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
    public partial class MantenedorTiposPermiso : System.Web.UI.Page
    {
        public Funcionario U1 { get { return (Funcionario)Session["_funcionario"]; } set { Session["_funcionario"] = value; } }

        List<TipoPermiso> PermisosColl = new TipoPermisoCollection().ReadAll().OrderBy(e => e.IdTipoPermiso).ToList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDll();
                CargarDllEdit();
            }
        }

        [WebMethod]
        public static object CargarDataTable()
        {
            List<TipoPermiso> ls = new TipoPermisoCollection().ReadAll().OrderBy(s => s.IdTipoPermiso).ToList();
            object json = new { data = ls };
            return json;
        }

        private void CargarDll()
        {
            ddlTipoPermiso.DataSource = PermisosColl;
            ddlTipoPermiso.DataTextField = "Nombre";
            ddlTipoPermiso.DataValueField = "IdTipoPermiso";
            ddlTipoPermiso.DataBind();
        }

        private void CargarDllEdit()
        {
            ddlTipoPermisoEdit.DataSource = PermisosColl;
            ddlTipoPermisoEdit.DataTextField = "Nombre";
            ddlTipoPermisoEdit.DataValueField = "IdTipoPermiso";
            ddlTipoPermisoEdit.DataBind();
        }

        protected void ddlTipoPermiso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTipoPermisoEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            List<TipoPermiso> listaTipo = new TipoPermisoCollection().ReadAll().ToList();
            TipoPermiso tipoPermiso = new TipoPermiso();
            tipoPermiso.IdTipoPermiso = listaTipo.Count();
            tipoPermiso.Nombre = txtNombre.Text;
            tipoPermiso.NumeroDias = int.Parse(txtNroDias.Text);
            if (tipoPermiso.Create())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacion(true)", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacion(false)", true);
            }

        }

        protected void btnConfirmarModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreEdit.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacionNull(true)", true);
            }
            else
            {
                int selec = ddlTipoPermisoEdit.SelectedIndex;

                TipoPermiso tipoP = new TipoPermisoCollection().ReadAll().First(es => es.IdTipoPermiso == selec);

                tipoP.Nombre = txtNombreEdit.Text;
                tipoP.NumeroDias = int.Parse(txtCantidadDias.Text);
                if (tipoP.Update())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacionModifi(true)", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacionModifi(false)", true);
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            TipoPermiso tp = new TipoPermiso();
            tp.IdTipoPermiso = ddlTipoPermiso.SelectedIndex;

            if (tp.Delete())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacionDelete(true)", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacionDelete(false)", true);
            }
        }
    }
}