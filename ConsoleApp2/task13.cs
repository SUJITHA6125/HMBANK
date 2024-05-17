using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Account
    {
        public required string AccountNumber { get; set; }
        public double Balance { get; set; }
        public required string CustomerName { get; set; }

        public override int GetHashCode()
        {
            return AccountNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return AccountNumber == ((Account)obj).AccountNumber;
        }
    }

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

    // HMBank class with Set of Accounts
    public class HMBank
    {
        private HashSet<Account> accounts = new HashSet<Account>();

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public void Withdraw(string accountNumber, double amount)
        {
            Account account = accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new InvalidAccountException("Invalid account number");
            }

            if (amount > account.Balance)
            {
                throw new InsufficientFundException("Insufficient funds for withdrawal");
            }

            account.Balance -= amount;
            Console.WriteLine($"Withdrawn: ${amount}, Balance: ${account.Balance}");
        }

        // Other methods like Transfer and OverDraftWithdraw can be similarly implemented

        public void ListAccounts()
        {
            // Sort accounts by customer name using a Comparator<Account>
            List<Account> sortedAccounts = accounts.OrderBy(acc => acc.CustomerName).ToList();

            // Print sorted accounts
            foreach (var account in sortedAccounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Customer Name: {account.CustomerName}, Balance: {account.Balance}");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            HMBank bank = new HMBank();

            // Add accounts
            bank.AddAccount(new Account { AccountNumber = "1001", Balance = 1000, CustomerName = "John Doe" });
            bank.AddAccount(new Account { AccountNumber = "1002", Balance = 2000, CustomerName = "Jane Smith" });
            bank.AddAccount(new Account { AccountNumber = "1003", Balance = 1500, CustomerName = "Alice Johnson" });

            // Test cases
            try
            {
                bank.Withdraw("1002", 500); // Withdraw from valid account
                bank.Withdraw("1004", 500); // InvalidAccountException
                bank.ListAccounts(); // List accounts sorted by customer name
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InsufficientFundException ex)
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
