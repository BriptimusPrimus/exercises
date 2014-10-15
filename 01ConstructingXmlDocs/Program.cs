using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace _01ConstructingXmlDocs
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateFullXDocument();
            CreateRootAndChildren();
            MakeXElementFromArray();
            ParseAndLoadExistingXml();
            Console.ReadLine();
        }

        static void CreateFullXDocument()
        {
            XDocument inventoryDoc =
              new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Current Inventory of cars!"),
                new XProcessingInstruction("xml-stylesheet",
                  "href='MyStyles.css' title='Compact' type='text/css'"),
                new XElement("Inventory",
                  new XElement("Car", new XAttribute("ID", "1"),
                    new XElement("Color", "Green"),
                    new XElement("Make", "BMW"),
                    new XElement("PetName", "Stan")
                  ),
                  new XElement("Car", new XAttribute("ID", "2"),
                    new XElement("Color", "Pink"),
                    new XElement("Make", "Yugo"),
                    new XElement("PetName", "Melvin")
                  )
                )
              );

            // Save to disk.
            inventoryDoc.Save("SimpleInventory.xml");
        }

        static void CreateRootAndChildren()
        {
            XElement inventoryDoc =
              new XElement("Inventory",
              new XComment("Current Inventory of cars!"),
                new XElement("Car", new XAttribute("ID", "1"),
                new XElement("Color", "Green"),
                new XElement("Make", "BMW"),
                new XElement("PetName", "Stan")
              ),
              new XElement("Car", new XAttribute("ID", "2"),
                new XElement("Color", "Pink"),
                new XElement("Make", "Yugo"),
                new XElement("PetName", "Melvin")
                )
              );

            // Save to disk.
            inventoryDoc.Save("SimpleInventory.xml");
        }

        static void MakeXElementFromArray()
        {
            // Create an anonymous array of anonymous types.
            var people = new[] {
                new { FirstName = "Mandy", Age = 32},
                new { FirstName = "Andrew", Age  = 40 },
                new { FirstName = "Dave", Age  = 41 },
                new { FirstName = "Sara", Age  = 31}
            };

            var arrayDataAsXElements = from c in people
                                       select
                                         new XElement("Person",
                                           new XAttribute("Age", c.Age),
                                           new XElement("FirstName", c.FirstName));

            XElement peopleDoc = new XElement("People", arrayDataAsXElements);
            Console.WriteLine(peopleDoc);
        }

        static void ParseAndLoadExistingXml()
        {
            // Build an XElement from string.
            string myElement =
              @"<Car ID ='3'>
                  <Color>Yellow</Color>
                  <Make>Yugo</Make>
                </Car>";
            XElement newElement = XElement.Parse(myElement);
            Console.WriteLine(newElement);
            Console.WriteLine();

            // Load the SimpleInventory.xml file.
            XDocument myDoc = XDocument.Load("SimpleInventory.xml");
            Console.WriteLine(myDoc);
        }

    }
}
