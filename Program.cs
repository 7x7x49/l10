using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

public class Car
    {
        public string name { get; set; }

    }
    public class Garage
    {
        public List<Car> garage = new List<Car>();

    }
    public class Washer
    {
        public delegate void WashCars(Car car);

        public WashCars washCars = new WashCars(wash);
        public static void wash(Car car)
        {
            Console.WriteLine($" В мойке сейчас: {car.name}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car maybach = new Car();
            Car koenigsegg = new Car();
            Car lamborghini = new Car();
            Car mcLaren = new Car();
            Car ferrari = new Car();
            Car aston = new Car();

            maybach.name = "Exelero";
            koenigsegg.name = "CCXR Trevita";
            lamborghini.name = "Veneno Roadster";
            mcLaren.name = "P1 GTR";
            ferrari.name = "Pininfarina Sergio";
            aston.name = "Martin Valkyrie";

            Garage garage = new Garage();
            garage.garage.Add(maybach);
            garage.garage.Add(koenigsegg);
            garage.garage.Add(lamborghini);
            garage.garage.Add(mcLaren);
            garage.garage.Add(ferrari);
            garage.garage.Add(aston);

            Washer washer = new Washer();
            Console.WriteLine(garage.garage.Count);

            for (int i = 0; i < garage.garage.Count-1; i++)
            {
                washer.washCars(garage.garage[i]);
                Console.WriteLine($"    {garage.garage[i + 1].name}: Статус - в ожидании");
                if (i == garage.garage.Count - 2)
                {
                    washer.washCars(garage.garage[i + 1]);
                    break;
                }
            }
            Console.ReadLine();
        }
    }