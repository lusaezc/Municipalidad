using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Muni.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IRegistros" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IRegistros
    {
        [OperationContract]
        bool ValidarUsuario(string xml);

        [OperationContract]
        string ReadUsuario(string xml);

        [OperationContract]
        bool CreateSolicitudJson(string json);

        [OperationContract]
        string ReadCollectionSolicitudJson();

        [OperationContract]
        bool ValidarUsuarioJson(string json);

        [OperationContract]
        string ReadUsuarioJson(string json);

        [OperationContract]
        string ReadCollectionFuncionarioJson();
    }
}
