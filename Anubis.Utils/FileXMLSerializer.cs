using System;
using System.IO;
using System.Xml.Serialization;

namespace Anubis.Utils
{
    public static class FileXMLSerializer
    {
        public static T Deserialise<T>(string fileName) where T : class
        {
            T obj;
            using (FileStream fileStream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + fileName))
            {
                obj = (T) new XmlSerializer(typeof (T)).Deserialize(fileStream);
            }
            return obj;
        }

        public static void Serialize<T>(T obj, string fileName) where T : class
        {
            using (FileStream fileStream = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + fileName))
            {
                new XmlSerializer(typeof (T)).Serialize(fileStream, obj);
            }
        }
    }
}