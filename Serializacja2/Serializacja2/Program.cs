using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Serializacja2
{
    public class Person : IXmlSerializable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person()
        {
        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("FirstName", FirstName);
            writer.WriteAttributeString("LastName", LastName);
            writer.WriteAttributeString("Age", Age.ToString());
        }

        public void ReadXml(XmlReader reader)
        {
            FirstName = reader.GetAttribute("FirstName");
            LastName = reader.GetAttribute("LastName");
            Age = int.Parse(reader.GetAttribute("Age"));
        }

        public XmlSchema GetSchema()
        {
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Jan", "Kowalski", 20);

            XmlSerializer xs = new XmlSerializer(typeof(Person));

            using (FileStream s = new FileStream("osoba.xml", FileMode.Create))
            {
                xs.Serialize(s, p);
            }

            using (FileStream s = new FileStream("osoba.xml", FileMode.Open))
            {
                Person p2 = (Person)xs.Deserialize(s);

                Console.WriteLine("First Name: {0}", p2.FirstName);
                Console.WriteLine("Last Name: {0}", p2.LastName);
                Console.WriteLine("Age: {0}", p2.Age);
            }
        }
    }
}