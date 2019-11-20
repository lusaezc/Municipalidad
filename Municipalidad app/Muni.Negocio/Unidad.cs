using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muni.Negocio
{
    public class Unidad : ICrud
    {
        public int IdUnidad { get; set; }
        public string Nombre { get; set; }

        public Unidad()
        {
            this.Init();
        }

        private void Init()
        {
            IdUnidad = 0;
            Nombre = string.Empty;
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            try
            {
                DALC.UNIDAD_INTERNA t1 = CommonBC.Modelo.UNIDAD_INTERNA.First(t => t.ID_UNIDAD == IdUnidad);

                Nombre = t1.NOMBRE;

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
