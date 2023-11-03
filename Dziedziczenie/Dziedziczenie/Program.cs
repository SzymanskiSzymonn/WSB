namespace Dziedziczenie
{
    class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }

        public Person(string name, string surName, DateTime dateOfBirth)
        {
            this.Name = name;
            this.SurName = surName;
            this.DateOfBirth = dateOfBirth;
        }
        public Person(string name, string surName, DateTime dateOfBirth, Address address) : this(name, surName, dateOfBirth)
        {
            this.Address = address;
        }

        public string GetFullName()
        {
            return $"{this.Name} {this.SurName}";
        }

        public int Age
        {
            get
            {
                TimeSpan difference = DateTime.Now - this.DateOfBirth;
                
                return (int)(difference.Days / 365.25);
            }
        }
    }

    class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }

        public Address(string city, string street, string houseNumber, string postalCode)
        {
            this.City = city;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.PostalCode = postalCode;
        }
    }

    class Student : Person
    {
        public string StudentNumber { get; set; }

        public Student(string name, string surName, DateTime dateOfBirth, string studentNumber) : base (name, surName, dateOfBirth)
        {
            this.StudentNumber = studentNumber;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
/*
•	Zdefiniuj klasę pochodną Teacher, która dziedziczy po klasie Person i ma dodatkowe pole subjects typu List<string> oraz konstruktor przyjmujący te wartości jako parametry.
•	Utwórz obiekty każdej klasy, używając słowa kluczowego new i podając odpowiednie wartości w konstruktorach.
•	Wyświetl dane utworzonych obiektów, używając metody Console.WriteLine i właściwości obiektów.
*/