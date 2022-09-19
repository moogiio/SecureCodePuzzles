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
            // "<!ENTITY xxe SYSTEM \"file:///c:/users/hårddisken/internet.txt\">]>" +
            // "<foo>&xxe;</foo>";

            XmlDocument xmlDoc = new XmlDocument
            {
                XmlResolver = null // <--- XmlResolver sätts till null för att inaktivera DTDs!
            };
            xmlDoc.LoadXml(xml);
            return xmlDoc.InnerText;
        }
    }
}
