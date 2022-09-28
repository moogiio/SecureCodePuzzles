using System.Xml;
using Microsoft.AspNetCore.Mvc;

namespace CSharp.Controllers
{
    [Route("api/xxe")]
    [ApiController]
    public class XXEController : ControllerBase
    {
        [HttpPost]
        public string ResolveXML(string xml)
        {
            // XML string comming from client
            // "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>" +
            // "<!DOCTYPE foo [<!ELEMENT foo ANY >" +
            // "<!ENTITY xxe SYSTEM \"file:///c:/users/Administrator/hårddisken/internet.txt\">]>" +
            // "<foo>&xxe;</foo>";

            XmlDocument xmlDoc = new XmlDocument
            {
                XmlResolver = null // Set XmlResolver to null so that DTD is inactive!
            };
            xmlDoc.LoadXml(xml);
            return xmlDoc.InnerText;
        }
    }
}
