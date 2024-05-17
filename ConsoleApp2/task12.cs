using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    using System;

    // Define custom exceptions
    public class InsufficientFundException : Exception
    {
        public InsufficientFundException(string message) : base(message)
        {
        }
    }

    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message)
        {
        }
    }

    public class OverDraftLimitExcededException : Exception
    {
        public OverDraftLimitExcededException(string message) : base(message)
        {
        }
    }

    // HMBank class with methods throwing exceptions
    public class HMBank
    {
        private double balance = 10000; // Initial balance for demonstration purposes

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new InsufficientFundException("Insufficient funds for withdrawal");
            }

            balance -= amount;
            Console.WriteLine($"Withdrawn: ${amount}, Balance: ${balance}");
        }

        public void Transfer(double amount, string targetAccount)
        {
            // Assuming validation logic for account number
            if (string.IsNullOrEmpty(targetAccount))
            {
                throw new InvalidAccountException("Invalid target account number");
            }

            if (amount > balance)
            {
                throw new InsufficientFundException("Insufficient funds for transfer");
            }

            // Transfer logic
            balance -= amount;
            Console.WriteLine($"Transferred: ${amount}, Balance: ${balance}");
        }

        public void OverDraftWithdraw(double amount)
        {
            // Assuming overdraft limit logic
            double overdraftLimit = 5000;
            if (amount > balance + overdraftLimit)
            {
                throw new OverDraftLimitExcededException("Exceeded overdraft limit");
            }

            // Withdraw logic
            balance -= amount;
            Console.WriteLine($"Overdraft Withdrawn: ${amount}, Balance: ${balance}");
        }
    }

    public class Program1
    {
        public static void Main()
        {
            try
            {
                HMBank bank = new HMBank();

                // Test cases
                bank.Withdraw(1500); // InsufficientFundException
                bank.Transfer(800, ""); // InvalidAccountException
                bank.OverDraftWithdraw(700); // OverDraftLimitExcededException
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverDraftLimitExcededException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
