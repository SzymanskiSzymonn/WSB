using System.Diagnostics.CodeAnalysis;

namespace Interfejsy
{
    class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public Book (string title, string author, int year, double price)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.Price = price;
        }
        int IComparable<Book>.CompareTo([AllowNull] Book other)
        //int IComparable<Book>.CompareTo(Book? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }
        public override string ToString()
        {
            return $"{this.Title}, {this.Author}, {this.Year}, {this.Price}zł";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> list = new List<Book>();
            list.Add(new Book("asd", "qwe", 2000, 80));
            list.Add(new Book("bnm", "iop", 1999, 40));
            list.Add(new Book("bnm", "iop", 1700, 40));
            list.Add(new Book("bnm", "iop", 1999, 12));
            list.Add(new Book("zxc", "rty", 1800, 20));

            Console.WriteLine("\nLista książek:");

            foreach (Book book in list)
                Console.WriteLine(book);

            list.Sort();
            Console.WriteLine("\nPosortowane wg ceny:");

            foreach (Book book in list)
                Console.WriteLine(book);

            Console.WriteLine("\nPosortowane wg tytułu:");
            var sortedByTitle = list.OrderBy(x => x.Title);

            foreach (Book book in sortedByTitle)
                Console.WriteLine(book);

            Console.WriteLine("\nPosortowane wg autora:");
            var sortedByAuthor = list.OrderBy(x => x.Author);

            foreach (Book book in sortedByAuthor)
                Console.WriteLine(book);

            Console.WriteLine("\nPosortowane wg roku wydania:");
            var sortedByYear = list.OrderBy(x => x.Year);

            foreach (Book book in sortedByYear)
                Console.WriteLine(book);

            Console.WriteLine("Posortowane nierosnąco wg ceny i od najstarszej książki:");
            var sortedByPriceThenYear = list.OrderByDescending(x => x.Price).ThenBy(x=>x.Year);

            foreach (Book book in sortedByPriceThenYear)
                Console.WriteLine(book);

        }
    }
}