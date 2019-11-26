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


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static object CargarDataTable()
        {
            MostrarSolicitud ms = new MostrarSolicitud();
            List<Unidad> ls = new UnidadCollection().ReadAll().OrderBy(s => s.IdUnidad).ToList();
            object json = new { data = ls };
            return json;
        }
    }
}