using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muni.DALC;

namespace Muni.Negocio
{
    public class SolicitudCollection
    {
        public List<Solicitud> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.SOLICITUD.ToList());
        }

        public static List<Solicitud> GenerarListado(List<SOLICITUD> list)
        {

            List<Solicitud> ls = new List<Solicitud>();
            Solicitud s;

            foreach (DALC.SOLICITUD item in list)
            {
                s = new Solicitud();
                s.IdSolicitud = (int)item.ID_SOLICITUD;
                s.FechaInicio = item.FECHA_INICIO;
                s.Rut = item.RUT;
                s.Estado = (int)item.ESTADO;
                s.FechaFin = item.FECHA_FIN;
                s.IdTipoPermiso = (int)item.ID_TIPO_PERMISO;
                s.FechaInicioStr = item.FECHA_INICIO.ToString("dd-MM-yyyy");
                s.FechaFinStr = item.FECHA_FIN.ToString();
                s.EstadoStr = item.ESTADO.ToString();
                ls.Add(s);
            }
            return ls;
        }
    }
}
