using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muni.DALC;

namespace Muni.Negocio
{
    public class DiasFuncionarioCollection
    {
        public List<DiasFuncionario> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.DIAS_FUNCIONARIO.ToList());
        }

        private List<DiasFuncionario> GenerarListado(List<DIAS_FUNCIONARIO> list)
        {
            {
                List<DiasFuncionario> lt = new List<DiasFuncionario>();
                DiasFuncionario t;

                foreach (DALC.DIAS_FUNCIONARIO item in list)
                {
                    t = new DiasFuncionario();

                    t.IdDias = (int)item.ID_DIAS;
                    t.DiasHabilesDisponibles = (int)item.DIAS_HABILES_DISPONIBLES;
                    t.IdTipoPermiso = (int)item.ID_TIPO_PERMISO;
                    t.Rut = item.RUT;

                    lt.Add(t);
                }
                return lt;
            }
        }
    }
}
