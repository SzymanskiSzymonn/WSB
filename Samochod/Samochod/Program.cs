﻿namespace Samochod
{
    internal class Program
    {
        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public Engine Engine { get; set; }

            public Car(string brand, string model, Engine engine)
            {
                this.Brand = brand;
                this.Model = model;
                this.Engine = engine;
            }

            public Car(string brand, string model, double capacity, double fuelAmount)
            {
                this.Brand = brand;
                this.Model = model;
                this.Engine.Capacity = capacity;
                this.Engine.FuelAmount = fuelAmount;
            }

            public Car(string brand, string model, double capacity, double fuelAmount, double fuelTankCapacity)
            {
                this.Brand = brand;
                this.Model = model;
                this.Engine = new Engine(capacity, fuelAmount, fuelTankCapacity);
            }

            public void Drive(int distance)
            {
                Console.WriteLine("Jadę");
                for (int i = 0; i < distance; i++)
                {
                    if (i % 100 == 0)
                        Console.Write("\n>");
                    else
                        Console.Write(">");
                    Thread.Sleep(100);
                }
                
                Engine.Work(distance);
            }

            public void Refuel(double fuelAmount)
            {
                if (Engine.FuelAmount + fuelAmount > Engine.FuelTankCapacity)
                    throw new Exception("Za dużo paliwa");

                Engine.FuelAmount += fuelAmount;
            }
        }

        class Engine
        {
            public double Capacity { get; set; }
            public double FuelAmount { get; set; }
            public double FuelTankCapacity { get; } = 50.0;

            public Engine(double capacity, double fuelAmount)
            {
                this.Capacity = capacity;
                this.FuelAmount = fuelAmount;
                this.FuelTankCapacity = 40.0;
            }

            public Engine(double capacity, double fuelAmount, double fuelTankCapacity) : this(capacity, fuelAmount)
            {
                this.FuelTankCapacity = fuelTankCapacity;
            }

            public static double ConvertLitersPer100KmToMilesPerGallon(double literesPer100Km)
            {
                return 235.214583 / literesPer100Km;
            }

            public static double ConvertMilesPerGallonToLiteresPer100Km(double milesPerGallon)
            {
                return 235.214583 / milesPerGallon;
            }

            public void Work(int distance)
            {
                double fuelConsumption = (Capacity * distance * 4) / 100;
                if (FuelAmount < fuelConsumption)
                    throw new Exception("Brak paliwa");

                FuelAmount -= fuelConsumption;
                Console.WriteLine("\nJestem");
            }
        }

        static void Main(string[] args)
        {
            /*
            Console.WriteLine(Engine.ConvertLitersPer100KmToMilesPerGallon(8)); //29,401822875 
            Console.WriteLine(Engine.ConvertMilesPerGallonToLiteresPer100Km(29.401822875)); //8

            Engine e = new Engine(2, 25.5);
            Console.WriteLine(e.FuelTankCapacity); //40

            Engine e2 = new Engine(1, 20, 30);
            Console.WriteLine(e2.FuelTankCapacity); //30

            Console.WriteLine("\n#########################\n\n");

            Car car = new Car("Fiat", "126p", 1, 20, 40);
            Console.WriteLine($"Marka: {car.Brand}, model: {car.Model}\nPojemność silnika: {car.Engine.Capacity}, ilość paliwa: {car.Engine.FuelAmount}, Pojemność baku: {car.Engine.FuelTankCapacity}\n\n");

            car.Drive(100);

            Console.WriteLine($"\nIlość paliwa: {car.Engine.FuelAmount}\n\n");

            //car.Refuel(100);
            car.Refuel(7);
            Console.WriteLine($"\nIlość paliwa: {car.Engine.FuelAmount}\n\n");
            */
            Console.WriteLine("Witamy w symulatorze jazdy samochodem!\n");

            Console.WriteLine("Podaj markę swojego samochodu: ");
            string brand = Console.ReadLine();
            Console.WriteLine("Podaj model swojego samochodu: ");
            string model = Console.ReadLine();
            Console.WriteLine("Podaj pojemność swojego samochodu: ");
            double capacity = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj ilość paliwa swojego samochodu: ");
            double fuelAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj pojemność baku swojego samochodu: ");
            double fuelTankCapacity = Convert.ToDouble(Console.ReadLine());

            Car car = new Car(brand, model, capacity, fuelAmount, fuelTankCapacity);

            //Console.WriteLine($"{car.Brand} {car.Model} {car.Engine.Capacity} {car.Engine.FuelAmount} {car.Engine.FuelTankCapacity}");

            Thread.Sleep(2000);
            Console.Clear();
            
            while(true)
            {
                Console.WriteLine("\n\n1: Jadę");
                Console.WriteLine("2: Tankuję");
                Console.WriteLine("3: Ile mam paliwa");
                Console.WriteLine("4: Dane mojego auta");
                Console.WriteLine("5: Wyjście z programu");

                Console.Write("\n\nWybierz opcję: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("\nPodaj dystans jaki chcesz przejechać: ");
                            int distance = int.Parse(Console.ReadLine());
                            car.Drive(distance);
                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine("\nPodaj liczbę paliwa do zatankowania: ");
                            double refuelAmount = double.Parse(Console.ReadLine());
                            car.Refuel(refuelAmount);
                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine($"\nMasz {car.Engine.FuelAmount}l paliwa");
                        }
                        break;

                    case 4:
                        {
                            Console.WriteLine($"\nMarka: {car.Brand}  Model: {car.Model}\nPojemność silnika: {car.Engine.Capacity}  Pojemność baku: {car.Engine.FuelTankCapacity}");
                        }
                        break;

                    case 5:
                        {
                            Console.WriteLine("Koniec programu");
                        }
                        return;
                    default:
                        {
                            Console.WriteLine("Nieprawidłowy wybór");
                        }
                        break;
                }
            }

        }
    }
}