using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Customer
    {
        // Attributes
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Constructors
        public Customer()
        {
            // Default constructor
        }

        public Customer(int customerId, string firstName, string lastName, string emailAddress, string phoneNumber, string address)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        // Methods
        public void PrintCustomerInfo()
        {
            Console.WriteLine($"Customer ID: {CustomerID}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Email: {EmailAddress}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
        }
    }

    // Account class
    public class Account
    {
        // Attributes
        public long AccountNumber { get; set; }
        public string AccountType { get; set; }
        public float AccountBalance { get; set; }
        public Customer AccountHolder { get; set; }

        // Static variable for automatic account number generation
        private static long nextAccountNumber = 1001;

        // Constructors
        public Account()
        {
            AccountNumber = GenerateAccountNumber();
        }

        public Account(string accountType, float accountBalance, Customer accountHolder)
        {
            AccountNumber = GenerateAccountNumber();
            AccountType = accountType;
            AccountBalance = accountBalance;
            AccountHolder = accountHolder;
        }

        // Methods
        private long GenerateAccountNumber()
        {
            return nextAccountNumber++;
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Type: {AccountType}");
            Console.WriteLine($"Balance: {AccountBalance}");
            Console.WriteLine($"Account Holder: {AccountHolder.FirstName} {AccountHolder.LastName}");
        }
    }

    // Bank class
    public class Bank3
    {
        // List to store accounts
        private List<Account> accounts = new List<Account>();

        public Bank(List<Account> accounts)
        {
            this.accounts = accounts;
        }

        // Methods
        public void CreateAccount(Customer customer, string accType, float balance)
        {
            Account account = new Account(accType, balance, customer);
            accounts.Add(account);
            Console.WriteLine($"Account created successfully. Account Number: {account.AccountNumber}");
        }

        public float GetAccountBalance(long accountNumber)
        {
            Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                return account.AccountBalance;
            }
            else
            {
                Console.WriteLine("Account not found.");
                return 0;
            }
        }

        public float Deposit(long accountNumber, float amount)
        {
            Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                account.AccountBalance += amount;
                Console.WriteLine($"Deposit of {amount} successful. New balance: {account.AccountBalance}");
                return account.AccountBalance;
            }
            else
            {
                Console.WriteLine("Account not found.");
                return 0;
            }
        }

        public float Withdraw(long accountNumber, float amount)
        {
            Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                if (account.AccountBalance >= amount)
                {
                    account.AccountBalance -= amount;
                    Console.WriteLine($"Withdrawal of {amount} successful. New balance: {account.AccountBalance}");
                    return account.AccountBalance;
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                    return account.AccountBalance;
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
                return 0;
            }
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            Account fromAccount = accounts.Find(acc => acc.AccountNumber == fromAccountNumber);
            Account toAccount = accounts.Find(acc => acc.AccountNumber == toAccountNumber);

            if (fromAccount != null && toAccount != null)
            {
                if (fromAccount.AccountBalance >= amount)
                {
                    fromAccount.AccountBalance -= amount;
                    toAccount.AccountBalance += amount;
                    Console.WriteLine($"Transfer of {amount} successful.");
                }
                else
                {
                    Console.WriteLine("Insufficient balance for transfer.");
                }
            }
            else
            {
                Console.WriteLine("One or both accounts not found.");
            }
        }

        public void GetAccountDetails(long accountNumber)
        {
            Account account = accounts.Find(acc => acc.AccountNumber == accountNumber);
            if (account != null)
            {
                account.PrintAccountInfo();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }

    // BankApp class for interaction
    public class BankApp
    {
        public static void Main()
        {
            Bank bank = new Bank();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Enter command: create_account, deposit, withdraw, get_balance, transfer, getAccountDetails, exit");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "create_account":
                        Console.WriteLine("Enter customer details:");
                        // You can add input validation here
                        Console.Write("Customer ID: ");
                        int customerId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Email Address: ");
                        string emailAddress = Console.ReadLine();
                        Console.Write("Phone Number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Address: ");
                        string address = Console.ReadLine();

                        Customer customer = new Customer(customerId, firstName, lastName, emailAddress, phoneNumber, address);

                        Console.WriteLine("Choose account type (Savings/Current): ");
                        string accType = Console.ReadLine().ToLower();
                        Console.Write("Initial balance: ");
                        float balance = float.Parse(Console.ReadLine());

                        BankAccount bankAccount = bank.CreateAccount(customer, accType, balance);
                        break;

                    case "deposit":
                        Console.Write("Enter account number: ");
                        long accNoDeposit = Convert.ToInt64(Console.ReadLine());
                        Console.Write("Enter amount to deposit: ");
                        float amountDeposit = float.Parse(Console.ReadLine());
                        bank.Deposit(accNoDeposit1, amountDeposit);
                        break;

                    case "withdraw":
                        Console.Write("Enter account number: ");
                        long accNoWithdraw = Convert.ToInt64(Console.ReadLine());
                        Console.Write("Enter amount to withdraw: ");
                        float amountWithdraw = float.Parse(Console.ReadLine());
                        bank.Withdraw(accNoWithdraw, amountWithdraw);
                        break;

                    case "get_balance":
                        Console.Write("Enter account number: ");
                        long accNoBalance = Convert.ToInt64(Console.ReadLine());
                        float v = bank.GetAccountBalance(accNoBalance);

                        Console.WriteLine($"Account balance: {v}");
                        break;

                    case "transfer":
                        Console.Write("Enter account number to transfer from: ");
                        long fromAccNo = Convert.ToInt64(Console.ReadLine());
                        Console.Write("Enter account number to transfer to:");
                        int toAccNo = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter amount to transfer: ");
                        float transferAmount = float.Parse(Console.ReadLine());
                        bank.Transfer(fromAccNo, toAccNo, transferAmount);
                        break;

                    case "getaccountdetails":
                        Console.Write("Enter account number: ");
                        long accNoDetails = Convert.ToInt64(Console.ReadLine());
                        bank.GetAccountDetails(accNoDetails);
                        break;

                    case "exit":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }
}
