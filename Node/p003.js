const { DOMParser } = require('xmldom');
const fs = require('fs');

const xml = `<?xml version="1.0" ?><!DOCTYPE foo [<!ENTITY xxe SYSTEM "EXTERNAL_FILE">]> <product id="1"> <description>&xxe;</description></product>`;

function parseXmlDocument() {
  const parser = new DOMParser();
  const xmlDoc = parser.parseFromString(xml, 'text/xml');
  return xmlDoc.documentElement.textContent;
}

function parseXmlReader() {
  const parser = new DOMParser({
    resolveExternalEntities: true
  });
  const xmlDoc = parser.parseFromString(xml, 'text/xml');
  return xmlDoc.documentElement.textContent;
}

console.log(parseXmlDocument());
console.log(parseXmlReader());