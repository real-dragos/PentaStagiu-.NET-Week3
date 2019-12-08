using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName;
            int attempts = 0;
            do
            {
                if (attempts == 0)
                {
                    Console.WriteLine("Please Enter Your Name: ");
                }
                else
                {
                    Console.WriteLine("The name is INVALID!");
                }
                Console.WriteLine("--------------------------------");
                Console.Write("Enter your first name: ");
                //1 - Trim
                firstName = Console.ReadLine().Trim();
                Console.Write("Enter your last name: ");
                lastName = Console.ReadLine().Trim();
                Console.WriteLine("--------------------------------");
                attempts++;
            // 2 - IsNullOrEmpty
            } while (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName));

            //3 - Concat
            string fullName = string.Concat(firstName, " ", lastName);

            //4 - Format, 5 - ToUpper
            Console.WriteLine(string.Format("Welcome, {0}!", fullName.ToUpper()));
            if(attempts > 2)
            {
                Console.WriteLine($"It seems you don't know your name very well or you don't take things seriously (attemtps {attempts})");
            }

            //6 - Compare, 7 - ToLower
            if (string.Compare(firstName.ToLower(), lastName.ToLower()) == 0)
            {
                Console.WriteLine(string.Format("Wow! Your first name is the same as your last name ({0})", firstName.ToUpper()));
            }

            //8 - Join, 9 - ToCharArray
            string reversedName = string.Join("", fullName.ToCharArray().Reverse());

            Console.WriteLine(string.Format("Your name reversed is {0}", reversedName.ToUpper()));

            Console.ReadLine();
        }
    }
}
