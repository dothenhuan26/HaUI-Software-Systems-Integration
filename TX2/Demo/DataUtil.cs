using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace Demo
{
    class DataUtil
    {
        XmlDocument doc;
        XmlElement root;
        string filename;

        public DataUtil()
        {
            filename = "BangGiaXe.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement banggiaxe = doc.CreateElement("banggiaxe");
                doc.AppendChild(banggiaxe);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }

        public List<Xe> GetAllXes()
        {
            List<Xe> li = new List<Xe>();

            XmlNodeList hangxes = root.SelectNodes("hangxe");

            foreach (XmlNode hangxe in hangxes)
            {
                XmlNodeList dongxes = hangxe.SelectNodes("dongxe");
                foreach (XmlNode dongxe in dongxes)
                {
                    Xe xe = new Xe();
                    xe.hangxe = hangxe.Attributes[0].InnerText;
                    xe.dongxe = dongxe.Attributes[0].InnerText;
                    xe.phienban = dongxe.SelectSingleNode("phienban").InnerText;
                    xe.dongco = dongxe.SelectSingleNode("dongco").InnerText;
                    xe.gia = dongxe.SelectSingleNode("gia").InnerText;
                    li.Add(xe);
                }
            }
            return li;
        }

        public bool AddXe(Xe xe)
        {
            XmlNode hangxef = root.SelectSingleNode("hangxe[@ten='" + xe.hangxe + "']");
            if (hangxef != null)
            {
                XmlNode dongxef = hangxef.SelectSingleNode("dongxe[@ten='" + xe.dongxe + "']");
                if (dongxef == null)
                {
                    XmlElement dongxe = doc.CreateElement("dongxe");
                    dongxe.SetAttribute("ten", xe.dongxe);
                    XmlElement phienban = doc.CreateElement("phienban");
                    phienban.InnerText = xe.phienban;
                    XmlElement dongco = doc.CreateElement("dongco");
                    dongco.InnerText = xe.dongco;
                    XmlElement gia = doc.CreateElement("gia");
                    gia.InnerText = xe.gia;
                    dongxe.AppendChild(phienban);
                    dongxe.AppendChild(dongco);
                    dongxe.AppendChild(gia);
                    hangxef.AppendChild(dongxe);
                    doc.Save(filename);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                XmlElement hangxe = doc.CreateElement("hangxe");
                hangxe.SetAttribute("ten", xe.hangxe);
                XmlElement dongxe = doc.CreateElement("dongxe");
                dongxe.SetAttribute("ten", xe.dongxe);
                XmlElement phienban = doc.CreateElement("phienban");
                phienban.InnerText = xe.phienban;
                XmlElement dongco = doc.CreateElement("dongco");
                dongco.InnerText = xe.dongco;
                XmlElement gia = doc.CreateElement("gia");
                gia.InnerText = xe.gia;
                dongxe.AppendChild(phienban);
                dongxe.AppendChild(dongco);
                dongxe.AppendChild(gia);
                hangxe.AppendChild(dongxe);
                root.AppendChild(hangxe);
                doc.Save(filename);
                return true;
            }
        }

        public bool DeleteXe(Xe xe)
        {
            XmlNode hangxef = root.SelectSingleNode("hangxe[@ten='" + xe.hangxe + "']");
            if (hangxef != null)
            {
                XmlNode dongxef = hangxef.SelectSingleNode("dongxe[@ten='" + xe.dongxe + "']");
                if (dongxef != null)
                {
                    hangxef.RemoveChild(dongxef);
                    doc.Save(filename);
                    return true;
                }
            }
            return false;
        }

        public List<Xe> FindByHangXe(string hangxe)
        {
            List<Xe> li = new List<Xe>();

            XmlNode hangxef = root.SelectSingleNode("hangxe[@ten='" + hangxe + "']");
            if (hangxef != null)
            {
                XmlNodeList dongxes = hangxef.SelectNodes("dongxe");
                foreach (XmlNode dongxe in dongxes)
                {
                    Xe xe = new Xe();
                    xe.hangxe = hangxef.Attributes[0].InnerText;
                    xe.dongxe = dongxe.Attributes[0].InnerText;
                    xe.phienban = dongxe.SelectSingleNode("phienban").InnerText;
                    xe.dongco = dongxe.SelectSingleNode("dongco").InnerText;
                    xe.gia = dongxe.SelectSingleNode("gia").InnerText;
                    li.Add(xe);
                }
            }
            return li;
        }
    }
}
