using Muni.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Muni.Web
{
    public partial class MantenedorUnidades : System.Web.UI.Page
    {
        public Funcionario U1 { get { return (Funcionario)Session["_funcionario"]; } set { Session["_funcionario"] = value; } }

        List<Unidad> PermisosColl = new UnidadCollection().ReadAll().OrderBy(e => e.IdUnidad).ToList();

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
            List<Unidad> ls = new UnidadCollection().ReadAll().OrderBy(s => s.IdUnidad).ToList();
            object json = new { data = ls };
            return json;
        }

        private void CargarDll()
        {
            ddlUnidades.DataSource = PermisosColl;
            ddlUnidades.DataTextField = "Nombre";
            ddlUnidades.DataValueField = "IdUnidad";
            ddlUnidades.DataBind();
        }

        private void CargarDllEdit()
        {
            ddlUnidadesEdit.DataSource = PermisosColl;
            ddlUnidadesEdit.DataTextField = "Nombre";
            ddlUnidadesEdit.DataValueField = "IdUnidad";
            ddlUnidadesEdit.DataBind();
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlUnidadesEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            List<Unidad> listaUnidad = new UnidadCollection().ReadAll().ToList();
            Unidad unidad = new Unidad();
            unidad.IdUnidad = listaUnidad.Max(iu => iu.IdUnidad) +1;
            unidad.Nombre = txtNombre.Text;

            if (unidad.Create())
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
                int selec = ddlUnidadesEdit.SelectedIndex;

                Unidad unidad = new UnidadCollection().ReadAll().First(es => es.IdUnidad == selec);

                unidad.Nombre = txtNombreEdit.Text;
                if (unidad.Update())
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
            Unidad unidad = new Unidad();
            unidad.IdUnidad = ddlUnidades.SelectedIndex;

            if (unidad.Delete())
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