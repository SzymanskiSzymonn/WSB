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

        public Student(string name, string surName, DateTime dateOfBirth, Address address, string studentNumber) : base (name, surName, dateOfBirth, address)
        {
            this.StudentNumber = studentNumber;
        }
    }

    class Teacher : Person
    {
        public List<string> Subjects {  get; set; }

        public Teacher(string name, string surName, DateTime dateOfBirth, Address address, List<string> subjects) : base(name, surName, dateOfBirth, address)
        {
            Subjects = subjects;
        }
    }

    internal class Program
    {
        public static List<Person> persons = new List<Person> ();
        public static List<Student> students = new List<Student>();
        public static List<Teacher> teachers = new List<Teacher>();

        static int DisplayMenu()
        {
            Console.WriteLine("\n\nProgram do zarządzania użytkownikami:\n");
            Console.WriteLine("1: Dodaj użytkownika");
            Console.WriteLine("2: Odczytaj użytkowników");
            Console.WriteLine("3: Usuń wszystkich użytkowników");
            Console.WriteLine("4. Wyjście");
            
            return int.Parse(Console.ReadLine());
        }

        static void AddUser()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nWybierz typ użytkownika:");
                Console.WriteLine("1: Osoba");
                Console.WriteLine("2: Student");
                Console.WriteLine("3: Nauczyciel");
                Console.WriteLine("4: Powrót");

                int opcja = Convert.ToInt32(Console.ReadLine());

                switch(opcja)
                {
                    case 1:
                        Console.WriteLine("Imię: ");
                        string pname = Console.ReadLine();
                        Console.WriteLine("Nazwisko: ");
                        string psurname = Console.ReadLine();
                        Console.WriteLine("Data urodzenia (RRRR-MM-DD): ");
                        DateTime pdateOfBirth = DateTime.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Miasto: ");
                        string pcity = Console.ReadLine();
                        Console.WriteLine("Ul: ");
                        string pstreetName = Console.ReadLine();
                        Console.WriteLine("Nr: ");
                        string phouseNumber = Console.ReadLine();
                        Console.WriteLine("Kod: ");
                        string ppostalCode = Console.ReadLine();
                        
                        Address paddress = new Address(pcity, pstreetName, phouseNumber, ppostalCode);

                        Person person = new Person(pname, psurname, pdateOfBirth, paddress);
                        persons.Add(person);
                        break;
                    case 2:
                        Console.WriteLine("Imię: ");
                        string sname = Console.ReadLine();
                        Console.WriteLine("Nazwisko: ");
                        string ssurname = Console.ReadLine();
                        Console.WriteLine("Data urodzenia (RRRR-MM-DD): ");
                        DateTime sdateOfBirth = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Miasto: ");
                        string scity = Console.ReadLine();
                        Console.WriteLine("Ul: ");
                        string sstreetName = Console.ReadLine();
                        Console.WriteLine("Nr: ");
                        string shouseNumber = Console.ReadLine();
                        Console.WriteLine("Kod: ");
                        string spostalCode = Console.ReadLine();

                        Console.WriteLine("Nr studenta: ");
                        string studentNumber = Console.ReadLine();

                        Address saddress = new Address(scity, sstreetName, shouseNumber, spostalCode);

                        Student student = new Student(sname, ssurname, sdateOfBirth, saddress, studentNumber);
                        students.Add(student);
                        break;
                    case 3:
                        Console.WriteLine("Imię: ");
                        string tname = Console.ReadLine();
                        Console.WriteLine("Nazwisko: ");
                        string tsurname = Console.ReadLine();
                        Console.WriteLine("Data urodzenia (RRRR-MM-DD): ");
                        DateTime tdateOfBirth = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Podaj liczbę przedmiotów");
                        int amount = Convert.ToInt32(Console.ReadLine());

                        List<string> subjects = new List<string>();
                        for (int i = 0; i < amount; i++)
                        {
                            Console.WriteLine($"Podaj przedmiot {i + 1}: ");
                            string subject = Console.ReadLine();
                            subjects.Add(subject);
                        }

                        Console.WriteLine("Miasto: ");
                        string tcity = Console.ReadLine();
                        Console.WriteLine("Ul: ");
                        string tstreetName = Console.ReadLine();
                        Console.WriteLine("Nr: ");
                        string thouseNumber = Console.ReadLine();
                        Console.WriteLine("Kod: ");
                        string tpostalCode = Console.ReadLine();

                        Address taddress = new Address(tcity, tstreetName, thouseNumber, tpostalCode);

                        Teacher teacher = new Teacher(tname, tsurname, tdateOfBirth, taddress, subjects);
                        teachers.Add(teacher);
                        break;
                    case 4:
                        return;
                }
            }
        }

        static void DisplayUsers()
        {
            Console.Clear ();
            if(persons.Count == 0)
            {
                Console.WriteLine("Nie ma żadnych użytkowników");
            }
            else
            {
                Console.WriteLine("\nLista osób:\n");

                int count = 1;
                foreach (Person person in persons)
                {
                    Console.WriteLine($"Użytkownik {count}:");
                    Console.WriteLine($"Imię: {person.Name} Nazwisko: {person.SurName} Data urodzenia: {person.DateOfBirth.ToShortDateString()}\nMiasto: {person.Address.City} Ul: {person.Address.Street} Nr: {person.Address.HouseNumber} Kod: {person.Address.PostalCode}\n\n");
                    count++;
                }
            }
            if (students.Count == 0)
            {
                Console.WriteLine("Nie ma żadnych studentów");
            }
            else
            {
                Console.WriteLine("\nLista studentów:\n");

                int count = 1;
                foreach (Student student in students)
                {
                    Console.WriteLine($"Student {count}:");
                    Console.WriteLine($"Imię: {student.Name} Nazwisko: {student.SurName} Data urodzenia: {student.DateOfBirth.ToShortDateString()} Nr: {student.StudentNumber}\nMiasto: {student.Address.City} Ul: {student.Address.Street} Nr: {student.Address.HouseNumber} Kod: {student.Address.PostalCode}\n\n");
                    count++;
                }
            }
            if (teachers.Count == 0)
            {
                Console.WriteLine("Nie ma żadnych nauczycieli");
            }
            else
            {
                Console.WriteLine("\nLista nauczycieli:\n");

                int count = 1;
                foreach (Teacher teacher in teachers)
                {
                    Console.WriteLine($"Nauczyciel {count}:");
                    Console.WriteLine($"Imię: {teacher.Name} Nazwisko: {teacher.SurName} Data urodzenia: {teacher.DateOfBirth.ToShortDateString()} Przedmioty: {string.Join(", ", teacher.Subjects)}\nMiasto: {teacher.Address.City} Ul: {teacher.Address.Street} Nr: {teacher.Address.HouseNumber} Kod: {teacher.Address.PostalCode}\n\n");
                    count++;
                }
            }
        }

        static void ClearUsers()
        {
            persons.Clear();
            students.Clear();
            teachers.Clear();
        }

        static void Main(string[] args)
        {
            while(true)
            {
                switch(DisplayMenu())
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        DisplayUsers();
                        break;
                    case 3:
                        ClearUsers();
                        break;
                    case 4:
                        Console.WriteLine("\nDziękujemy za skorzystanie z programu.\n");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja, spróbuj ponownie");
                        break;
                }
            }
        }
    }
}