using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muni.DALC;

namespace Muni.Negocio
{
    public class TipoPermisoCollection
    {
        public List<TipoPermiso> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.TIPO_PERMISO.ToList());
        }

        private List<TipoPermiso> GenerarListado(List<TIPO_PERMISO> list)
        {
            List<TipoPermiso> lt = new List<TipoPermiso>();
            TipoPermiso t;

            foreach (DALC.TIPO_PERMISO item in list)
            {
                t = new TipoPermiso();

                t.IdTipoPermiso = (int)item.ID_TIPO_PERMISO;
                t.Nombre = item.NOMBRE;
                t.NumeroDias = (int)item.NRO_DIAS;

                lt.Add(t);
            }
            return lt;
        }
    }
}
