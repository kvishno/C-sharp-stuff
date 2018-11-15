using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-------------A simple C# menu-------------

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
            string selectText = "Select an option (number):";
            string wrongNum = "Wrong number. Select again.";
            string onlyWholeNum = "Insert only whole numbers!";
            string backToMenu = "\nPress any key to return to the menu";

            //Loop Menu
            bool exitMenu = false; //do-while loop (the menu) runs until set to true
            
            do
            {
                Console.Clear(); //Clear console before printing menu
                
                //Print menu 
                Console.WriteLine(selectText);
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
                
                var ans = Console.ReadLine(); //Select menu answer
                Console.Clear(); //Clear console after choosing and item

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
                            exitMenu = true; //Changes bool to exit menu
                            break;

                        case 1:                            
                            // YOUR CODE HERE

                            Console.WriteLine(backToMenu);
                            Console.ReadKey();
                            break;
                        case 2:
                            // YOUR CODE HERE

                            Console.WriteLine(backToMenu);
                            Console.ReadKey();
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
