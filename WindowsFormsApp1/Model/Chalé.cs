using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    internal class Chalé
    {
        public int CodChalé { get; set; }

       public string Alugar {  get; set; }

        public string City { get; set; }    

        public float Price { get; set; }    

        public Chalé(string alugar, string city, float price)

        { Alugar = alugar;
            City = city;
            Price = price;
        }
    }
}
