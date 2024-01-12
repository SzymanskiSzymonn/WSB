using System.Xml.Serialization;

namespace Serializacja
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { FirstName = "Franek", LastName = "Kowalski", Age = 20 };
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (FileStream fileStream = new FileStream("osoba.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fileStream, person);
            }
        }
    }
}