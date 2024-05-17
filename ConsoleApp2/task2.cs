using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp2
{
    class Program2
    {
        static void Main()
        {
            // Ask the user to enter their current balance
            Console.Write("Enter your current balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            // Display ATM options
            Console.WriteLine("ATM Options:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.Write("Enter your choice (1/2/3): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Display current balance
                    Console.WriteLine($"Your current balance is: {balance:C}");
                    break;
                case 2:
                    // Withdraw money
                    Console.Write("Enter the amount to withdraw: ");
                    decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                    if (withdrawAmount > balance)
                    {
                        Console.WriteLine("Insufficient funds.");
                    }
                    else if (withdrawAmount % 100 != 0 && withdrawAmount % 500 != 0)
                    {
                        Console.WriteLine("Withdrawal amount must be in multiples of 100 or 500.");
                    }
                    else
                    {
                        balance -= withdrawAmount;
                        Console.WriteLine($"Withdrawal successful. Remaining balance: {balance:C}");
                    }
                    break;
                case 3:
                    // Deposit money
                    Console.Write("Enter the amount to deposit: ");
                    decimal depositAmount = decimal.Parse(Console.ReadLine());
                    if (depositAmount <= 0)
                    {
                        Console.WriteLine("Invalid deposit amount.");
                    }
                    else
                    {
                        balance += depositAmount;
                        Console.WriteLine($"Deposit successful. New balance: {balance:C}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
