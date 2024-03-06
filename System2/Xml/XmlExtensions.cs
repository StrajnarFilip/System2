using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace System2.Xml
{
    using System.Xml;

    public static class XmlExtensions
    {
        public static XmlDocument LoadXmlDocumentFromString(this string xml)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            return xmlDocument;
        }

        public static XmlDocument LoadXmlDocumentFromFile(this string xmlFileUrl)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlFileUrl);
            return xmlDocument;
        }

        public static XmlDocument LoadXmlDocumentFromFile(this Stream xmlStream)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlStream);
            return xmlDocument;
        }

        public static XmlDocument LoadXmlDocumentFromFile(this XmlReader xmlReader)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlReader);
            return xmlDocument;
        }

        public static IEnumerable<XmlNode> GetChildNodes(this XmlNode xmlNode)
        {
            return xmlNode.ChildNodes.Cast<XmlNode>();
        }

        public static IEnumerable<XmlAttribute> GetAttributes(this XmlNode xmlNode)
        {
            return xmlNode.Attributes is null
                ? Array.Empty<XmlAttribute>()
                : xmlNode.Attributes.Cast<XmlAttribute>();
        }

        public static XmlNode FindChildNodeByName(this XmlNode xmlNode, string name)
        {
            return xmlNode.GetChildNodes().First(node => node.Name == name);
        }

        public static IEnumerable<XmlNode> FindChildNodesByName(this XmlNode xmlNode, string name)
        {
            return xmlNode.GetChildNodes().Where(node => node.Name == name);
        }

        public static XmlAttribute FindAttributeByName(this XmlNode xmlNode, string attributeName)
        {
            return xmlNode.GetAttributes().First(attribute => attribute.Name == attributeName);
        }

        public static string AttributeValue(this XmlNode xmlNode, string attributeName)
        {
            return xmlNode.FindAttributeByName(attributeName).Value;
        }
    }
}
