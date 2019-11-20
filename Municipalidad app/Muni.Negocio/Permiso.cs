using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muni.Negocio
{
    public class Permiso : ICrud
    {
        public int IdPermiso { get; set; }
        public int Estado { get; set; }
        public string Observaciones { get; set; }
        public int CantidadDias { get; set; }

        public int Pendiente { get; set; }
        public int IdSolicitud { get; set; }
        public int CodVerificacion { get; set; }

        private string estadoStr;

        public string EstadoStr
        {
            get
            {
                if (Estado == 1)
                {
                    estadoStr = string.Format("solicitado");
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
                    estadoStr = string.Format("rechazado");
                }
                return estadoStr;
            }

            set { estadoStr = value; }
        }



        public string Rut
        {

            get
            {

                Muni.DALC.SOLICITUD s1 = CommonBC.Modelo.SOLICITUD.First(s => s.ID_SOLICITUD == IdSolicitud);

                return s1.RUT;

            }
        }

        public string NombreUsuario
        {

            get
            {

                Muni.DALC.FUNCIONARIO u1 = CommonBC.Modelo.FUNCIONARIO.First(u => u.RUT == Rut);
                return string.Format("{0} {1}", u1.NOMBRE, u1.APELLIDOP);

            }
        }

        public string PendienteDesplegar
        {

            get
            {

                if (Pendiente == 1)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }

            }
        }


        public Permiso()
        {
            this.Init();
        }

        private void Init()
        {
            IdPermiso = 0;
            Estado = 0;
            Observaciones = string.Empty;
            CantidadDias = 0;
            Pendiente = 0;
            IdSolicitud = 0;
            CodVerificacion = 0;
        }

        public bool Create()
        {
            try
            {
                DALC.PERMISO p1 = new DALC.PERMISO();

                p1.ID_PERMISO = IdPermiso;
                p1.ESTADO = Estado;
                p1.OBSERVACIONES = Observaciones;
                p1.CANTIDAD_DIAS = CantidadDias;
                p1.PENDIENTE = Pendiente;
                p1.ID_SOLICITUD = IdSolicitud;
                p1.COD_VERIFICACION = CodVerificacion;
                CommonBC.Modelo.PERMISO.Add(p1);
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
                DALC.PERMISO p1 = CommonBC.Modelo.PERMISO.First(p => p.ID_PERMISO == IdPermiso);

                CantidadDias = (int)p1.CANTIDAD_DIAS;
                if (p1.PENDIENTE == 1)
                {
                    Pendiente = 1;
                }
                Observaciones = p1.OBSERVACIONES;

                IdSolicitud = (int)p1.ID_SOLICITUD;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }
    }
}
