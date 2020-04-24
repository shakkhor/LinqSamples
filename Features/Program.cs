using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Func <int,int> squares = x => x * x;
            Action<int> action = x => Console.WriteLine(x);
            action(squares(4));

            IEnumerable<Employee> developers = new Employee[]
            {
               new Employee{Id=1, Name="Dudu"},
               new Employee{Id=2,Name="Hagu"}
            };
            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee{Id=3,Name="BoyalMach"}
            };
            Console.WriteLine($"Number of developers: {developers.Count()}");
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            var query = developers.Where(d => d.Name.Length == 4)
                                  .OrderBy(d => d.Name);
            var query2 = from developer in developers
                         where developer.Name.Length == 4
                         orderby developer.Name
                         select developer;
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        private static int Square(int arg)
        {
            throw new NotImplementedException();
        }
    }
}
