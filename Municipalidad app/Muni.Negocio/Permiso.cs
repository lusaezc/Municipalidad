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
        public string Observaciones { get; set; }
        public int CantidadDias { get; set; }

        public int Pendiente { get; set; }
        public int IdSolicitud { get; set; }
        public int CodVerificacion { get; set; }




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

        private string pendienteStr;

        public string PendienteStr
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
            set { pendienteStr = value; }
        }


        public Permiso()
        {
            this.Init();
        }

        private void Init()
        {
            IdPermiso = 0;
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
            try
            {
                DALC.PERMISO s1 = CommonBC.Modelo.PERMISO.First(s => s.ID_PERMISO == IdPermiso);
                s1.OBSERVACIONES = Observaciones;
                s1.PENDIENTE = Pendiente;
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
