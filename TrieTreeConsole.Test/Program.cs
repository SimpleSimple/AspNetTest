using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data;

namespace TrieTreeConsole.Test
{
    class Program
    {
        static string CnnString = System.Configuration.ConfigurationManager.ConnectionStrings["99ducj"].ToString();

        static void Main(string[] args)
        {
            TestTireTree();
        }

        private static void TestTireTree()
        {
            const int count = 100;
            string[] Arr = new string[count];
            //for (int i = 0; i < Arr.Length; i++) { Arr[i] = (Guid.NewGuid()).ToString(); } // 这里是只是演示放入字符，建立Tire树

            TireTree Tree = new TireTree();
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select keyname from tb_keywords;");
            DataTable dt = PgSqlHelper.ExecuteDataset(CnnString, System.Data.CommandType.Text, sb.ToString(), null).Tables[0];

            //foreach (string str in Arr)
            //{
            //    Tree.AddWords(str);
            //}

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(dt.Rows[i]["keyname"].ToString()))
                {
                    Tree.AddWords(dt.Rows[i]["keyname"].ToString());
                }
            }

            string word = "小日本最近又在搞什么政治倾向,测试看是否可以到腾讯QQ字段#华臣天拓#";
            List<string> ResultList = Tree.SearchWords(word);
            foreach (string result in ResultList)
            {
                Console.WriteLine(string.Format("检测到非法词语{0}", result));
            }

        }
    }
}
