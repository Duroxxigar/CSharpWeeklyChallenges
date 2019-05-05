using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOne_foreach
{
    class Program
    {
        /*
         *  Create a list of strings, putting in a few names. Use a foreach loop to print those to the console
         *  
         *  **BONUS**
         *  Create another list of models. Models should store 2 string values. foreach loop should print out both values for each item.
         * 
         */

        static void Main(string[] args)
        {
            string input = null;
            while (input == null)
            {
                Console.WriteLine("Plese enter the number for the style that you'd like to see.");
                Console.WriteLine("1. Print just the first name");
                Console.WriteLine("2. Print just the last name");
                input = Console.ReadLine();
            }
            var userChoice = int.Parse(input);
            switch (userChoice)
            {
                case 1:
                    PrintBasicNames();
                    break;
                case 2:
                    PrintPersonNames();
                    break;
                default:
                    Console.WriteLine("You did not enter one of the two options");
                    break;
            }
        }

        private static void PrintBasicNames()
        {
            List<string> myList = new List<string>();
            myList.Add("Adam");
            myList.Add("Beth");
            myList.Add("Charlie");
            myList.Add("Diane");

            foreach (var name in myList)
            {
                Console.WriteLine($"Hello {name}!");
            }
        }

        private static void PrintPersonNames()
        {
            List<Person> myPeople = new List<Person>();
            myPeople.Add(new Person("Adam", "Smith"));
            myPeople.Add(new Person("Beth", "Jones"));
            myPeople.Add(new Person("Charlie", "Hunt"));
            myPeople.Add(new Person("Diane", "Atkins"));

            foreach (Person person in myPeople)
            {
                Console.WriteLine($"Hello {person.FirstName} {person.LastName}!");
            }
        }
    }
}
