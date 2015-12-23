using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.IO;

namespace AspNetTest
{
    public partial class _Default : System.Web.UI.Page
    {
        MemoryStream ms = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Person person = new Person
            {
                Name = "zhanggensuo",
                Age = 25
            };
            Response.Write("序列化值："+SerializerObject(person));

        }

        public string SerializerObject(Person person)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(Person));
            serializer.WriteObject(ms, person);
            byte[] buffer = ms.ToArray();
            return System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }

        [Serializable]
        public class Person
        {
            public int Age { get; set; }

            public string Name { get; set; }
        }
    }
}
