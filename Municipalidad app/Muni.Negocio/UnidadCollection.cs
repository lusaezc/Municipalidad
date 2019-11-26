using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muni.DALC;

namespace Muni.Negocio
{
    public class UnidadCollection
    {
        public List<Unidad> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.UNIDAD_INTERNA.ToList());
        }

        private List<Unidad> GenerarListado(List<UNIDAD_INTERNA> list)
        {
            List<Unidad> lt = new List<Unidad>();
            Unidad u;

            foreach (DALC.UNIDAD_INTERNA item in list)
            {
                u = new Unidad();

                u.IdUnidad = (int)item.ID_UNIDAD;
                u.Nombre = item.NOMBRE;

                lt.Add(u);
            }
            return lt;
        }
    }
}
