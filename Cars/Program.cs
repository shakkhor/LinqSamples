using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");
            foreach(var item in manufacturers)
            {
                Console.WriteLine(item.Name);
            }
            var query = cars.OrderByDescending(car => car.Combined)
                            .ThenBy(car => car.Name);
            var top = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                          .OrderByDescending(c => c.Combined)
                          .ThenBy(c => c.Name)
                          .FirstOrDefault();
            Console.WriteLine(top.Name);
            foreach(var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
            Console.ReadKey();
        }

        private static List<Manufactuerer> ProcessManufacturers(string path)
        {
            return
                File.ReadAllLines(path)
                 .Skip(1)
                 .Where(line => line.Length > 1)
                 .Select(Manufactuerer.ParseFromCSV)
                 .ToList();
        }

        private static List<Car> ProcessCars(string path)
        {
            return 
                File.ReadAllLines(path)
                 .Skip(1)
                 .Where(line => line.Length > 1)
                 .Select(Car.ParseFromCSV)
                 .ToList();

        }

        
    }
}
