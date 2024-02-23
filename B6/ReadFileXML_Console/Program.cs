using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadFileXML_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("thuvien");
            XmlElement cuonsach = doc.CreateElement("cuonsach");
            XmlElement tensach = doc.CreateElement("tensach");
            XmlText ttensach = doc.CreateTextNode("Lap trinh java");
            XmlElement sotrang = doc.CreateElement("sotrang");
            XmlText tsotrang = doc.CreateTextNode("350");
            XmlElement tacgia = doc.CreateElement("tacgia");
            XmlElement hoten = doc.CreateElement("hoten");
            XmlText thoten = doc.CreateTextNode("Nguyen dang hoang");
            XmlElement dienthoai = doc.CreateElement("dienthoai");
            XmlText tdienthoai = doc.CreateTextNode("09876548");
            XmlElement giatien = doc.CreateElement("giatien");
            XmlText tgiatien = doc.CreateTextNode("500");
            root.AppendChild(cuonsach);
            cuonsach.AppendChild(tensach);
            tensach.AppendChild(ttensach);
            sotrang.AppendChild(tsotrang);
            hoten.AppendChild(thoten);
            dienthoai.AppendChild(tdienthoai);
            giatien.AppendChild(tgiatien);
            cuonsach.AppendChild(sotrang);
            cuonsach.AppendChild(tacgia);
            tacgia.AppendChild(hoten);
            tacgia.AppendChild(dienthoai);
            cuonsach.AppendChild(giatien);
            doc.AppendChild(root);
            doc.Save("thuvien2.xml");
        }

        //static void Main(string[] args)
        //{
        //    Console.OutputEncoding = System.Text.Encoding.UTF8;
        //    Console.WriteLine("DOC FILE THUVIEN.XML 2");
        //    XmlDocument doc = new XmlDocument();

        //    doc.Load("thuvien.xml");
        //    XmlElement root = doc.DocumentElement;

        //    PrintNode(root);

        //    Console.ReadKey();

        //}

        //static void PrintNode(XmlNode node)
        //{
        //    Console.Write("Type = [" + node.NodeType + "]");
        //    Console.Write(", Name = " + node.Name);
        //    Console.Write(", Value = [" + node.Value + "]");

        //    XmlNodeList list = node.ChildNodes;
        //    if (list.Count > 0)
        //    {
        //        Console.WriteLine("--------Các con của node: " + node.Name + " là: ");
        //        foreach (XmlNode item in list)
        //        {
        //            PrintNode(item);
        //        }
        //        Console.WriteLine("Ket thuc node: " + node.Name);
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    Console.OutputEncoding = System.Text.Encoding.UTF8;

        //    Console.WriteLine("CHƯƠNG TRÌNH ĐỌC FILE THUVIEN.XML");

        //    XmlDocument doc = new XmlDocument();
        //    doc.Load("thuvien.xml");

        //    XmlElement root = doc.DocumentElement;

        //    XmlNodeList li = root.SelectNodes("cuonsach");

        //    int i = 1;
        //    foreach (XmlNode item in li)
        //    {
        //        Console.WriteLine("-------------\nPhần tử thứ: " + i);
        //        Console.WriteLine("Tên sách: " + item.SelectSingleNode("tensach").InnerText);
        //        Console.WriteLine("Số trang: " + item.SelectSingleNode("sotrang").InnerText);
        //        Console.WriteLine("Họ tên tác giả: " + item.SelectSingleNode("tacgia/hoten").InnerText);
        //        Console.WriteLine("Điện thoại tác giả: " + item.SelectSingleNode("tacgia/dienthoai").InnerText);
        //        Console.WriteLine("Giá tiền: " + item.SelectSingleNode("giatien").InnerText);
        //        i++;
        //    }
        //    Console.WriteLine("Số lượng cuốn sách: "+li.Count);
        //    Console.ReadKey();
        //}
    }
}
