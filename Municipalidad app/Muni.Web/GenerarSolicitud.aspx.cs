using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Muni.Negocio;

namespace Muni.Web
{
    public partial class GenerarSolicitud : System.Web.UI.Page
    {
        public Funcionario U1 { get { return (Funcionario)Session["_funcionario"]; } set { Session["_funcionario"] = value; } }
        DateTime limite;
        public static int CantidadDias = 0;
        public static int diasFinde = 0;
        public static int diasPermiso = 0 ;
        List<TipoPermiso> PermisosColl = new TipoPermisoCollection().ReadAll().ToList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (U1.Moroso == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alertarme()", true);
                }
                CargarDll();
                lblTitulo.Text = string.Format("Haz tu solicitud en tu unidad interna", U1.TipoUnidad);
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
            CantidadDias = PermisosColl.First(p => p.IdTipoPermiso == ddlCategoria.SelectedIndex).NumeroDias;
            diasPermiso = CantidadDias;
            if (ddlCategoria.SelectedIndex == 0)
            {
                CantidadDias = U1.DiasAdministrativos;
                diasPermiso = U1.DiasAdministrativos;
            }
            if (ddlCategoria.SelectedIndex == 1)
            {
                CantidadDias = U1.DiasFeriadoLegal;
                diasPermiso = U1.DiasFeriadoLegal;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lblCalendar.Text = string.Format("Ingrese la fecha limite");
            Calendar2.Visible = true;
            limite = Calendar1.SelectedDate;
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

        //private int NumberOfWorkDays()
        //{
        //    int workDays = 0;
        //    int start = Calendar1.SelectedDate.Day;
        //    int end = Calendar1.SelectedDate.Day + CantidadDias;
        //    DateTime fecha = Calendar1.SelectedDate;
        //    if (Calendar1.SelectedDate.DayOfWeek == DayOfWeek.Friday)
        //    {
        //        end = end + 2;
        //    }
        //    while (start != end)
        //    {
        //        if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
        //        {
        //            workDays++;
        //        }
        //        fecha = fecha.AddDays(1);
        //        start++;
        //    }
        //    return workDays;
        //}

        protected void RenderDays2(object sender, DayRenderEventArgs e)
        {
            DateTime dt = e.Day.Date;
            if (e.Day.Date == Calendar1.SelectedDate)
            {
                e.Cell.Controls.Add(new LiteralControl("<p style=\"color:green;\">Inicio</p>"));
            }
            if (e.Day.IsWeekend || e.Day.IsOtherMonth || e.Day.Date < Calendar1.SelectedDate)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.Enabled = false;
            }
            if (dt.Date > limite && (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday) && dt.Date < limite.AddDays(diasPermiso))
            {
                CantidadDias++;
            }
            if (e.Day.Date >= limite.AddDays(CantidadDias))
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                e.Cell.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Solicitud> ls = new SolicitudCollection().ReadAll().ToList();
            Solicitud s1 = new Solicitud();
            int CantidadDias = Calendar2.SelectedDate.Day - Calendar1.SelectedDate.Day + 1;
            CantidadDias = CantidadDias - diasFinde + 1;
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
            s1.Estado = 5;
            if (ddlCategoria.SelectedIndex == 0)
            {
                U1.DiasAdministrativos = U1.DiasAdministrativos - CantidadDias;
                U1.Update();
            }
            if (ddlCategoria.SelectedIndex == 1)
            {
                U1.DiasFeriadoLegal = U1.DiasFeriadoLegal - CantidadDias;
                U1.Update();
            }
            s1.IdTipoPermiso = ddlCategoria.SelectedIndex;
            if (s1.Create())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacion(true)", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "verificacion(false)", true);
            }
        }
    }
}
