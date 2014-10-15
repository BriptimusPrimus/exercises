using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Linq;

namespace _00LinqToXmlFirstLook
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildXmlDocWithDOM();
        }

        private static void BuildXmlDocWithDOM()
        {
            // Make a new XML document in memory.
            XmlDocument doc = new XmlDocument();

            // Fill this document with a root element
            // named <Inventory>.
            XmlElement inventory = doc.CreateElement("Inventory");

            // Now, make a subelement named <Car> with
            // an ID attribute.
            XmlElement car = doc.CreateElement("Car");
            car.SetAttribute("ID", "1000");

            // Build the data within the <Car> element.
            XmlElement name = doc.CreateElement("PetName");
            name.InnerText = "Jimbo";
            XmlElement color = doc.CreateElement("Color");
            color.InnerText = "Red";
            XmlElement make = doc.CreateElement("Make");
            make.InnerText = "Ford";

            // Add <PetName>, <Color>, and <Make> to the <Car>
            // element.
            car.AppendChild(name);
            car.AppendChild(color);
            car.AppendChild(make);

            // Add the <Car> element to the <Inventory> element.
            inventory.AppendChild(car);

            // Insert the complete XML into the XmlDocument object,
            // and save to file.
            doc.AppendChild(inventory);
            doc.Save("Inventory.xml");
        }

        private static void BuildXmlDocWithLINQToXml()
        {
            // Create an XML document in a more "functional" manner.
            XElement doc =
                new XElement("Inventory",
                    new XElement("Car", new XAttribute("ID", "1000"),
                        new XElement("PetName", "Jimbo"),
                        new XElement("Color", "Red"),
                        new XElement("Make", "Ford")
                    )
                );

            // Save to file.
            doc.Save("InventoryWithLINQ.xml");
        }

    }
}
