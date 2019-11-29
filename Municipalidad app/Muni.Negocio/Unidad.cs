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
            try
            {
                DALC.UNIDAD_INTERNA u1 = new DALC.UNIDAD_INTERNA();
                u1.ID_UNIDAD = IdUnidad;
                u1.NOMBRE = Nombre;
                CommonBC.Modelo.UNIDAD_INTERNA.Add(u1);
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
            try
            {
                DALC.UNIDAD_INTERNA u1 = CommonBC.Modelo.UNIDAD_INTERNA.First(u => u.ID_UNIDAD == IdUnidad);
                u1.NOMBRE = Nombre;
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
            try
            {
                DALC.UNIDAD_INTERNA u1 = CommonBC.Modelo.UNIDAD_INTERNA.First(u => u.ID_UNIDAD == IdUnidad);
                CommonBC.Modelo.UNIDAD_INTERNA.Remove(u1);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
