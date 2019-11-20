using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Muni.Negocio;

namespace MuniWeb
{
    public partial class MaestroSolicitud : System.Web.UI.Page
    {
        public Funcionario U1 { get { return (Funcionario)Session["_funcionario"]; } set { Session["_funcionario"] = value; } }
        public DiasFuncionario F1 { get { return (DiasFuncionario)Session["_diasfuncionario"]; } set { Session["_diasfuncionario"] = value; } }
        DateTime limite;
        int CantidadDias = 0;

        List<TipoPermiso> PermisosColl = new TipoPermisoCollection().ReadAll().ToList();
        public List<DiasFuncionario> ld;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CargarGv();
                CargarDll();
               // lblTitulo.Text = string.Format("Haz tu solicitud en tu unidad interna", U1.TipoUnidad);
            }
        }

        private void CargarDll()
        {

            ddlCategoria.DataSource = PermisosColl;
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "IdTipoPermiso";
            ddlCategoria.DataBind();
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
            int CantidadDias = PermisosColl.Where(p => p.IdTipoPermiso == ddlCategoria.SelectedIndex).First().NumeroDias;
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            

            lblCalendar.Text = string.Format("Ingrese la fecha limite");
            Calendar2.Visible = true;
            limite = Calendar1.SelectedDate;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            List<Solicitud> ls = new SolicitudCollection().ReadAll().ToList();
            Solicitud s1 = new Solicitud();

            int CantidadDias = PermisosColl.Where(p => p.IdTipoPermiso == ddlCategoria.SelectedIndex).First().NumeroDias;


            if (ls.Count() == 0)
            {
                s1.IdSolicitud = 1;
            }
            else
            {
                s1.IdSolicitud = ls.Max(s => s.IdSolicitud) + 1;
            }


            s1.FechaInicio = Calendar1.SelectedDate;
            s1.FechaFin = Calendar2.SelectedDate;
            s1.Rut = U1.Rut;



                DiasFuncionario st = new DiasFuncionario();

                //if (ddlCategoria.SelectedIndex == 0 || ddlCategoria.SelectedIndex == 1)
                //{
                //    st.DiasHabilesDisponibles = st.CantDias - CantidadDias;
                //st.Update();
                // }


            s1.IdTipoPermiso = ddlCategoria.SelectedIndex;

            if (s1.Create())
            {
                MsgBox("Solicitud Generada", this.Page, this);
            }
            else
            {
                MsgBox("Error", this.Page, this);
            }
            


        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            

            Button1.Visible = true;
        }
        protected void RenderDays1(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsToday)
            {
                e.Cell.Controls.Add(new LiteralControl("<p style=\"color:green;\">Hoy</p>"));
            }


            if (e.Day.Date < DateTime.Now.Date || e.Day.IsWeekend || e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.Enabled = false;

            }




        }
        protected void RenderDays2(object sender, DayRenderEventArgs e)
        {

            if (e.Day.Date == Calendar1.SelectedDate)
            {
                e.Cell.Controls.Add(new LiteralControl("<p style=\"color:green;\">Inicio</p>"));
            }


            CantidadDias = PermisosColl.Where(p => p.IdTipoPermiso == ddlCategoria.SelectedIndex).First().NumeroDias;

            if (e.Day.Date < DateTime.Now.Date || e.Day.IsWeekend || e.Day.IsOtherMonth || e.Day.Date < Calendar1.SelectedDate)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.Enabled = false;

            }

            if (ddlCategoria.SelectedIndex == 0 || ddlCategoria.SelectedIndex == 1)
            {

                if (e.Day.Date > limite.AddDays(CantidadDias))
                {
                    e.Day.IsSelectable = false;
                    e.Cell.BackColor = System.Drawing.Color.LightGray;
                    e.Cell.Enabled = false;
                }
            }
            else
            {
                if (e.Day.Date > limite.AddDays(CantidadDias))
                {
                    e.Day.IsSelectable = false;
                    e.Cell.BackColor = System.Drawing.Color.LightGray;
                    e.Cell.Enabled = false;
                }

            }
        }


        }
    }
