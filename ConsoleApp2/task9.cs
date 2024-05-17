using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class BankAccount
    {
        // Attributes
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }

        // Default constructor
        public BankAccount()
        {
            AccountNumber = 0;
            CustomerName = "";
            Balance = 0.0;
        }

        // Overloaded constructor with Account attributes
        public BankAccount(int accountNumber, string customerName, double balance)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
            Balance = balance;
        }

        // Getter and Setter methods
        public int GetAccountNumber()
        {
            return AccountNumber;
        }

        public void SetAccountNumber(int accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public string GetCustomerName()
        {
            return CustomerName;
        }

        public void SetCustomerName(string customerName)
        {
            CustomerName = customerName;
        }

        public double GetBalance()
        {
            return Balance;
        }

        public void SetBalance(double balance)
        {
            Balance = balance;
        }

        // Abstract methods
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void CalculateInterest();
    }
    // Concrete class for SavingsAccount
    public class SavingsAccount1 : BankAccount
    {
        // Additional attribute
        public double InterestRate { get; set; }

        // Constructor
        public SavingsAccount1(int accountNumber, string customerName, double balance, double interestRate) : base(accountNumber, customerName, balance)
        {
            InterestRate = interestRate;
        }

        // Implement calculate_interest() method
        public override void CalculateInterest()
        {
            double interest = Balance * InterestRate / 100;
            Balance += interest;
        }

        // Implement Deposit() and Withdraw() methods
        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        public override void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
    }

    // Concrete class for CurrentAccount
    public class CurrentAccount1 : BankAccount
    {
        // Constant for overdraft limit
        private const double OverdraftLimit = 1000.0;

        // Constructor
        public CurrentAccount1(int accountNumber, string customerName, double balance) : base(accountNumber, customerName, balance)
        {
        }

        // Implement Withdraw() method with overdraft limit
        public override void Withdraw(double amount)
        {
            if (amount <= Balance + OverdraftLimit)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Withdrawal amount exceeds overdraft limit.");
            }
        }

        // Implement Deposit() and CalculateInterest() methods (no interest for current account)
        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        public override void CalculateInterest()
        {
            Console.WriteLine("No interest for current accounts.");
        }
    }
    public class Bank2
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Choose account type:");
            Console.WriteLine("1. SavingsAccount");
            Console.WriteLine("2. CurrentAccount");
        }

        public BankAccount CreateAccount(int choice, int accountNumber, string customerName, double balance, double interestRate = 0.0)
        {
            switch (choice)
            {
                case 1:
                    return new SavingsAccount1(accountNumber, customerName, balance, interestRate);
                case 2:
                    return new CurrentAccount1(accountNumber, customerName, balance);
                default:
                    Console.WriteLine("Invalid choice.");
                    return null;
            }
        }

        public void Deposit(BankAccount account, double amount)
        {
            account.Deposit(amount);
            Console.WriteLine($"Deposited {amount} into account {account.GetAccountNumber()}. Current balance: {account.GetBalance()}");
        }

        public void Withdraw(BankAccount account, double amount)
        {
            account.Withdraw(amount);
            Console.WriteLine($"Withdrawn {amount} from account {account.GetAccountNumber()}. Current balance: {account.GetBalance()}");
        }

        public void CalculateInterest(BankAccount account)
        {
            account.CalculateInterest();
            Console.WriteLine($"Interest calculated for account {account.GetAccountNumber()}. Current balance: {account.GetBalance()}");
        }
    }

    class Program
    {
        static void Main()
        {
            Bank bank = new Bank();
            bank.DisplayMenu();
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            double balance = double.Parse(Console.ReadLine());

            BankAccount account = bank.CreateAccount(choice, accountNumber, customerName, balance);

            if (account != null)
            {
                Console.WriteLine("Account created successfully.");
                Console.WriteLine($"Account Number: {account.GetAccountNumber()}, Customer Name: {account.GetCustomerName()}, Balance: {account.GetBalance()}");

                // Perform operations
                bank.Deposit(account, 1000);
                bank.Withdraw(account, 500);
                bank.CalculateInterest(account);
            }

            Console.ReadKey();
        }
    }

}
