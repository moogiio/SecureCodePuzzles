namespace CSharp.Controllers
{
    public class XxeController : Controller
    {
        private static string _xml = "<?xml version=\"1.0\" ?><!DOCTYPE foo [<!ENTITY xxe SYSTEM \"_EXTERNAL_FILE_\">]> <product id=\"1\"> <description>&xxe;</description></product>";

        public static string ParseXmlDocument()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.XmlResolver = new XmlUrlResolver(); // XmlDocuments becomes vulerable when initializing an XmlUrlResolver.
            xmlDocument.LoadXml(_xml);
            return xmlDocument.InnerText;
        }

        public static string ParseXmlReader(){
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Prohibit;
            settings.MaxCharactersFromEntities = 6000;
            settings.DtdProcessing = DtdProcessing.Parse; // XmlReader becomes vulernable if DtdProcessing is set to Parse
            settings.XmlResolver = new XmlUrlResolver(); // and XmlResolver is initialized

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                XmlReader reader = XmlReader.Create(stream, settings);

                var xmlDocument = new XmlDocument();
                xmlDocument.XmlResolver = new XmlUrlResolver();
                xmlDocument.Load(reader);
                return xmlDocument.InnerText;
            }
        }
    }
}   