using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DesignPatternsDemo
{
    public class CarManfacturer
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public int Year { get; set; }
    }

    public class ManfacturerDataProvider
    {
        public static List<CarManfacturer> GetData() =>
            new List<CarManfacturer>()
            {
            new CarManfacturer{Name="Ferrari",Country="Italy" ,Year=1965},
            new CarManfacturer{Name="Tesla",Country="USA" ,Year=2015},
            new CarManfacturer{Name="Volksvagen",Country="Germany" ,Year=1978},
            new CarManfacturer{Name="Nissan",Country="Japan" ,Year=1982},
            };
    }

    public class XMLConverter
    {
        public XDocument GetXML()
        {
            var xDocument = new XDocument();
            var xElement = new XElement("Manufacturers");
            var xAttributes = ManfacturerDataProvider.GetData()
                .Select(m => new XElement("CarManfacturer", new XAttribute("City", m.Country), new XAttribute("Name", m.Name), new XAttribute("Year", m.Year)));
            xElement.Add(xAttributes);
            xDocument.Add(xElement);
            Console.WriteLine(xDocument);
            return xDocument;
        }
    }

        public class CarJSONConverter
        {
            private IEnumerable<CarManfacturer> _manfacturers;

            public CarJSONConverter(IEnumerable<CarManfacturer> manfacturers)
            {
                _manfacturers = manfacturers;
            }

            public void ConvertToJSON()
            {
                var jsonManufacturers = JsonConvert.SerializeObject(_manfacturers, Newtonsoft.Json.Formatting.Indented);
                Console.WriteLine("\n Printing JSON list \n");
                Console.WriteLine(jsonManufacturers);
            }
        }

        public interface IXmlToJSON
        {
            void ConvertToJSON();
        }

        public class XMLToJSONParser : IXmlToJSON
        {
            private readonly XMLConverter _xMLConverter;

            public XMLToJSONParser(XMLConverter xMLConverter)
            {
                _xMLConverter = xMLConverter;
            }

            public void ConvertToJSON()
            {
                var manufacturers = _xMLConverter.GetXML().Element("Manufacturers").Elements("CarManfacturer")
                                   .Select(m => new CarManfacturer
                                   {
                                       Country = m.Attribute("Country").Value,
                                       Name = m.Attribute("Name").Value,
                                       Year = Convert.ToInt32(m.Attribute("Year").Value)
                                   });
                new CarJSONConverter(manufacturers).ConvertToJSON();
            }
        }
    }
