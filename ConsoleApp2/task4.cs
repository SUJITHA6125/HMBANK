using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    

    class Program4
    {
        static void Main()
        {
            int[] account_number = { 12345, 67890, 13579, 24680 };
            int[] balance = { 1000, 2000, 3000, 4000 };


            for (int i = 0; i < account_number.Length; i++)
            {
                Console.WriteLine("Enter a valid accound number:");
                int acc = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < account_number.Length; j++)
                {

                    if (acc == account_number[j])
                    {
                        Console.WriteLine($"balance::{balance[j]}");
                        break;
                    }

                }


            }
        }
    }
}
