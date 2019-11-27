using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Muni.Negocio;

namespace Muni.Web
{
    public partial class FuncionariosUni : System.Web.UI.Page
    {
        public Funcionario U1 { get { return (Funcionario)Session["_funcionario"]; } set { Session["_funcionario"] = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userName1.Text = string.Format("{0} {1} {2}", U1.Nombre, U1.ApellidoP, U1.ApellidoM);
                fechaCon1.Text = string.Format("{0}", U1.FechaContrato);
            }

            List<Funcionario> listafuncionarios = new FuncionarioCollection().ReadAll().Where(l => l.IdUnidad == U1.IdUnidad).ToList();


        }


    }
}