using System.Xml;
using Microsoft.AspNetCore.Mvc;

namespace CSharp.Controllers
{
    [Route("api/xxe")]
    [ApiController]
    public class XXEController : ControllerBase
    {
        [HttpPost]
        public XDocument StringToXml(string input)
        {
            /*
                <?xml version="1.0" encoding="ISO-8859-1"?>
                <!DOCTYPE foo [
                <!ELEMENT foo ANY >
                <!ENTITY % xxe SYSTEM "http://internal.service/secret_pass.txt" >
                ]>
                <foo>&xxe;</foo>
            */

            using(StringReader tr = new StringReader(input))
            {
                XDocument doc = XDocument.Load(tr);
                return doc;
            }
        }
    }
}
