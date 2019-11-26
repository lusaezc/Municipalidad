using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muni.Negocio
{
    public class Funcionario : ICrud
    {
        public string Rut { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Correo { get; set; }
        public DateTime FechaContrato { get; set; }
        public int Moroso { get; set; }
        public int IdUnidad { get; set; }
        public int IdRol { get; set; }
        public int DiasAdministrativos { get; set; }
        public int DiasFeriadoLegal { get; set; }





        public Funcionario()
        {
            Rut = string.Empty;
            Pass = string.Empty;
            Nombre = string.Empty;
            ApellidoP = string.Empty;
            ApellidoM = string.Empty;
            Correo = string.Empty;
            FechaContrato = new DateTime();
            Moroso = 0;
            IdUnidad = 0;
            IdRol = 0;
            DiasAdministrativos = 0;
            DiasFeriadoLegal = 0;

        }


        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            try
            {

                DALC.FUNCIONARIO u1 = CommonBC.Modelo.FUNCIONARIO.First(u => u.RUT == Rut);
                Pass = u1.PASS;
                Nombre = u1.NOMBRE;
                ApellidoP = u1.APELLIDOP;
                ApellidoM = u1.APELLIDOM;
                Correo = u1.CORREO;
                FechaContrato = u1.FECHA_CONTRATO;
                IdRol = (int)u1.ID_ROL;
                IdUnidad = (int)u1.ID_UNIDAD;
                Moroso = int.Parse(u1.MOROSO);
                DiasAdministrativos = (int)u1.DIAS_ADMINISTRATIVOS;
                DiasFeriadoLegal = (int)u1.DIAS_FERIADO_ANUAL;

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
                DALC.FUNCIONARIO u = CommonBC.Modelo.FUNCIONARIO.First(u1 => u1.RUT == Rut);

                u.PASS = Pass;
                u.NOMBRE = Nombre;
                u.APELLIDOP = ApellidoP;
                u.APELLIDOM = ApellidoM;
                u.CORREO = Correo;
                u.FECHA_CONTRATO = FechaContrato;
                u.ID_UNIDAD = IdUnidad;
                u.ID_ROL = IdRol;
                u.MOROSO = Moroso.ToString();

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string MorosoDesplegar
        {

            get
            {

                if (Moroso == 1)
                {
                    return "SI";
                }
                else
                {
                    return "NO";
                }

            }
        }

        public static Funcionario Deserializar(string xml)
        {
            return (Funcionario)CommonBC.Deserializar<Funcionario>(xml);
        }

        public string Serializar()
        {
            return CommonBC.Serializar<Funcionario>(this);
        }

        public bool ValidarUsuario()
        {
            try
            {
                DALC.FUNCIONARIO u1 = CommonBC.Modelo.FUNCIONARIO.First(u => u.RUT == Rut && u.PASS == Pass);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public string DatosLogin
        {
            get
            {
                var idlogin = CommonBC.Modelo.FUNCIONARIO.First(t => t.RUT == Rut);
                return string.Format("{0} {1} - {2}", Nombre, ApellidoP, CommonBC.Modelo.ROL.First(t => t.ID_ROL == idlogin.ID_ROL).DESCRIPCION);
            }
        }
        /*, CommonBC.Modelo.tipo_usuario.First(t => t.id_tipo == IdTipo).descripcion*/
        public string TipoUsuario
        {
            get
            {
                var idlogin = CommonBC.Modelo.FUNCIONARIO.First(t => t.RUT == Rut);
                return string.Format("{0}", CommonBC.Modelo.ROL.First(U => U.ID_ROL == idlogin.ID_ROL).DESCRIPCION);
            }
        }

        public int IdTipoUsuario
        {
            get
            {
                var idlogin = CommonBC.Modelo.FUNCIONARIO.First(t => t.RUT == Rut);
                return (int)CommonBC.Modelo.UNIDAD_INTERNA.First(U => U.ID_UNIDAD == idlogin.ID_UNIDAD).ID_UNIDAD;
            }
        }

        public string TipoUnidad
        {
            get
            {

                return string.Format("{0}", CommonBC.Modelo.UNIDAD_INTERNA.First(U => U.ID_UNIDAD == IdUnidad).NOMBRE);
            }
        }

        public string CorreoUsuario
        {

            get
            {

                Muni.DALC.FUNCIONARIO u1 = CommonBC.Modelo.FUNCIONARIO.First(u2 => u2.RUT == Rut);
                Funcionario u = new Funcionario();
                u.Rut = u1.RUT;
                u.Read();
                return u.Correo;

            }
        }

    }
}
