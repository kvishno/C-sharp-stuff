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
            //Menu Items
            string[] menuItems =
            {
                "Exit menu",//This string should always be the first in the array
                "Something",
                "Something else"
            };
            
            //Text strings
            string pickText = "Pick an option (number):";
            string wrongNum = "Wrong number. Pick again.";
            string onlyWholeNum = "Insert only whole numbers!";
            string backToMenu = "\nPress any key to return to the menu";

            //Loop Menu
            bool exitMenu = false;
            do
            {
                //Print menu
                Console.WriteLine(pickText);
                {
                    Console.WriteLine("---------------------------------");
                    int i = 0;
                    foreach (string value in menuItems)
                    {
                        Console.WriteLine(i + ". " + value);
                        i = i + 1;
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
                            exitMenu = true; //Change bool to exit menu
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
                            Console.WriteLine(wrongNum);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(onlyWholeNum);
                }
            } while (exitMenu == false);
        }
    }
}
