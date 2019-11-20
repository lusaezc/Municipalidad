using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muni.DALC;

namespace Muni.Negocio
{
    public class PermisoCollection
    {
        public List<Permiso> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.PERMISO.ToList());
        }



        private List<Permiso> GenerarListado(List<PERMISO> list)
        {

            List<Permiso> lp = new List<Permiso>();
            Permiso permiso;

            foreach (DALC.PERMISO item in list)
            {
                permiso = new Permiso();

                permiso.IdPermiso = (int)item.ID_PERMISO;
                permiso.Estado = (int)item.ESTADO;
                permiso.Observaciones = item.OBSERVACIONES;
                permiso.CantidadDias = (int)item.CANTIDAD_DIAS;
                
                if (item.PENDIENTE == 1)
                {
                    permiso.Pendiente = 1;
                }

                permiso.IdSolicitud = (int)item.ID_SOLICITUD;
                permiso.CodVerificacion = (int)item.COD_VERIFICACION;

                lp.Add(permiso);
            }
            return lp;
        }
    }
}
