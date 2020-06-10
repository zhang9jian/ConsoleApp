using System;
using System.IO;
using System.Text;
using System.Xml;

namespace XML
{
    internal class XmlParser
    {
        private String a = "<?xml version=\"1.0\" encoding=\"UTF-8\"?> <library id =\"10\">" +
                       "<BOOK id =\"2\">" +
                        "<name id =\"3\" txt =\"科目\">高等数学</name> " +
                         "<name1>大学英语</name1>" +
                         "<first id =\"4\" txt =\"这是节点么\"/>" +
                         "<name2><rename>test</rename></name2>" +
                    "</BOOK> " +
                    "<BOOK id =\"2\">" +
                        "<name id =\"3\" txt =\"科目\">高等数学</name> " +
                         "<name1>大学英语</name1>" +
                         "<first id =\"4\" txt =\"这是节点么\"/>" +
                         "<name2><rename>test</rename></name2>" +
                    "</BOOK> " +
                 "</library>";

        public string formatXml(string str = null)
        {
            if (str == null) str = a;
            MemoryStream mstream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mstream, null);
            writer.Formatting = Formatting.Indented;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(str);

            xmldoc.WriteTo(writer);
            writer.Flush();
            writer.Close();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            string strReturn = encoding.GetString(mstream.ToArray());
            mstream.Close();
            return strReturn;
        }

        public void parse()
        {
            XmlDocument xdoc = new XmlDocument();

            xdoc.LoadXml(a);
            //x.LoadXml(@"C:\app\vs2019\VC#\mywork\XMLParser\XMLParser\bin\Debug\demo.xml");
            Console.WriteLine(formatXml(a));
            //Console.WriteLine(x.InnerXml);
            XmlNodeReader xmlNode = new XmlNodeReader(xdoc.GetElementsByTagName("library")[0]);
            Console.WriteLine("Node library Value: " + xmlNode.Value);//打印获取值
            Console.WriteLine("XmlDocument ChildNodes.Count： " + xdoc.ChildNodes.Count);//打印子节点数量
            Console.WriteLine("XmlDocument ChildNodes[0].Name： " + xdoc.ChildNodes[0].Name);//打印节点名称
            Console.WriteLine("Node library MoveToContent()： " + xmlNode.MoveToContent());//如果有下一个节点，直接指向下一个节点
            Console.WriteLine("Node library AttributeCount: " + xmlNode.AttributeCount);//打印属性数量
            Console.WriteLine("Node library MoveToAttribute(\"id\"): " + xmlNode.MoveToAttribute("id"));//获取该属性节点的值
            Console.WriteLine("Node library Value: " + xmlNode.Value);//打印获取值
            Console.WriteLine("Node library name: " + xdoc.GetElementsByTagName("library")[0].Name);//打印节点名称
            Console.WriteLine("Node library attr id: " + xdoc.GetElementsByTagName("library")[0].Attributes["id"].Value);//打印节点属性值
            Console.WriteLine("Node name innertext: " + xdoc.GetElementsByTagName("name")[0].InnerText);//打印节点值
            Console.WriteLine("Node name attr count: " + xdoc.GetElementsByTagName("name")[0].Attributes.Count);//打印属性数量
            Console.WriteLine("Node name attr txt value: " + xdoc.GetElementsByTagName("name")[0].Attributes["txt"].Value);//打印属性值
            Console.WriteLine("XmlDocument Name: " + xdoc.DocumentElement.Name);
            Console.WriteLine("XmlDocument FirstChild Name: " + xdoc.DocumentElement.FirstChild.Name);

            XmlNodeList nodeList = xdoc.DocumentElement.ChildNodes;
            foreach (XmlElement xe in nodeList)
            {
                Console.WriteLine(xdoc.DocumentElement.Name + " Child Name:" + xe.Name);
            }
            nodeList = xdoc.DocumentElement.FirstChild.ChildNodes;
            foreach (XmlElement xe in nodeList)
            {
                Console.WriteLine(xe.InnerText);
                if (xe.HasAttributes)
                {
                    Console.WriteLine(xe.Attributes.Count);
                    for (int i = 0; i < xe.Attributes.Count; i++)
                        Console.WriteLine(xe.Attributes[i].Name);
                    Console.WriteLine(xe.Attributes["id"].Value);
                    Console.WriteLine(xe.Attributes["txt"].Value);
                }
            }
        }
    }
}