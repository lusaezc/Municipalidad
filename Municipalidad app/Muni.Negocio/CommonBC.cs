using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muni.DALC;
using System.Xml.Serialization;
using System.IO;

namespace Muni.Negocio
{
    public class CommonBC
    {
        private static MuniEntities _modelo;

        public static MuniEntities Modelo
        {
            get
            {
                if (_modelo == null)
                {
                    _modelo = new MuniEntities();
                }
                return _modelo;
            }

        }

        public static string Serializar<T>(object objeto)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            StringWriter writer = new StringWriter();

            serializador.Serialize(writer, objeto);

            return writer.ToString();
        }

        public static object Deserializar<T>(string xml)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(xml);

            return serializador.Deserialize(reader);
        }
    }
}
