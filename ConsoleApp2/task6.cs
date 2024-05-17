using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    

    class Program6
    {
        static void Main()
        {
            List<Transaction> transactions = new List<Transaction>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Transaction History");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        MakeDeposit(transactions);
                        break;

                    case "2":
                        MakeWithdrawal(transactions);
                        break;

                    case "3":
                        ShowTransactionHistory(transactions);
                        break;

                    case "4":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }

            Console.WriteLine("\nThank you for using our banking system.");
        }

        static void MakeDeposit(List<Transaction> transactions)
        {
            Console.Write("Enter deposit amount: ");
            decimal amount = GetValidAmount();

            transactions.Add(new Transaction(DateTime.Now, TransactionType.Deposit, amount));
            Console.WriteLine($"Deposit of {amount:C} successful.");
        }

        static void MakeWithdrawal(List<Transaction> transactions)
        {
            Console.Write("Enter withdrawal amount: ");
            decimal amount = GetValidAmount();

            transactions.Add(new Transaction(DateTime.Now, TransactionType.Withdrawal, amount));
            Console.WriteLine($"Withdrawal of {amount:C} successful.");
        }

        static decimal GetValidAmount()
        {
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid amount:");
            }
            return amount;
        }

        static void ShowTransactionHistory(List<Transaction> transactions)
        {
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions yet.");
                return;
            }

            Console.WriteLine("\nTransaction History:");
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine($"{transaction.Date} - {transaction.Type}: {transaction.Amount:C}");
            }
        }
    }

    enum TransactionType
    {
        Deposit,
        Withdrawal
    }

    class Transaction
    {
        public DateTime Date { get; }
        public TransactionType Type { get; }
        public decimal Amount { get; }

        public Transaction(DateTime date, TransactionType type, decimal amount)
        {
            Date = date;
            Type = type;
            Amount = amount;
        }
    }

}
