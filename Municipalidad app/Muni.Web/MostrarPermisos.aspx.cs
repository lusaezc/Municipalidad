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
    public partial class MostrarPermisos : System.Web.UI.Page
    {
        public Funcionario U1 { get { return (Funcionario)Session["_funcionario"]; } set { Session["_funcionario"] = value; } }
        public int buscado { get { return (int)Session["_buscado"]; } set { Session["_buscado"] = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (U1.IdRol != 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alertarme()", true);
                }
            }
        }

        [WebMethod]
        public static object CargarDataTable()
        {
            MostrarPermisos mp = new MostrarPermisos();
            List<Permiso> lp = new PermisoCollection().ReadAll().OrderBy(s => s.IdPermiso).ToList();
            object json = new { data = lp };
            return json;
        }




        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            string ee = txtcod.Text;
            buscado = int.Parse(ee);

            List<Muni.Negocio.Permiso> ls = new PermisoCollection().ReadAll().ToList();
            foreach (Muni.Negocio.Permiso s in ls)
            {
                if (buscado == s.CodVerificacion)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacion(true)", true);
                    break;
                }
                else
                {

                }

            }
            ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacion(false)", true);
        }
    }
}