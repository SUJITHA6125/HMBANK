using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program5
    {
        static void Main()
        {
            Console.WriteLine("Create a password for your bank account:");
            string password = Console.ReadLine();

            bool isValid = ValidatePassword(password);

            if (isValid)
            {
                Console.WriteLine("Password is valid.");
            }
            else
            {
                Console.WriteLine("Password is not valid. Please make sure it meets the criteria.");
            }
        }

        static bool ValidatePassword(string password)
        {
            // Check length
            if (password.Length < 8)
            {
                return false;
            }

            // Check for at least one uppercase letter and one digit
            bool hasUppercase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUppercase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }

            return hasUppercase && hasDigit;
        }
    }

}
