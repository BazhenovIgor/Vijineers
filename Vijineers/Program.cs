using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace Vijineers
{
    class Program
    {
        static void Main(string[] args)
        {
            Vijener a = new Vijener();

            var result = a.Encryption("MY FIRST LAB", "Kisel");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
