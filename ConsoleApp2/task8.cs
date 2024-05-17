using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Account1
    {
        // Attributes
        public string accountNumber;
        public string accountType;
        public decimal accountBalance;

        // Default constructor
        public Account1()
        {
            accountNumber = "";
            accountType = "";
            accountBalance = 0;
        }

        // Constructor with attributes
        public Account1(string number, string type, decimal balance)
        {
            accountNumber = number;
            accountType = type;
            accountBalance = balance;
        }

        // Getter and setter methods
        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public void SetAccountNumber(string number)
        {
            accountNumber = number;
        }

        // Method to print all information
        public void PrintInfo()
        {
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Account Balance: {accountBalance:C}");
        }

        // Deposit methods
        public void Deposit(float amount)
        {
            Deposit((decimal)amount);
        }

        public void Deposit(int amount)
        {
            Deposit((decimal)amount);
        }

        public void Deposit(double amount)
        {
            Deposit((decimal)amount);
        }

        public void Deposit(decimal amount)
        {
            accountBalance += amount;
            Console.WriteLine($"Deposit of {amount:C} successful. New balance: {accountBalance:C}");
        }

        // Withdraw methods
        public void Withdraw(float amount)
        {
            Withdraw((decimal)amount);
        }

        public void Withdraw(int amount)
        {
            Withdraw((decimal)amount);
        }

        public void Withdraw(double amount)
        {
            Withdraw((decimal)amount);
        }

        public void Withdraw(decimal amount)
        {
            if (amount > accountBalance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                accountBalance -= amount;
                Console.WriteLine($"Withdrawal of {amount:C} successful. New balance: {accountBalance:C}");
            }
        }

        // Calculate interest method
        public virtual void CalculateInterest()
        {
            Console.WriteLine("Interest calculation not applicable for this account type.");
        }
    }

    class SavingsAccount : Account
    {
        public decimal interestRate;

        public SavingsAccount(string number, decimal balance, decimal rate) : base(number, "Savings", balance)
        {
            interestRate = rate;
        }
    }

    class CurrentAccount : Account
    {
        private decimal overdraftLimit;
        private const decimal DefaultOverdraftLimit = 1000.00m; // Example overdraft limit

        public CurrentAccount(string number, decimal balance) : base(number, "Current", balance)
        {
            overdraftLimit = DefaultOverdraftLimit;
        }

        public void SetOverdraftLimit(decimal limit)
        {
            overdraftLimit = limit;
        }

        public void Withdraw(float amount)
        {
            Withdraw((decimal)amount, GetAccountBalance1(GetAccountBalance()));
        }

        public void Withdraw(int amount)
        {
            Withdraw((decimal)amount, GetAccountBalance1(GetAccountBalance()));
        }

        public void Withdraw(double amount)
        {
            Withdraw((decimal)amount, GetAccountBalance1(GetAccountBalance()));
        }

        private decimal GetAccountBalance()
        {
            return accountBalance;
        }

        private decimal GetAccountBalance1(decimal accountBalance)
        {
            return accountBalance;
        }

        private void Withdraw(decimal amount, decimal accountBalance)
        {
            decimal availableBalance = accountBalance + overdraftLimit;
            if (amount > availableBalance)
            {
                Console.WriteLine("Withdrawal amount exceeds available balance and overdraft limit.");
            }
            else
            {
                accountBalance -= amount;
                Console.WriteLine($"Withdrawal of {amount:C} successful. New balance: {accountBalance:C}");
            }
        }
    }

    class Bank1
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Bank!");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. Current Account");
            Console.Write("Choose account type (1 or 2): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateSavingsAccount();
                    break;
                case "2":
                    CreateCurrentAccount();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void CreateSavingsAccount()
        {
            Console.Write("Enter account number: ");
            string number = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            decimal balance;
            while (!decimal.TryParse(Console.ReadLine(), out balance) || balance < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid balance:");
            }
            Console.Write("Enter interest rate (e.g., 0.045 for 4.5%): ");
            decimal rate;
            while (!decimal.TryParse(Console.ReadLine(), out rate) || rate <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid interest rate:");
            }

            SavingsAccount savingsAccount = new SavingsAccount(number, balance, rate);
            savingsAccount.PrintInfo();
            savingsAccount.Deposit(500);
            savingsAccount.Withdraw(200);
            savingsAccount.CalculateInterest();
        }

        static void CreateCurrentAccount()
        {
            Console.Write("Enter account number: ");
            string number = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            decimal balance;
            while (!decimal.TryParse(Console.ReadLine(), out balance) || balance < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid balance:");
            }

            CurrentAccount currentAccount = new CurrentAccount(number, balance);
            currentAccount.PrintInfo();
            currentAccount.Deposit(500);
            currentAccount.Withdraw(200.00);
            currentAccount.SetOverdraftLimit(1500.00m); // Example overdraft limit
            currentAccount.Withdraw(1000.00); // Within overdraft limit
            currentAccount.Withdraw(2000.00); // Exceeding overdraft limit
        }
    }



}
