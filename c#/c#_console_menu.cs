using System;
using System.IO;

//-------------A simple C# menu-------------

namespace Test
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

            //Loop Menu
            bool exitMenu = false; //do-while loop (the menu) runs until set to true

            do
            {
                //Print menu 
                Console.WriteLine("Select an option (number):");
                {
                    Console.WriteLine("---------------------------------");
                    int i = 0;
                    foreach (string title in menuItems)
                    {
                        Console.WriteLine(i + ". " + title);
                        i += 1;
                    }
                    Console.WriteLine("---------------------------------");
                }

                var ans = Console.ReadLine(); //Select menu answer
                Console.Clear(); //Clear console after choosing an item

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

                            EndCase();
                            break;
                        case 2:
                            // YOUR CODE HERE

                            EndCase();
                            break;
                        default:
                            Console.WriteLine("Wrong number. Select again.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Insert only whole numbers!\n");
                }
            } while (exitMenu == false);
        }
        
        private static void EndCase()
        {
            Console.WriteLine("\nPress any key to return to the menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
