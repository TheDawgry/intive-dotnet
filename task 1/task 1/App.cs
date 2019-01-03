using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class ConsoleApp
    {
        public ConsoleApp() { }

        ConsoleKeyInfo choice;

        //Basic function that runs the class
        public void Play() 
        {
            WriteMenu();
            SelectChoice();
        }

        //Write menu in console
        private void WriteMenu()    
        {
            Console.Clear();
            Console.WriteLine(" MENU ");
            Console.WriteLine("------");
            Console.WriteLine("1.FizzBuzz");
            Console.WriteLine("2.DeepDive");
            Console.WriteLine("3.DrownItDown");
            Console.WriteLine("4.Exit");
        }

        //Let user select an option from menu
        private void SelectChoice()     
        {
            choice = Console.ReadKey();
            switch (choice.KeyChar)
            {
                case '1':
                    FizzBuzz();
                    break;
                case '2':
                    DeepDive();
                    break;
                case '3':
                    DrownItDown();
                    break;
                case '4':
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        //FizzBuzz - option 1
        private void FizzBuzz()
        {
            bool correctNumber = false; //boolean used to check input format
            Console.Clear();
            Console.WriteLine("Write an integer between 0 and 1000: ");

            if (Int32.TryParse(Console.ReadLine(), out int number)) //using TryParse, so the program won't fail if given wrong type
            {
                if (number >= 0 && number <= 1000) //numbers range
                {
                    correctNumber = true;
                    FizzBuzzCheck(number);
                }
            }

            if (!correctNumber) //error message if requirements are not met
            {
                Console.WriteLine("Input type must be a number in range 0-1000 !");
            }
            Console.ReadKey(); //wait for user reaction before returning to menu
        }

        private void FizzBuzzCheck(int number) //check if number can be divided
        {
            if (number % 2 == 0)
            {
                Console.Write("Fizz");
            }
            if (number % 3 == 0)
            {
                Console.Write("Buzz");
            }
        }

        private void DeepDive()
        {

        }

        private void DrownItDown()
        {

        }
    }

}
