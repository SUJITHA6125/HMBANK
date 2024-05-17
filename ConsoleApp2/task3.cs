using System;
namespace ConsoleApp2
{
    class Program3
    {
        static void Main()
        {
            // Ask the user for the number of customers
            Console.Write("Enter the number of customers: ");
            int numCustomers = int.Parse(Console.ReadLine());

            // Loop through each customer
            for (int i = 1; i <= numCustomers; i++)
            {
                Console.WriteLine($"\nCustomer {i}:");

                // Ask for customer details
                Console.Write("Enter initial balance: ");
                decimal initialBalance = decimal.Parse(Console.ReadLine());
                Console.Write("Enter annual interest rate (%): ");
                decimal annualInterestRate = decimal.Parse(Console.ReadLine());
                Console.Write("Enter number of years: ");
                int years = int.Parse(Console.ReadLine());

                // Calculate future balance
                decimal futureBalance = CalculateFutureBalance(initialBalance, annualInterestRate, years);

                // Display future balance
                Console.WriteLine($"Future balance after {years} years: {futureBalance:C}");
            }
        }

        static decimal CalculateFutureBalance(decimal initialBalance, decimal annualInterestRate, int years)
        {
            decimal futureBalance = initialBalance * (decimal)Math.Pow(1 + (double)annualInterestRate / 100, years);
            return futureBalance;
        }
    }
}