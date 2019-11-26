using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muni.Negocio
{
    public class Solicitud : ICrud
    {
        public int IdSolicitud { get; set; }
        public int Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Rut { get; set; }
        public int IdTipoPermiso { get; set; }


        private string estadoStr;

        public string EstadoStr
        {
            get
            {
                if (Estado == 1)
                {
                    estadoStr = string.Format("rechazado");
                }
                else if (Estado == 2)
                {
                    estadoStr = string.Format("firmado");
                }
                else if (Estado == 3)
                {
                    estadoStr = string.Format("autorizado");
                }
                else
                {
                    estadoStr = string.Format("solicitado");
                }
                return estadoStr;
            }

            set { estadoStr = value; }
        }


        private string fechaInicioStr;

        public string FechaInicioStr
        {
            get { return FechaInicio.ToString("dd/MM/yyyy"); }
            set { fechaInicioStr = value; }
        }

        private string fechaFinStr;

        public string FechaFinStr
        {
            get { return FechaFin.ToString("dd/MM/yyyy"); }
            set { fechaFinStr = value; }
        }

        private string tipoUsuarioStr;

        public string TipoUsuarioStr
        {
            get
            {
                Muni.DALC.TIPO_PERMISO u1 = CommonBC.Modelo.TIPO_PERMISO.First(u => u.ID_TIPO_PERMISO == IdTipoPermiso);
                return string.Format("{0}", u1.NOMBRE);
            }
            set { tipoUsuarioStr = value; }
        }



        public List<Solicitud> FiltrarSolicitud(int id)
        {
            var c = (from solic in CommonBC.Modelo.SOLICITUD where solic.ID_SOLICITUD == id select solic).ToList();
            return SolicitudCollection.GenerarListado(c);
        }

        public string NombreUsuario
        {

            get
            {

                Muni.DALC.FUNCIONARIO u1 = CommonBC.Modelo.FUNCIONARIO.First(u => u.RUT == Rut);
                return string.Format("{0} {1}", u1.NOMBRE, u1.APELLIDOP);

            }
        }

        public string TipoPermiso
        {
            get
            {

                Muni.DALC.TIPO_PERMISO u1 = CommonBC.Modelo.TIPO_PERMISO.First(u => u.ID_TIPO_PERMISO == IdTipoPermiso);
                return string.Format("{0}", u1.NOMBRE);

            }
        }

        public int TipoUsuario
        {

            get
            {
                Muni.DALC.FUNCIONARIO u1 = CommonBC.Modelo.FUNCIONARIO.First(u2 => u2.RUT == Rut);
                Funcionario u = new Funcionario();
                u.Rut = u1.RUT;
                u.Read();
                return u.IdUnidad;
            }
        }


        public Solicitud()
        {
            this.Init();
        }

        private void Init()
        {
            IdSolicitud = 0;
            FechaInicio = new DateTime();
            FechaFin = new DateTime();
            Rut = string.Empty;
            IdTipoPermiso = 0;
            Estado = 0;

        }


        public bool Create()
        {
            try
            {
                DALC.SOLICITUD s1 = new DALC.SOLICITUD();
                s1.ESTADO = Estado;
                s1.ID_SOLICITUD = IdSolicitud;
                s1.FECHA_INICIO = FechaInicio;
                s1.FECHA_FIN = FechaFin;
                s1.RUT = Rut;
                s1.ID_TIPO_PERMISO = IdTipoPermiso;
                CommonBC.Modelo.SOLICITUD.Add(s1);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Read()
        {
            try
            {
                DALC.SOLICITUD s1 = CommonBC.Modelo.SOLICITUD.First(s => s.ID_SOLICITUD == IdSolicitud);

                Estado = (int)s1.ESTADO;
                FechaInicio = s1.FECHA_INICIO;
                FechaFin = s1.FECHA_FIN;
                Rut = s1.RUT;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                DALC.SOLICITUD s1 = CommonBC.Modelo.SOLICITUD.First(s => s.ID_SOLICITUD == IdSolicitud);
                s1.ESTADO = Estado;
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }


    }
}

