using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleAppClinicManagementSystem.Utility
{
    public class StaffValidation
    {

        //Username should not be empty
        //user name should contain only letters,numbers,underscores, and dot

        public static bool IsValidUserName(string userName)
        {
            return !string.IsNullOrEmpty(userName) &&
                Regex.IsMatch(userName, @"^[a-zA-Z0-9_.]+$");
        }

        //password should have at least 4 characters
        //including at least one uppercase letter ,one lowercase letter,
        //one digit, one special character

        public static bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) &&
                Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{4,}$");


        }


        //replace alphabets with * symbol for password

        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                //1 each keystroke from the user, replaces it with an asterisk(*) and add it to the password string until the user presses the enter key

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }

                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }





            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;

        }
    }
}
