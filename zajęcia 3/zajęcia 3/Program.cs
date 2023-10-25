
namespace zajęcia_3
{
    internal class Program
    {
       static void Main(string[] args)
        {
            //Osoba osoba = new Osoba();
            // osoba.Imie = "Janusz";
            //osoba.Nazwisko = "Nowak";
            //osoba.UstawDane(osoba.Imie, osoba.Nazwisko);
            //Console.WriteLine("Nazywam sie: {0} {1}", osoba.Imie, osoba.Nazwisko);
            //Console.WriteLine(osoba.PrzedstawSie());

            //osoba.UstawDane("Janusz","Kowalski");
            //Console.WriteLine(osoba.PrzedstawSie());

            //osoba.Imie = "Szymon";
            //Console.WriteLine(osoba.PrzedstawSie());

            /*Adres adres = new Adres 
            {
                Ulica = "Polna",
                NrDomu = "10",
                NrMieszkania = "2",
                KodPocztowy = "12-345",
                Miasto = "Poznań",
                Panstwo = "Polska"
            };
            Osoba nowak = new Osoba("Franek","Kowalski", adres);
            Console.WriteLine(nowak.PrzedstawSie());
            */
            Console.WriteLine("Podaj liczbe kontaktów do wprowadzenia");
            int n = int.Parse(Console.ReadLine());

            List<string> imiona = new List<string>();
            List<string> nazwiska = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"Podaj imie {i} kontktu: ");
                string imie = Console.ReadLine();
                imiona.Add(imie);

                Console.Write($"Podaj nazwisko {i} kontktu: ");
                string nazwisko = Console.ReadLine();
                nazwiska.Add(nazwisko);
            }
            Console.WriteLine("\nLista  kontaktow");
            for (int i = 0;i < n; i++)
            {
                Console.WriteLine($"{i+1} {imiona[1]} {nazwiska[i]}");
            }
        }
       
    }
}