using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANT.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// JSON反序列化
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer ser =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
            System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
}
