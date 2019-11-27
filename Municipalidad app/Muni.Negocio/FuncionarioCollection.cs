using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muni.DALC;

namespace Muni.Negocio
{
    public class FuncionarioCollection
    {
        public List<Funcionario> ReadAll()
        {
            return GenerarListado(CommonBC.Modelo.FUNCIONARIO.ToList());
        }



        private List<Funcionario> GenerarListado(List<FUNCIONARIO> list)
        {

            List<Funcionario> lp = new List<Funcionario>();
            Funcionario funcionario;

            foreach (FUNCIONARIO item in list)
            {
                funcionario = new Funcionario();

                funcionario.Rut = item.RUT;
                funcionario.Pass = item.PASS;
                funcionario.Nombre = item.NOMBRE;
                funcionario.ApellidoP = item.APELLIDOP;
                funcionario.ApellidoM = item.APELLIDOM;
                funcionario.Correo = item.CORREO;
                funcionario.FechaContrato = item.FECHA_CONTRATO;
                funcionario.Moroso = int.Parse(item.MOROSO);
                funcionario.IdUnidad = (int)item.ID_UNIDAD;
                funcionario.IdRol = (int)item.ID_ROL;
                funcionario.DiasAdministrativos = (int)item.DIAS_ADMINISTRATIVOS;
                funcionario.DiasFeriadoLegal = (int)item.DIAS_FERIADO_ANUAL;

                lp.Add(funcionario);
            }
            return lp;
        }
    }
}
