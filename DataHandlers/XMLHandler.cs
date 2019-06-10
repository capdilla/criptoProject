using System;
using System.Xml;

namespace DataHandlers
{
    public class XMLHandler
    {
        XmlTextWriter xmlTextWritter;
        XmlDocument xmlDocumentReader;
        public XMLHandler()
        {
            this.xmlDocumentReader = new XmlDocument();
        }

        public String [] readTdesKeys(String route)
        {         
            String[] keys = new String[3];
            this.xmlDocumentReader.Load(route);
            //Iterate three times over the keys, that allow scalable alrogithms
            for (int i = 0; i < keys.Length; i++)
            {
                XmlNode key = xmlDocumentReader.DocumentElement.SelectSingleNode("tdes"+(i+1));                
                keys[i] = key.InnerText;                
            }
            return keys;
        }
        public string readInitializationVector(String route)
        {            
            string initializationVector="";
            this.xmlDocumentReader.Load(route);
            XmlNode iv = xmlDocumentReader.DocumentElement.SelectSingleNode("iv");
            initializationVector = iv.InnerText;
            return initializationVector;           
        }
        public string readRsaPublicKey(string route)
        {            
            string publicRsaKey = "";
            this.xmlDocumentReader.Load(route);
            XmlNodeList elemList = this.xmlDocumentReader.GetElementsByTagName("clavepublica");
            if (elemList.Count > 0)
            {
                publicRsaKey = elemList[0].InnerText;
            }

            Console.WriteLine(publicRsaKey);
            return publicRsaKey;
        }

        public void exportTdesKeys(string route,string [] keys,string initializationVector)
        {            
            this.xmlTextWritter = new XmlTextWriter(route, null);
            // Opens the document  
            xmlTextWritter.WriteStartDocument();
            xmlTextWritter.WriteStartElement("root");
            for (int i = 0; i < keys.Length; i++)
            {
                xmlTextWritter.WriteStartElement("tdes" + (i + 1));
                xmlTextWritter.WriteString(keys[i]);
                xmlTextWritter.WriteEndElement();
            }
            xmlTextWritter.WriteStartElement("iv");
            xmlTextWritter.WriteString(initializationVector);
            xmlTextWritter.WriteEndElement();
            xmlTextWritter.WriteEndElement();
            xmlTextWritter.WriteEndDocument();            
            xmlTextWritter.Close();
        }

        public void exportRsaPublicKey(string route, String key)
        {            
            this.xmlTextWritter = new XmlTextWriter(route, null);
            // Opens the document  
            xmlTextWritter.WriteStartDocument();
            xmlTextWritter.WriteStartElement("root");
            xmlTextWritter.WriteStartElement("clavepublica");
            xmlTextWritter.WriteString(key);
            xmlTextWritter.WriteEndElement();
            xmlTextWritter.WriteEndElement();
            xmlTextWritter.WriteEndDocument();
            // close writer  
            xmlTextWritter.Close();
        }

        public string readEncryptedText(string route)
        {            
            return this.readNode(route, "textoe");            
        }

        public void exportEncrytpedText(string route,string message)
        {            
            this.xmlTextWritter = new XmlTextWriter(route, null);
            // Opens the document  
            xmlTextWritter.WriteStartDocument();
            xmlTextWritter.WriteStartElement("root");
            xmlTextWritter.WriteStartElement("textoe");
            xmlTextWritter.WriteString(message);
            xmlTextWritter.WriteEndElement();
            xmlTextWritter.WriteEndElement();
            xmlTextWritter.WriteEndDocument();            
            xmlTextWritter.Close();
        }

        public string readNode(string route,string nodeName)
        {            
            this.xmlDocumentReader.Load(route);
            String nodeValue="";

            XmlNode node = xmlDocumentReader.DocumentElement.SelectSingleNode(nodeName);
            if (node != null) {
                nodeValue = node.InnerText;
            }                        
            return nodeValue;
        }
        
    }
}
