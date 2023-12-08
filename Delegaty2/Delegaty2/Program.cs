namespace Delegaty2
{
    public delegate bool Logic(bool x, bool y);
    internal class Program
    {
        public static bool And(bool x, bool y)
        {
            return x && y;
        }
        public static bool Or(bool x, bool y)
        {
            return x || y;
        }
        public static bool Xor(bool x, bool y)
        {
            return x ^ y;
        }
        public static bool Not(bool x, bool y)
        {
            return !x;
        }
        static void Main(string[] args)
        {
            bool a = GetBoolFromUser("Podaj pierwszą wartość 'true' lub 'false': ");
            bool b = GetBoolFromUser("Podaj drugą wartość 'true' lub 'false': ");

            DisplayResutl(new Logic(And), a, b);
            DisplayResutl(new Logic(Or), a, b);
            DisplayResutl(new Logic(Xor), a, b);
            DisplayResutl(new Logic(Not), a, b);
        }

        public static void DisplayResutl(Logic logic, bool x, bool y)
        {
            bool result;
            if ((x != true && x != false) || (y != true && y != false))
            {
                Console.WriteLine("\nWartość null!\n\n");
            }
            else
            {
                result = logic(x, y);
                Console.WriteLine("Wynik operacji {0} na wartościach {1} i {2} wynosi: {3}", logic.Method.Name, x, y, result);
            }
        }

        public static bool GetBoolFromUser (string prompt)
        {
            Console.Write(prompt);
            bool value;
            string input = Console.ReadLine();
            bool isValid = bool.TryParse(input, out value) && (value == true || value == false);

            while (!isValid)
            {
                Console.WriteLine("\nNieprawidłowe dane. Podaj wartość 'true' albo 'false'");
                input = Console.ReadLine();
                isValid = bool.TryParse(input, out value) && (value == true || value == false);
            }
            return value;
        }
    }
}