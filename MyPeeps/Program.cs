using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyPeeps
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName, emailAddress;
            int age;

            Console.WriteLine("Let's create a list of people!");
            while (true)
            {
                firstName = GetName("Enter a first name: ");
                lastName = GetName("Enter a last name: ");
                emailAddress = GetEmail("Enter an email address: ");
                age = GetAge("Enter an age: ");
                Person userInput = new Person(firstName, lastName, emailAddress, age);
                userInput.AddToList(firstName, lastName, emailAddress, age);
                string answer = GetResponse("Would you like to view the list? \nType Y to view the list.");
                if (answer.ToUpper() == "Y")
                {
                    Console.WriteLine("List of people:");
                    Person.ViewList(Person.adults);
                }

                Console.WriteLine(" ");
                string endProgram = GetResponse("Would you like to continue adding people?  Press Y to continue");
                if (endProgram.ToUpper() != "Y")
                {
                    break;
                }
            }
        }

        public static string GetResponse(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();

        }

        public static string GetName(string message)
        {
            Console.WriteLine(message);
            string answer = Console.ReadLine();

            while (true)
            {
                if (Regex.IsMatch(answer, @"[0-9]"))
                {
                    answer = GetName($"{answer} is not a valid input, please do not enter any numbers or symbols.");
                    continue;
                }
                else
                {
                    return answer;
                }
            }
        }

        public static int GetAge(string message)
        {
            int number;

            while (true)
            {
                Console.Write(message);
                bool parsed = int.TryParse(Console.ReadLine(), out number);
                if (!parsed || number < 1)
                {
                    Console.WriteLine("That is not a valid age, please enter a positive number over 0.");
                }
                else
                {
                    return number;
                }
            }
        }

        public static string GetEmail(string message)
        {
            Console.WriteLine(message);
            string userEmail = Console.ReadLine();

            while (true)
            {
                if (!Regex.IsMatch(userEmail, @"^[a-zA-Z0-9]{3,30}@[a-zA-Z0-9]{2,10}.[a-z]{2,3}$"))
                {
                    userEmail = GetEmail("That is not a valid email, please try again.  Format: joesmith@aol.com");
                    continue;
                }
                else
                {
                    return userEmail;
                }
            }
        }
    }
}
