using System;
using System.Collections.Generic;
using System.Text;

namespace Gra_Tekstowa
{
    public class Boss
    {
        public static void LoadBossList(Player p)
        {

            RunBossList(p);
        }

        public static void RunBossList(Player p)
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("  Raids are sequences where you fight bunch of enemies and at the end Boss is waiting for you.  ");
            Console.WriteLine("                         High risk - High reward!");
            Console.WriteLine("RAIDS ARE NOT COMPLETE YET.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            if (Program.currentPlayer.RP >= 1)
            {
                Console.Write("1: Raid 1 - Forest - Completed");
            }
            else if (Program.currentPlayer.RP < 1) 
            {
                Console.WriteLine("1: Raid 1 - Forest");
            }
            Console.WriteLine();
            if (Program.currentPlayer.RP >= 2)
            {
                Console.Write("2: Raid 2 - Swamp - Completed");
            }
            else if (Program.currentPlayer.RP < 2) 
            {
                Console.WriteLine("2: Raid 2 - Swamp");
            }
            Console.WriteLine();
            if (Program.currentPlayer.RP >= 3)
            {
                Console.Write("3: Raid 3 - Catacombs - Completed");
            }
            else if (Program.currentPlayer.RP < 3)
            {
                Console.WriteLine("3: Raid 3 - Catacombs");
            }
            Console.WriteLine();
            Console.WriteLine("4: Raid 4");
            Console.WriteLine();
            Console.WriteLine("Enter Raids number to begin.");
            string input = Console.ReadLine().ToLower();

            // FIRST RAID
            if (input == "1" || input == "forest")
            {
               // Console.Clear();
                Console.WriteLine();
                Program.Print("You decided to begin first raid.");
                Console.ReadKey();
                Console.Clear();
                Program.Print("You heard from people around town that there is monster in nearby forest.");
                Console.WriteLine();
                Console.ReadKey();
                Program.Print("  \"He is stealing out supplies\" ");
                Console.WriteLine();
                Program.Print("  \"We will pay you if you deal with our problem\"");
                Console.WriteLine();
                Console.ReadKey();
                Program.Print("Do you think that are you ready to deal with the Beast? (yes/ no)");
                Console.WriteLine();
                string inputBoss1 = Console.ReadLine().ToLower();
                if (inputBoss1 == "yes" ||inputBoss1== "y")
                {
                    Console.WriteLine();
                    Program.Print("Thats great!");

                    Console.ReadKey();
                    Console.Clear();
                    Program.Print("You enter area covered by shadows.");
                    Console.WriteLine();
                    Program.Print("The sun's rays do not pass through the dense canopy of trees.");
                    Console.WriteLine();
                    Program.Print("As you follow the path you hear disturbing noises in the distance.");
                    Console.WriteLine();
                    Program.Print("A few dozen meters further you can see a dark figure crouching over the carcass of a villager.");
                    Console.WriteLine();
                    Program.Print("You try to run up to the monster, but after hearing your steps, it went crazy and ran away into the darkness.");
                    Console.WriteLine();
                    Program.Print("when you approached the villager, you heard his last words.");
                    Console.WriteLine();
                    Program.Print("   \"Please save my daughter, she disappeared a few days ago.\"");
                    Console.WriteLine("");
                    Program.Print("   \"The last place I know of her whereabouts is the border of the forest.\"");
                    Console.WriteLine();
                    Console.ReadKey();
                    Program.Print(".........................");
                    Console.WriteLine();
                    Console.ReadKey();

                    Program.Print("He passed away.");
                    Console.WriteLine();
                    Program.Print(" You followed the footsteps of the beasts left behind.");
                    Console.ReadKey();
                    Console.Clear();
                    Program.Print("During the journey, you felt someone's eyesight on yourself.");
                    Console.WriteLine();
                    Program.Print("A few steps later you heard the sound of trampled leaves behind you");
                    Console.WriteLine();
                    Program.Print("you turned and the beast was already charging on you.");
                    Console.WriteLine();
                    Program.Print("You managed to jump back in the last moment, the monster only scratched you slightly.");
                    Console.WriteLine();
                    Program.Print("It is a Werewolf.");
                    Console.ReadKey();
                    Console.Clear();

                    Encounters.RaidOneBoss();
                    Console.Clear();
                   // Console.ReadKey();
                    Program.Print("you decide to go further"); // zmiana
                    Console.WriteLine();
                    //dodac historie ===================================================================================
                    Program.Print("you fight with werewolf again"); //zmiana
                    Console.ReadKey();
                    Encounters.RaidOneBossv2();
                    Console.WriteLine("The beast is finally dead.");
                    Program.currentPlayer.coins += 1000;
                    Program.currentPlayer.xp += 1000;
                    Console.Write("You gained 1000coins and 500xp");
                    Console.Clear();
                    if (Program.currentPlayer.CanLevelUp())
                    {
                        Program.currentPlayer.LevelUp();
                    }
                    Console.ReadKey();
                    Console.Clear();


                    Program.Print("monster has been slain");
                    Console.WriteLine();
                    Program.Print("you go back to town.");
                    Console.WriteLine();
                    Console.ReadKey();
                    Program.currentPlayer.RP = 1;


                }
                else if(inputBoss1 == "no" || inputBoss1 == "n")
                {
                    Console.WriteLine();
                    Program.Print("I see, come back whenever you will feel ready.");
                    Console.WriteLine();
                    Console.ReadKey();
                }

                

            }
            if(input=="swamp" || input=="2")
            {
                

                if ( Program.currentPlayer.RP >= 1)
                {
                    Program.Print("You decide to begin second raid");
                    Console.ReadKey();
                    Console.Clear();
                    Encounters.BasicFightEncounter();
                    Program.currentPlayer.RP = 2;

                }
                else if (Program.currentPlayer.RP < 1)
                {
                    Program.Print("You have to complete all previos raids to acces this one.");
                    Console.ReadKey();
                    RunBossList(p);
                }

            }
            if (input == "catacombs" || input == "3")
            {
                if (Program.currentPlayer.RP >= 2)
                {
                    Program.Print("You decide to begin third raid");
                    Console.ReadKey();
                    Console.Clear();
                    Encounters.BasicFightEncounter();
                    Program.currentPlayer.RP = 3;

                }
                else if (Program.currentPlayer.RP < 2)
                {
                    Program.Print("You have to complete all previos raids to acces this one.");
                    Console.ReadKey();
                    RunBossList(p);
                }

            }
           






        }




    }
}
