using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Manufactuerer
    {
        public string Name { get; set; }
        public string Headquarters { get; set; }
        public int Year { get; set; }

        internal static Manufactuerer ParseFromCSV(string line)
        {
            var column = line.Split(',');
            return new Manufactuerer
            {
                Year = int.Parse(column[2]),
                Headquarters = column[1],
                Name = column[0],
               
            };
        }
    }
}
