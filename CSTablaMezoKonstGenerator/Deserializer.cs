using d7p4n4Namespace.Final.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CSTablaMezoKonstGenerator
{
    class Deserializer
    {
        public Tabla deser(string xml)
        {
            Tabla result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Tabla));
            using (TextReader reader = new StringReader(xml))
            {
                result = (Tabla)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
