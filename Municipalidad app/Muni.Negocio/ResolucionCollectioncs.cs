using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muni.DALC;

namespace Muni.Negocio
{
    public class ResolucionCollection
    {
        public List<Resolucion> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.RESOLUCION.ToList());
        }

        public static List<Resolucion> GenerarListado(List<RESOLUCION> list)
        {
            List<Resolucion> lt = new List<Resolucion>();
            Resolucion t;

            foreach (DALC.RESOLUCION item in list)
            {
                t = new Resolucion();

                t.IdResolucion = (int)item.ID_RESOLUCION;
                t.Detalle = item.DETALLE;
                t.Correlativo = (int)item.CORRELATIVO;
                t.Rut = item.RUT;
                t.IdPermiso = (int)item.ID_PERMISO;

                lt.Add(t);
            }
            return lt;
        }
    }
}
