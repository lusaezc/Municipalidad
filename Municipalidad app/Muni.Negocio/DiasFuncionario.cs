using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muni.Negocio
{
    public class DiasFuncionario : ICrud
    {
        public int IdDias { get; set; }
        public int DiasHabilesDisponibles { get; set; }
        public int IdTipoPermiso { get; set; }
        public string Rut { get; set; }


        public DiasFuncionario()
        {
            IdDias = 0;
            DiasHabilesDisponibles = 0;
            IdTipoPermiso = 0;
            Rut = string.Empty;

        }

        //public string TipoPermiso
        //{
        //    get
        //    {
        //        var idlogin = CommonBC.Modelo.DIAS_FUNCIONARIO.First(t => t.ID_DIAS == IdDias);
        //        return string.Format("{0}", CommonBC.Modelo.TIPO_PERMISO.First(U => U.ID_TIPO_PERMISO == idlogin.ID_TIPO_PERMISO).NOMBRE);
        //    }
        //}


        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            try
            {
                DALC.DIAS_FUNCIONARIO u1 = CommonBC.Modelo.DIAS_FUNCIONARIO.First(u => u.ID_DIAS == IdDias);
                DiasHabilesDisponibles = (int)u1.DIAS_HABILES_DISPONIBLES;
                IdTipoPermiso = (int)u1.ID_TIPO_PERMISO;
                Rut = u1.RUT;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            {
                try
                {
                    DALC.DIAS_FUNCIONARIO D1 = CommonBC.Modelo.DIAS_FUNCIONARIO.First(s => s.ID_DIAS == IdDias);

                    D1.DIAS_HABILES_DISPONIBLES = DiasHabilesDisponibles;
                    
                    D1.ID_TIPO_PERMISO = IdTipoPermiso;
                    D1.RUT = Rut;
                    CommonBC.Modelo.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public int CantDias
        {
            get
            {
                var dia = CommonBC.Modelo.FUNCIONARIO.First(t => t.RUT == Rut);
                return (int)CommonBC.Modelo.DIAS_FUNCIONARIO.First(U => U.RUT == dia.RUT).DIAS_HABILES_DISPONIBLES;
            }
        }
    }
}
