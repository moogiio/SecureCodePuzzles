const libxmljs = require('libxmljs');

const xml = `<?xml version="1.0" ?><!DOCTYPE foo [<!ENTITY xxe SYSTEM "EXTERNAL_FILE">]> <product id="1"> <description>&xxe;</description></product>`;

function parseXmlSecurely() {
  try {
    const xmlDoc = libxmljs.parseXml(xml, {
      nonet: true,  // Disable network access
      recover: true,  // Recover from errors
      noent: false,  // Don't substitute entities
      dtdload: false,  // Don't load external DTDs
      dtdattr: false,  // Don't default DTD attributes
    });
    return xmlDoc.root().text();
  } catch (error) {
    console.error('XML parsing error:', error);
    return null;
  }
}

console.log(parseXmlSecurely());