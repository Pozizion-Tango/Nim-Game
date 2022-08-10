using System;
using System.Threading;

namespace Nim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There is 7 matches in total. The one who picks the last Match loses.\r\n\r\n");
            bool close = true;
            bool restart = true;
            Random rnd = new Random();
            int playerpoint = 0;
            int aipoint = 0;

            while (close)
            {
                restart = true;
                bool player = true;
                bool ai = true;
                Console.WriteLine("Player : "+playerpoint+"   "+aipoint+" :AI\r\n\r\n");
                int matches = 7;
                //Starting settings for each game
                while(restart)
                {
                    Console.WriteLine("\r\nMatches " + matches+"\r\n");
                    Console.WriteLine("\r\nEnter a number from 1-3\r\n");
                    while (player)//player's choice column
                    {
                        int choice = Convert.ToInt32(Console.ReadLine());//The player must choice a number for the game to continue
                        if (choice >= 4 || choice < 1 || choice > matches)
                        {
                            Console.WriteLine("Invalid Number");
                        }
                        else if (choice == matches)
                        {
                            Console.WriteLine("You picked the last match!");
                            aipoint++;
                            matches = matches - choice;
                            player = false;
                            ai = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You took " + choice + " from the " + matches + " matches");
                            matches = matches - choice;
                            break;
                        }
                    }
                    if (matches > 0)// It will take 3 seconds before the AI will reactivate to make a choice.
                    {
                        Console.WriteLine("\r\nAI is choicing...");
                        Thread.Sleep(3000);
                    }
                    while (ai)//AI's choice column
                    {
                        int aichoice = rnd.Next(1, 4);//The "AI" isn't really a AI, just a random choice
                        
                        if (aichoice == matches)
                        {
                            Console.WriteLine("AI picked the last match!");
                            playerpoint++;
                            matches = matches - aichoice;
                            ai = false;
                            player = false;
                            break;
                        }
                        else if (aichoice >= 4 || aichoice < 1 || aichoice > matches)
                        {
                            //These are no need to put a message in this collumn, since the AI won't be needing to read the invalid messages.
                        }
                        else
                        {
                            Console.WriteLine("AI took " + aichoice + " from the " + matches + " matches");
                            matches = matches - aichoice;
                            break;
                        }

                    }
                    if (matches == 0)//When the match hits 0 the game will pop up with a menu to choice to either reset from the top, or to quit the game.
                    {
                        Console.WriteLine("\r\nGame Over!\r\n");
                        while (true)
                        {
                            Console.WriteLine("Type reset To replay\r\nquit To Exit The Game");
                            string redo = Console.ReadLine();
                            if (redo == "reset" || redo == "Reset")
                            {
                                restart = false;
                                Console.Clear();
                                break;
                            }
                            else if (redo == "quit" || redo == "Quit")
                            {
                                restart = false;
                                close = false;
                                break;
                            }
                        }
                    }
                   
                    
                }
            }
        }
    }
}
