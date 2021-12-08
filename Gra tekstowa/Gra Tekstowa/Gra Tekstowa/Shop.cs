using System;
using System.Collections.Generic;
using System.Text;

namespace Gra_Tekstowa
{
    public class Shop
    {


        public static void LoadShop(Player p)
        {


            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionP;
            int amorP;
            int weaponP;
            int difP;
            int restp;
            Console.Clear();
            Program.Print("Welcome in the Town!");
            Console.ReadKey();



            while (true)
            {
                potionP = 15 + 10 * p.mods;
                amorP = 100 * (p.armorValue) + 100;
                weaponP = 100 * p.weaponValue;
                difP = 300 + 100 * p.mods;
                restp = 100 * p.mods + 100;




                // Console.WriteLine("Look around you can buy whatever you want.");
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("  You have: " + p.coins + "$");
                Console.WriteLine("     ________________________________");
                Console.WriteLine("    ///////////|    |////////////////|                              Type 'puzzles' to try out new mechanic.");
                Console.WriteLine("   ////////////|Shop|/////////////// |");
                Console.WriteLine("   ==================================|");
                Console.Write("   | (W)eapon:");
                Console.ForegroundColor = ConsoleColor.Yellow; 
                Console.WriteLine("        $" + weaponP); 
                Console.ResetColor();
                Console.Write("   | (A)rmor:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("         $" + amorP);
                Console.ResetColor();
                Console.Write("   | (P)otion:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("        $" + potionP);
                Console.ResetColor();
                Console.Write("   | (D)ifficulty:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    $" + difP);
                Console.ResetColor();
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.Write("Go to (T)awern and rest. Get some hp for ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write( restp+" $");
                Console.ResetColor();
                Console.WriteLine(".");
                Console.WriteLine();
                Console.WriteLine("  (L)eave Town");
                Console.WriteLine("  (Q)uit the game");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("      Your current statistics:");
                Console.WriteLine("           Player stats");
                Console.WriteLine("===============================");

                Console.WriteLine("  Current Health:    " + p.health);
                Console.WriteLine("  Weapon Strenght:   " + p.weaponValue);
                Console.WriteLine("  Armor Value:       " + p.armorValue);
                Console.WriteLine("  Avaiable Potions:  " + p.potions);
                Console.WriteLine("  Current Difficulty " + p.mods);
                Console.WriteLine("===============================");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("If you feel powerfull, try yourself in (R)aids");
                Console.ResetColor();
                Console.WriteLine();
               



                //Wait for input
                string input = Console.ReadLine().ToLower();
                if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponP, p);

                }
                else if (input == "a" || input == "armor")
                {
                    TryBuy("armor", amorP, p);

                }
                else if (input == "d" || input == "difficulty")
                {
                    TryBuy("dif", difP, p);

                }
                else if (input == "l" || input == "leave")
                {
                    //break;
                    Console.Clear();
                    Program.Print("You decided to leave the city for now.");
                    break;





                }
                else if (input == "q" || input == "quit")
                {
                    Program.Quit();
                }
                else if (input == "r" || input == "raid")
                {
                    Boss.LoadBossList(Program.currentPlayer);
                }
                else if (input == "t" || input == "tawern")
                {
                    Console.WriteLine();
                    
                    TryBuy("rest", restp, p);
                }
                else if (input == "puzzles")
                {
                    Encounters.PuzzleOneEncounter();
                }


            }


        }
        static void TryBuy(string item, int cost, Player p)
        {
            if (p.coins >= cost)
            {
                if (item == "potion")
                    p.potions++;
                else if (item == "weapon")
                    p.weaponValue++;
                else if (item == "armor")
                    p.armorValue++;
                else if (item == "dif")
                    p.mods++;
                else if (item == "rest")
                    p.health += 5;


                p.coins -= cost;

            }
            else
            {
                Console.WriteLine();
                Program.Print("You dont have enough gold!");


            }
        }
    }
}
