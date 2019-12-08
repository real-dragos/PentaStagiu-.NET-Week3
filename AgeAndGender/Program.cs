using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace AgeAndGender
{
    class Program
    {
        enum Gender
        {
            Female,
            Male
        }

        static Dictionary<Gender, int> retirementDict = new Dictionary<Gender, int>()
        {
            { Gender.Female, 63 },
            { Gender.Male, 65 }
        };

        const double AVERAGE_DAYS_PER_YEAR = 365.25;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! Let's see when you will retire!\n");

            DateTime birthDate = ReadBirthDate();
            Gender? gender = ReadGender();

            int age = ComputeAge(birthDate);
            Console.WriteLine($"You are {age} years old");

            if (gender.HasValue)
            {
                if (IsRetired(age, gender.Value))
                {
                    Console.WriteLine("Congrats! You are eligible to retire!");
                }
                else
                {
                    int yearsUntilRetirement = retirementDict[gender.Value] - age;
                    Console.WriteLine($"Hopefully, you have at most {yearsUntilRetirement} years left until you are eligible to retire");
                }
            }
            else
            {
                Console.WriteLine("Your gender is out of our range!");
            }
            Console.ReadLine();
        }

        static int ComputeAge(DateTime birthday)
        {
            TimeSpan timeDifference = DateTime.Now - birthday;
            return Convert.ToInt32(Math.Floor(timeDifference.TotalDays / AVERAGE_DAYS_PER_YEAR));
        }

        static bool IsRetired(int age, Gender gender)
        {
            if (age > retirementDict[gender])
            {
                return true;
            }
            return false;
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
            return new DateTime(year, month, day);
        }

        static bool IsValidDate(int year, int month, int day, Calendar calendar = null)
        {
            if (calendar == null)
            {
                calendar = new GregorianCalendar();
            }

            if (year < calendar.MinSupportedDateTime.Year || year > calendar.MaxSupportedDateTime.Year)
            {
                PrintError("Year is invalid!");
                return false;
            }

            if (month < 1 || month > calendar.GetMonthsInYear(year))
            {
                PrintError("Month is invalid");
                return false;
            }

            if (day < 1 || day > DateTime.DaysInMonth(year, month))
            {
                PrintError("Day is invalid");
                return false;
            }

            try
            {
                var testDate = new DateTime(year, month, day, calendar);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                PrintError("Date is Invalid");
                return false;
            }
        }

        static Gender? ReadGender()
        {
            var GendersDict = new Dictionary<string, Gender>()
            {
                {"M", Gender.Male },
                {"F", Gender.Female }
            };

            Console.WriteLine("Enter your gender (M/F): ");

            string input = ReadFromConsole().ToUpper();
            if (GendersDict.ContainsKey(input))
            {
                return GendersDict[input];
            }
            return null;
        }

        static void PrintError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }
    }
}
