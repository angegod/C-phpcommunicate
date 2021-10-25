
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;


namespace ConsoleApp1
{
    public class Student
    {
        public string id { get; set; }
        public string username { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:7892/php/test/ange/Testreturnvalue.php";

            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.CookieContainer = cc;

            
            string Classcode = "AAA"; //密碼
            string lastname = "10000";
            string data = "Classcode="+HttpUtility.UrlEncode(Classcode)+"&lastname="+HttpUtility.UrlEncode(lastname); ;
            request.ContentLength = data.Length;

            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(data);//execute
            writer.Flush();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //預設編碼
            }

            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            data = reader.ReadToEnd();
            //cc = request.CookieContainer;
            response.Close();

            
            
            var j = JArray.Parse(data);
            var token = j[0];

            var obj = token.ToObject<Student>();

            Console.WriteLine(obj.id);
            Console.WriteLine(obj.username);




        }
    }
}
