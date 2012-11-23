using System;
using System.IO;
using System.Xml.Serialization;

namespace Anubis.Utils
{
    public static class FileXmlSerializer
    {
        public static T Deserialize<T>(string fileName) where T : class
        {
            T obj;
            using (var fileStream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + fileName))
            {
                obj = (T) new XmlSerializer(typeof (T)).Deserialize(fileStream);
            }
            return obj;
        }

        public static void Serialize<T>(T obj, string fileName) where T : class
        {
            using (var fileStream = File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + fileName))
            {
                new XmlSerializer(typeof (T)).Serialize(fileStream, obj);
            }
        }
    }
}