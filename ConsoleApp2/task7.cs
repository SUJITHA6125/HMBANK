using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{


    class Customer
    {
        // Attributes
        private string customerId;
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string phoneNumber;
        private string address;

        // Default constructor
        public Customer()
        {
            customerId = "";
            firstName = "";
            lastName = "";
            emailAddress = "";
            phoneNumber = "";
            address = "";
        }

        // Constructor with attributes
        public Customer(string id, string first, string last, string email, string phone, string addr)
        {
            customerId = id;
            firstName = first;
            lastName = last;
            emailAddress = email;
            phoneNumber = phone;
            address = addr;
        }

        // Getter and setter methods
        public string GetCustomerId()
        {
            return customerId;
        }

        public void SetCustomerId(string id)
        {
            customerId = id;
        }

        // Implement similar getter and setter methods for other attributes...

        // Method to print all information
        public void PrintInfo()
        {
            Console.WriteLine($"Customer ID: {customerId}");
            Console.WriteLine($"First Name: {firstName}");
            Console.WriteLine($"Last Name: {lastName}");
            Console.WriteLine($"Email Address: {emailAddress}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Address: {address}");
        }
    }

    class Account
    {
        // Attributes
        private string accountNumber;
        private string accountType;
        private decimal AccountBalance;

        // Default constructor
        public Account()
        {
            accountNumber = "";
            accountType = "";
            AccountBalance = 0;
        }

        // Constructor with attributes
        public Account(string number, string type, decimal balance)
        {
            accountNumber = number;
            accountType = type;
            AccountBalance = balance;
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

        // Implement similar getter and setter methods for other attributes...

        // Method to print all information
        public void PrintInfo()
        {
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Account Balance: {AccountBalance:C}");
        }

        // Deposit method
        public void Deposit(decimal amount)
        {
            AccountBalance += amount;
            Console.WriteLine($"Deposit of {amount:C} successful. New balance: {AccountBalance:C}");
        }

        // Withdraw method
        public void Withdraw(decimal amount)
        {
            if (amount > AccountBalance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrawal of {amount:C} successful. New balance: {AccountBalance:C}");
            }
        }

        // Calculate interest method
        public void CalculateInterest()
        {
            if (accountType.ToLower() == "savings")
            {
                decimal interestRate = 0.045m; // 4.5%
                decimal interest = AccountBalance * interestRate;
                AccountBalance += interest;
                Console.WriteLine($"Interest calculated and added. New balance: {AccountBalance:C}");
            }
            else
            {
                Console.WriteLine("Interest calculation not applicable for current accounts.");
            }
        }

        public override void CalculateInterest1()
        {
            decimal interest = AccountBalance * interestRate;
            AccountBalance += interest;
            Console.WriteLine($"Interest calculated and added. New balance: {AccountBalance:C}");
        }
    }

    class Bank
    {
        static void Main()
        {
            // Create a Customer object
            Customer customer = new Customer("123456", "John", "Doe", "johndoe@example.com", "123-456-7890", "123 Main St");

            // Create an Account object
            Account account = new Account("ACC123", "Savings", 1000.00m);

            // Print customer and account information
            Console.WriteLine("Customer Information:");
            customer.PrintInfo();

            Console.WriteLine("\nAccount Information:");
            account.PrintInfo();

            // Perform operations on the account
            account.Deposit(500.00m);
            account.Withdraw(200.00m);
            account.CalculateInterest();
        }

        internal void CalculateInterest(BankAccount account)
        {
            throw new NotImplementedException();
        }

        internal BankAccount CreateAccount(int choice, int accountNumber, string? customerName, double balance)
        {
            throw new NotImplementedException();
        }

        internal BankAccount CreateAccount(Customer customer, string accType, float balance)
        {
            throw new NotImplementedException();
        }

        internal void Deposit(BankAccount account, int v)
        {
            throw new NotImplementedException();
        }

        internal void DisplayMenu()
        {
            throw new NotImplementedException();
        }

        internal void Withdraw(BankAccount account, int v)
        {
            throw new NotImplementedException();
        }
    }
}
