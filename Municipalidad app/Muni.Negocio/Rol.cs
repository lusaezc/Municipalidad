using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muni.Negocio
{
    public class Rol : ICrud
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; }

        public Rol()
        {
            this.Init();
        }

        private void Init()
        {
            IdRol = 0;
            Descripcion = string.Empty;
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            try
            {
                DALC.ROL t1 = CommonBC.Modelo.ROL.First(t => t.ID_ROL == IdRol);

                Descripcion = t1.DESCRIPCION;

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
