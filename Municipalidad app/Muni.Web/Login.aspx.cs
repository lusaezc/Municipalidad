using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Muni.Negocio;

namespace Muni.Web
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtRut.Text != string.Empty && TxtPass.Text != string.Empty)
            {
                Funcionario u = new Funcionario();
                u.Rut = TxtRut.Text;
                u.Pass = TxtPass.Text;
                string xml1 = u.Serializar();

                Muni.Web.MuniWCF.RegistrosClient proxy = new Muni.Web.MuniWCF.RegistrosClient();
                bool valido = proxy.ValidarUsuario(xml1);

                proxy.Close();

                if (valido)
                {
                    proxy = new Muni.Web.MuniWCF.RegistrosClient();
                    string xml = proxy.ReadUsuario(u.Serializar());
                    proxy.Close();
                    u = Funcionario.Deserializar(xml);
                    Session["_funcionario"] = u;
                    Response.Redirect("MantenedorUnidades.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Ingresar datos,estan vacios')", true);

                }
            }
        }
    }
}