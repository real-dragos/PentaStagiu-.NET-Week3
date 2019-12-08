using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace StringTraining
{
    class Program
    {
        enum Gender
        {
            Female,
            Male
        }

        static Dictionary<string, Gender> Genders = new Dictionary<string, Gender>()
        {
            {"M", Gender.Male },
            {"F", Gender.Female }
        };

        static void Main(string[] args)
        {

        }

        static string ReadFromConsole()
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            return input;
        }

        static int ReadInteger()
        {
            int output;
            bool isInt;
            do
            {
                string input = ReadFromConsole();
                isInt = int.TryParse(input, out output);
                if (!isInt)
                {
                    PrintError("Please enter a valid number!");
                }
            } while (!isInt);
            return output;
        }

        static DateTime ReadBirthDate()
        {
            int year;
            int month;
            int day;
            do
            {
                Console.WriteLine("Please Enter Your Birthday: ");
                Console.WriteLine("Year (e.g. 1995):");
                year = ReadInteger();
                Console.WriteLine("Month (e.g. 10): ");
                month = ReadInteger();
                Console.WriteLine("Day (e.g. 25): ");
                day = ReadInteger();
            } while (!IsValidDate(year, month, day));
        }

        static bool IsValidDate(int year, int month, int day, Calendar calendar = null)
        {
            if(calendar == null)
            {
                calendar = new GregorianCalendar();
            }

            if(year < calendar.MinSupportedDateTime.Year || year > calendar.MaxSupportedDateTime.Year)
            {
                PrintError("Year is invalid!");
                return false;
            }

            if(month < 1 || month > calendar.GetMonthsInYear(year))
            {
                PrintError("Month is invalid");
                return false;
            }

            if(day < 1 || day > DateTime.DaysInMonth(year, month))
            {
                PrintError("Day is invalid");
                return false;
            }

            return true;
        }

        static void PrintError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }

        static Gender? ReadGender()
        {
            string input = ReadFromConsole().ToUpper();
            if (Genders.ContainsKey(input))
            {
                return Genders[input];
            }
            return null;
        }
    }
}
