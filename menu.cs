using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Menu_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Header
            /*
            Console.WriteLine("***Insert something here***");
            Console.WriteLine("Vishno - 2018");
            Console.WriteLine();
            */

            //Menu Items
            string[] menuItems =
            {
                "Exit menu",//This string should always be the first in the array
                "Something",
                "Something else"
            };

            string pickText = "Pick an option (number):";

            //Text strings
            string wrongNum = "Wrong number. Pick again.";
            string onlyWholeNum = "Inset only whole numbers!";
            string backToMenu = "\nPress any key to return to the menu";

            //Loop Menu
            bool exitMenu = true;
            do
            {
                //Print menu
                Console.WriteLine(pickText);
                {
                    Console.WriteLine("---------------------------------");
                    int i = -1;
                    foreach (string value in menuItems)
                    {
                        i = i + 1;
                        Console.WriteLine(i + ". " + value);
                    }
                    Console.WriteLine("---------------------------------");
                }

                //Pick menu answer
                var ans = Console.ReadLine();

                //Clear console after choosing and item
                Console.Clear();

                int choice = 0;
                if (int.TryParse(ans, out choice))
                {
                    switch (choice)
                    {
                        //Cases in switch
                        case 0: //Exit application
                            Console.WriteLine("Exiting in:");

                            Console.WriteLine("3...");
                            System.Threading.Thread.Sleep(1000);

                            Console.WriteLine("2..");
                            System.Threading.Thread.Sleep(1000);

                            Console.WriteLine("1.");
                            System.Threading.Thread.Sleep(1000);

                            Console.WriteLine("0");
                            //Change bool to exit menu
                            exitMenu = false;
                            break;

                        case 1:                            
                            // YOUR CODE HERE

                            Console.WriteLine(backToMenu);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:

                            // YOUR CODE HERE

                            Console.WriteLine(backToMenu);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("\n" + wrongNum);
                            Console.WriteLine("-----------------------------------\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n" + onlyWholeNum);
                    Console.WriteLine("-----------------------------------\n");
                }
            } while (exitMenu);
        }
    }
}
