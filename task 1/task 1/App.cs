using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class ConsoleApp
    {
        public ConsoleApp() { }

        ConsoleKeyInfo choice;
        Guid directoryName;
        private const string basePath = @"c:\";
        private string path;
        private Guid[] directories = new Guid[5];
        private bool dirCreated = false;
        private int howMany;

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

        private bool TFChecker(string text)
        {
            Console.WriteLine(text +" (1. YES   2. NO): ");
            choice = Console.ReadKey();
            switch (choice.KeyChar)
            {
                case '1':
                    return true;
                case '2':
                    return false;
                default:
                    return false;
            }
        }

        //FizzBuzz - option 1
        private void FizzBuzz()
        {
            Console.Clear();
            Console.WriteLine("Write an integer between 0 and 1000: ");

            bool correctNumber = false; //boolean used to check input format
            if (int.TryParse(Console.ReadLine(), out int number)) //using TryParse, so the program won't fail if given wrong type
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

        //DeepDive - option 2
        private void DeepDive()
        {
            Console.Clear();
            Console.Write("How many directories do you want to create? (max 5): ");

            if (int.TryParse(Console.ReadLine(), out howMany)) //using TryParse, like in FizzBuzz method
            {
                if (howMany > 0 && howMany <= 5) //limited to 5 directories
                {
                    //set used path to base
                    path = basePath;

                    for (int i=0; i<howMany; i++) //create exact amount of directories
                    {
                        directoryName = Guid.NewGuid();
                        directories[i] = directoryName; //used for DrownItDown function
                        path += directoryName + @"\";
                        DirectoryInfo di = Directory.CreateDirectory(path); //create directory
                    }
                    dirCreated = true;
                }
                else
                {
                    Console.WriteLine("Number out of range, you can only create 1-5 directories!");
                }
            }
            else
            {
                Console.WriteLine("This value should be an integer!");
            }

            //wait for user reaction before returning to menu
            Console.WriteLine("Directories created!");
            Console.ReadKey(); 
        }

        //DrownItDown - option 3
        private void DrownItDown()
        {
            Console.Clear();

            //check if DeepDive was used before, if not, suggest user to do it
            if (!dirCreated)
            {
                if(TFChecker("No directories created, do you want to create some now ?"))
                {
                    DeepDive();
                }
                return;
            }

            //actual function starts here
            Console.WriteLine("How deep do you want to create a file?: ");
            if (int.TryParse(Console.ReadLine(), out int howDeep)) //using TryParse, like in FizzBuzz and DeepDive methods
            {
                if (howDeep > 0 && howDeep <= howMany) //limited to the amount of 
                {
                    //set used path to base
                    path = basePath;

                    for(int i = 0; i < howDeep; i++) //go as deep as demanded
                    {
                        path += directories[i] + @"\";
                    }

                    //declare a file name
                    string fileName = path + "file";

                    if (File.Exists(fileName)) //check if file exists
                    {
                        if (!TFChecker("The file already exists, do you want to overwrite it?"))
                        {
                            return;
                        }
                    }

                    //create a file
                    FileStream fs = File.Create(fileName);
                    fs.Close();
                    
                }
                else
                {
                    Console.WriteLine("Number out of range, "+ howMany +" is maximum!");
                }
            }
            else
            {
                Console.WriteLine("This value should be an integer!");
            }
            
            //wait for user reaction before returning to menu
            Console.WriteLine("File created!");
            Console.ReadKey(); 
        }
    }

}
