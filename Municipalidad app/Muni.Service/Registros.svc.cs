using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using Muni.Negocio;

namespace Muni.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Registros" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Registros.svc o Registros.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Registros : IRegistros
    {
        public string ReadUsuario(string xml)
        {
            try
            {
                Funcionario f1 = Funcionario.Deserializar(xml);
                if (f1.Read())
                {
                    return f1.Serializar();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool CreateSolicitudJson(string json)
        {
            try
            {

                Solicitud s1 = new JavaScriptSerializer().Deserialize<Solicitud>(json);
                if (s1.Create())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public string ReadCollectionSolicitudJson()
        {
            List<Solicitud> ls = new SolicitudCollection().ReadAll();
            var json = new JavaScriptSerializer().Serialize(ls);

            return json;
        }

        public bool ValidarUsuario(string xml)
        {
            try
            {
                Funcionario u = Funcionario.Deserializar(xml);
                return u.ValidarUsuario();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
