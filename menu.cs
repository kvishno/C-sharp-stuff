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
            Console.WriteLine("Insert something here");
            Console.WriteLine("Vishno - 2018");
            Console.WriteLine();
            */

            //Menu Items
            string[] menuItems =
            {
                "Exit menu                    ",//This string should always be the first in the array
                "Something				        ",
                "Something else					"
            };

            string pickText = "Pick an option (number):";


            //Text displayed when choosing an case
            string[] caseText =
            {
                "Exiting in:", //This string should always be the first in the array
                "You picked 1 - ",
                "You picked 2 - "
            };

            //Text strings
            string wrongNum = "Wrong number. Pick again.";
            string onlyWholeNum = "Inset only whole numbers!";
            string backToMenu = "\nPress any key to return to the menu";

            //Loop Menu
            bool exitMenu = true;
            do
            {
                //Menu
                Console.WriteLine(pickText);
                {
                    Console.WriteLine("---------------------------------");
                    int i = -1;
                    foreach (string value in menuItems)
                    {
                        i = i + 1;
                        Console.WriteLine("|" + i + ". " + value + "\t|");
                    }
                    Console.WriteLine("---------------------------------");
                }

                //Pick menu answer
                var ansA = Console.ReadLine();

                //Clear console after choosing and item
                Console.Clear();

                int choiceA = 0;
                if (int.TryParse(ansA, out choiceA))
                {
                    int choiceANum = choiceA;
                    switch (choiceA)
                    {
                        //Cases in switch
                        case 0: //Exit application
                            Console.WriteLine(caseText[choiceANum]);

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
                            Console.WriteLine(caseText[choiceANum] + menuItems[choiceANum]);


                            Console.WriteLine(backToMenu);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            Console.WriteLine(caseText[choiceANum] + menuItems[choiceANum]);


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
