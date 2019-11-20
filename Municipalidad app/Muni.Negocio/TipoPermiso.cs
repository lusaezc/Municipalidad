using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muni.DALC;

namespace Muni.Negocio
{
    public class TipoPermiso : ICrud
    {
        public int IdTipoPermiso { get; set; }
        public string Nombre { get; set; }
        public int NumeroDias { get; set; }

        public TipoPermiso()
        {
            this.Init();
        }

        private void Init()
        {
            IdTipoPermiso = 0;
            Nombre = string.Empty;
            NumeroDias = 0;
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }



        public bool Read()
        {
            try
            {
                DALC.TIPO_PERMISO t1 = CommonBC.Modelo.TIPO_PERMISO.First(t => t.ID_TIPO_PERMISO == IdTipoPermiso);

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
