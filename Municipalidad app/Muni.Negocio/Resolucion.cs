using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muni.Negocio
{
    public class Resolucion : ICrud
    {
        public int IdResolucion { get; set; }
        public string Detalle { get; set; }
        public int Correlativo { get; set; }
        public string Rut { get; set; }
        public int IdPermiso { get; set; }



        public List<Resolucion> FiltrarResolucion(int idResolucion)
        {
            var c = (from tick in CommonBC.Modelo.RESOLUCION where tick.ID_RESOLUCION == IdResolucion select tick).ToList();
            return ResolucionCollection.GenerarListado(c);
        }


        //public string Fecha
        //{

        //    get
        //    {

        //        Muni.DALC.PERMISO p1 = CommonBC.Modelo.PERMISO.First(p => p.ID_PERMISO == IdResolucion);
        //        return string.Format("{0} - {1}", p1.FECHA_TERMINO, p1.FECHA_TERMINO);

        //    }
        //}

        public string DatosUsuario
        {

            get
            {

                Muni.DALC.FUNCIONARIO u1 = CommonBC.Modelo.FUNCIONARIO.First(u => u.RUT == Rut);
                return string.Format("{0} {1} {2}", u1.RUT, u1.NOMBRE, u1.APELLIDOP);

            }
        }


        public Resolucion()
        {
            this.Init();
        }

        private void Init()
        {
            IdResolucion = 0;
            Detalle = string.Empty;
            Correlativo = 0;
            Rut = string.Empty;
            IdPermiso = 0;
        }





        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            try
            {
                DALC.RESOLUCION t1 = CommonBC.Modelo.RESOLUCION.First(t => t.ID_PERMISO == IdPermiso && t.ID_RESOLUCION == IdResolucion &&
                    t.RUT == Rut);

                Detalle = t1.DETALLE;

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
