using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp2
{
    internal class Program1
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Enter a Credit score:");
            double credit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter a Annual Income:");
            double income = Convert.ToDouble(Console.ReadLine());
            if (credit > 700 & income >= 50000)
            {
                Console.WriteLine("Your eligible for a loan");
            }
            else
            {
                Console.WriteLine("Your not eligible for a loan");
            }
        }
    }
}

