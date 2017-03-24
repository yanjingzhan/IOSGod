using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib
{
    public class JsonHelper
    {
        public static string SerializerToJson(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static T DeserializeObjectFromJson<T>(string jsonStr)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            catch
            {
                return default(T);
            }
        }

        public static void SerializerToJsonFile(object obj, string filePath)
        {
            try
            {
                string s = JsonConvert.SerializeObject(obj);
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(s);
                    sw.Flush();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static T DeserializeObjectFromJsonFile<T>(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string s = sr.ReadToEnd().Trim();
                    return JsonConvert.DeserializeObject<T>(s);
                }
            }
            catch
            {
                return default(T);
            }
        }
    }
}
