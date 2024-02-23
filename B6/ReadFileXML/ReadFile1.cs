using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadFileXML
{
    class ReadFile1
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("CHƯƠNG TRÌNH ĐỌC FILE THUVIEN.XML");

            XmlDocument doc = new XmlDocument();
            doc.Load("thuvien");

            XmlElement root = doc.DocumentElement;

            XmlNodeList li = root.SelectNodes("cuonsach");

            int i = 1;
            foreach (XmlNode item in li)
            {
                Console.WriteLine("-------------\nPhần tử thứ: " + i);
                Console.WriteLine("Tên sách: " + item.SelectSingleNode("tensach").InnerText);
                Console.WriteLine("Số trang: " + item.SelectSingleNode("sotrang").InnerText);
                Console.WriteLine("Họ tên tác giả: " + item.SelectSingleNode("tacgia/hoten").InnerText);
                Console.WriteLine("Điện thoại tác giả: " + item.SelectSingleNode("tacgia/dienthoai").InnerText);
                Console.WriteLine("Giá tiền: " + item.SelectSingleNode("giatien").InnerText);
                i++;
            }
            Console.ReadKey();



        }



    }
}
