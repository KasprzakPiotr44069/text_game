using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gra_Tekstowa
{
    public class Encounters
    {
        static Random rand = new Random();
        //Encounter Generic


        //Encounter
        public static void FirstEncounter()
        {
            Console.Clear();
            Program.Print("You throw open the door and grab a rusty metal sword while charging toward your captor ");
            Console.ReadKey();
            Console.WriteLine();
            Program.Print("He turns on you.");
            Console.ReadKey();
            Combat(false, "Rogue", 1, 4);
        }

        public static void BasicFightEncounter()
        {
            Console.Clear();
            Program.Print("You turn the corner and there you see a hulking beast.");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }
        public static void RougeDungeonFightEncounter1()
        {
            Console.Clear();
            Program.Print("As you run away, you find another masked person."); // tekst do zmiany
            Console.ReadKey();
            Combat(false, "Rogue Adept", 1, 3);
        }
        public static void RougeDungeonFightEncounter2()
        {
            Console.Clear();
            Program.Print("There is one more enemy behind you and an exit, you have to fight again."); // tekst do zmiany
            Console.ReadKey();
            Combat(false, "Rogue Warrior", 2, 4);
        }
        public static void WizardEncounter()
        {
            Console.Clear();
            Program.Print("As you defeated you captor, you see doors next to you cell, and you decide to open it.");
            Console.ReadKey();
            Console.WriteLine();
            Program.Print("The door slowly creaks open as you peer into the dark room.");
            Console.ReadKey();
            Console.WriteLine();
            Program.Print("Do u want to fight him?");
            Console.WriteLine();
            string input = Console.ReadLine();
            if (input == "yes" || input == "y")
            {
                Console.Clear();
                
                Program.Print("You can see an old, tall man that is looking at a large tome.");
                Console.ReadKey();
                Console.WriteLine();
                Program.Print("It looks like he didnt expect you here.");
                Console.ReadKey();
                Console.WriteLine();
                Program.Print("He stands of the old chair, grabes wooden staff and moves towards you.");
                Console.ReadKey();
                Combat(false, "Dark Wizard", 3, 2);
            }
            else if(input == "no" || input == "n")
            {
                Program.Print("You decided to go away.");
                Console.ReadKey();
            }

        }
        public static void FirstBoss()
        {
            Console.Clear();
            Program.Print("As you fight through bunch of enemies, you finally see an exit.");
            Console.ReadKey();
            Console.WriteLine();
            Program.Print("You try reach the door but giant man stays on your way.");
            Console.ReadKey();
            Console.WriteLine();
            Program.Print("    \"You wont run away from here, you belong to us!\"");
            Console.ReadKey();
            Combat(false, "Rogue Warchief", 3, 10);


        }
         // ===================================RAIDS
        public static void RaidOneBoss()
        {

            
            Combat(false, "Werewolf", 5, 20);
            
        }
        public static void RaidOneBossv2()
        {


            Combat(false, "Creazy Werewolf", 10, 5);

        }
        public static void PuzzleOneEncounter()
        {
            
            Console.Clear();
            Program.Print("Welcome in Puzzle training, go try yourself in solving puzzles.");
            Console.WriteLine();
            Program.Print("You wont lose HP here, if you fail, nothing happens to you.");
            Console.WriteLine();
            Program.Print("You have to figure a path through puzzles.");
            Console.WriteLine();
            Program.Print("Puzzles are checked one by one. youll see 4 sequences of puzzles.\nEnter first puzzle that you want to step on then enter the second etc.");
            Console.WriteLine();
            Program.Print("Remember, all you have to do is enter puzzle's position, not the simbol itself.");
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
            Program.Print("You are walking down a hall, You see that the floor is covered in runes.");
            Console.WriteLine();
            Console.WriteLine();
            List<char> chars = new char[]{ 'Đ', 'Ť', '┌', '┘', '■', '┴', '╬', 'Ů', 'Ä', '«' }.ToList();
            List<int> positions = new List<int>();
            char c = chars[rand.Next(0, 10)];
            chars.Remove(c);
            for (int y = 0; y < 4; y++)
            {
                int pos = rand.Next(0, 4);
                positions.Add(pos);
                for (int x = 0; x < 4; x++)
                {
                    
                    if (x == pos)
                    {
                        Console.Write(c);
                    }
                    else
                    {
                        
                        Console.Write(" " + chars[rand.Next(0, 8)] + " ");
                    }
                        
                }
                Console.Write("\n");
                Console.Write("\n");
            }
            Console.WriteLine();
            Console.WriteLine("Choose you path.");
            Console.WriteLine();
            for(int i = 0; i < 4; i++)
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int input) && input < 5 && input > 0)  
                    {
                        if (positions[i] == input - 1)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Darts fly out of the walls. You take zero damage ;)");
                            //Program.currentPlayer.health -= 2;
                            if (Program.currentPlayer.health <= 0)
                            {
                                Console.Clear();

                                Program.Print("Poison from the darts kill you. \n=============GAME OVER=============");
                                Console.ReadKey();
                                System.Environment.Exit(0);
                            }
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");

                    }

                }
            }
            Console.WriteLine("You have successfully crossed hallway.");
            Console.ReadKey();
        }

        //Encounter tools

        public static void RandomEncounter()
        {
            switch (rand.Next(0, 1))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                    //  case 1:
                    //     WizardEncounter(); // Wizard is cannon to kill
                    //     break;
            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            
            string n = "";
            
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();


            }
            else
            {
                n = name;
                p = power;
                h = health;

            }
            while (h > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ======================");
                Console.WriteLine("  "+n);
                Console.WriteLine("  Power: " + p + "/ Health " + h);
                Console.WriteLine("  ======================");
                Console.ResetColor();
                Console.WriteLine("  ======================");
                Console.WriteLine("  | (A)ttack  (D)efend |      $: " + Program.currentPlayer.coins);
                Console.WriteLine("  | (R)un     (H)eal   |");
                Console.WriteLine("  ======================");
                Console.WriteLine("   Actual Power: " + Program.currentPlayer.weaponValue);
                Console.WriteLine("   Actual Armor: " + Program.currentPlayer.armorValue);
                Console.WriteLine("   Potions: " + Program.currentPlayer.potions + "  Health: " + Program.currentPlayer.health);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("     Player Level: " + Program.currentPlayer.level);
                Console.Write("[");
                Program.ProgressBar("+", "-", ((decimal)Program.currentPlayer.xp / (decimal)Program.currentPlayer.GetLevelUpValue()), 25);

                Console.WriteLine("]");
                Console.WriteLine();
                Console.WriteLine("  (T)ips about fighting.");
                Console.WriteLine();
                string input = Console.ReadLine();


                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack
                    Console.WriteLine("With haste you surge forth, your sword is flying in your hands!\nAs you pass the" + n + " strikes you back.");
                    int damage = p - Program.currentPlayer.armorValue;
                    int upperDamage = Program.currentPlayer.weaponValue + 2;
                    if (damage < 0)
                    {
                        damage = 0;
                       
                    }
                    int attack = rand.Next(1, upperDamage);


                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }



                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend
                    Console.WriteLine("As the" + n + "You prepares to strike, you ready yourself in a defencive stance");
                    int upperDamage = Program.currentPlayer.weaponValue + 2;
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(1, upperDamage) / 2;

                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }


                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    if (Program.currentPlayer.currentClass == Player.PlayerClass.Archer)
                    {
                        Console.WriteLine();
                        Program.Print("You successfully escaped from the " + n);
                        Console.ReadKey();

                        //go to store
                        Console.Clear();
                        Shop.LoadShop(Program.currentPlayer);

                    }
                    else
                    {
                        if (n == "Rogue" || n == "Rogue Adept" || n == "Rogue Warrior" || n == "Rogue Warchief" || n == "Dark Wizard")
                        {
                            Console.WriteLine("You cant escape now, you have to fight your way out");
                        }
                        else if (rand.Next(0, 2) == 0)
                        {
                            Console.WriteLine("As you try to sprint away from the " + n + " its strikes you in the back sending you on the ground.");
                            int damage = p - Program.currentPlayer.armorValue;
                            if (damage < 0)
                            {
                                damage = 0;
                            }
                            Console.WriteLine("As a result you lose " + damage + " health and are unable to escape.");
                            Program.currentPlayer.health -= damage;


                        }

                        else
                        {

                            Console.WriteLine();
                            Program.Print("You successfully escaped from the " + n);
                            Console.ReadKey();

                            //go to store
                            Console.Clear();
                            Shop.LoadShop(Program.currentPlayer);



                        }




                    }
                    //Run
                    





                }


                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal
                    if (Program.currentPlayer.potions == 0)
                    {
                        Console.WriteLine("You run out of potions!");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Program.currentPlayer.health -= damage;
                        Console.WriteLine("While you were looking for a potion, " + n + " strikes you in the face.\n As a result you lose " + damage + " healt.");

                    }
                    else
                    {
                        Console.WriteLine("You fill your mouth with the contents of the bottle.");
                        int potionV;
                        if (Program.currentPlayer.currentClass == Player.PlayerClass.Mage)
                        {
                            potionV = (10 + Program.currentPlayer.mods + Program.currentPlayer.level - 1);
                        }
                        else
                        {
                            potionV = (5 + Program.currentPlayer.mods + Program.currentPlayer.level - 1);

                        }

                        Console.WriteLine("You gain " + potionV + " health");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine("As you were occupied, the " + n + " advanced and struck");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You lose " + damage + " health");
                        Program.currentPlayer.health -= damage;
                        Program.currentPlayer.potions -= 1;
                        int potionsLeft = Program.currentPlayer.potions;
                        Console.WriteLine("You have " + potionsLeft + " potions left");

                    }
                    //Console.ReadKey();
                }
                else if (input.ToLower() == "t" || input.ToLower() == "tips")
                {
                    Console.Clear();
                    Program.Print("Here are tips, how does fight work:");
                    Console.WriteLine();
                    Console.WriteLine();
                    Program.Print("If you attack, you will deal random damage, it is multiplied by your weapon value.");
                    Console.WriteLine();
                    Program.Print("However enemy will strike you back.");
                    Console.WriteLine();
                    Console.WriteLine();
                    Program.Print("If you decide to defend, in next turn, enemy will deal you lower damage depenind on your armor value.");
                    Console.WriteLine();
                    Program.Print("You will strike him back, but your damage will be lower. ");
                    Console.WriteLine();
                    Console.WriteLine();
                    Program.Print("If you decide to heal, you will restore small amount of your health points.");
                    Console.WriteLine();
                    Program.Print("However enemy will attack you anyway. ");
                    Console.WriteLine();
                    Console.WriteLine();
                    Program.Print("If you want to run, there will be chance you run away from enemy to town,");
                    Console.WriteLine();
                    Program.Print("If your escape fails, you will get attacked by your enemy.");
                }


                    if (Program.currentPlayer.health <= 0)
                    {
                    Console.Clear();

                    Program.Print("You are killed by the " + n + " !!!!\n=============GAME OVER=============");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                    }

                Console.ReadKey();
                if (n == "Werewolf" && h <= 0)
                {
                    Console.Clear();
                    Program.Print("The barely alive beast whined and plunged into the woods, running away from you");
                    //Program.currentPlayer.coins += 400;
                    Console.ReadKey();
                }

                if (h <= 0 && n != "Human Warchief")
                {
                    if(n != "Werewolf")
                    {
                        Console.Clear();
                        Program.Print("Congratulations!");
                        Console.WriteLine();
                        Program.Print("You have defeated " + n);
                        
                        Console.WriteLine();
                        
                        Console.ReadKey();
                    }
                    

                }
            }
            if (n == "Rogue Warchief" && h <= 0)
            {
                Console.Clear();
                Program.Print("    \"I will find you back, you belong to me!!!\"");
                Console.ReadKey();
                Console.Clear();

            }
            int c = Program.currentPlayer.GetCoins();
            int x = Program.currentPlayer.GetXP();
            if (n != "Rogue Warchief")
            {
                if (n != "Werewolf")
                {
                    if (n != "Creazy Werewolf")
                    {
                        

                        Console.WriteLine();
                        Program.Print("As you stay victorius over " + n + ", its body dissolves into " + c + " gold coins");
                        Console.WriteLine();
                        Program.Print("You have gained " + x + " XP.");
                        Program.currentPlayer.coins += c;
                        Program.currentPlayer.xp += x;
                        if (Program.currentPlayer.CanLevelUp())
                        {
                            Program.currentPlayer.LevelUp();

                        }
                        Console.ReadKey();

                        Console.Clear();
                    }
                }
                

            }
          
           


            if (n == "Rogue Warchief" && h <= 0)
            {
                Console.Clear();
                Program.Print("As you see that your enemy cant stand up, you decide to pick up his weapon\nand take potions that are left in his pockets.");
                Console.ReadKey();
                Console.WriteLine();
                Program.Print("..................");
                Console.ReadKey();
                Console.WriteLine();
                Program.Print("You found 2 full potions in his pockets, and took his sword.");
                Console.ReadKey();
                Console.WriteLine();
                Program.Print("Anything will be better than old rusty sword that you found before.");

                Console.ReadKey();
                Console.WriteLine();
                Program.Print("You gain +1 attack.");
                Console.ReadKey();
                Console.WriteLine();
                Program.Print("Last thing that you take from nearly dying opponent is his money.");
                Console.ReadKey();
                Console.WriteLine();
                Program.Print("You found 400 coins.");
                Console.WriteLine();
                Program.Print("You gain 700XP");
                Console.ReadKey();
                Console.WriteLine();
                Program.currentPlayer.xp += 700;
                Program.currentPlayer.coins = Program.currentPlayer.coins + 400;
                Program.currentPlayer.weaponValue++;
                Program.currentPlayer.potions = Program.currentPlayer.potions + 2;
                if (Program.currentPlayer.CanLevelUp())
                {
                    Program.currentPlayer.LevelUp();
                    Console.ReadKey();
                    Console.WriteLine();
                }
                

                Program.Print("Then you run away from the dungeon as fast as you can.");
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
                //Console.ReadKey();




            }
            if (n == "Dark Wizard" && h <= 0)
            {
                Console.Clear();

                Program.Print("As you defeat mage, you look around the room.");
                Console.ReadKey();
                Console.WriteLine();
                Program.Print("You found wooden shield, you decide to take it.");
                Console.ReadKey();
                Console.WriteLine();
                Program.Print("You gain +1 armor.");
                Console.ReadKey();
                Console.Clear();
                Program.currentPlayer.armorValue++;
            }
            /*if (n == "Stone Golem" && h <= 0)
           {
               Console.WriteLine("Raid 1 completed");
               Console.ReadKey();
               Console.WriteLine("You go back to town.");
               Console.ReadKey();
               Shop.LoadShop(Program.currentPlayer);
           } */

           /* if (Program.currentPlayer.level == 2)
            {
                Console.WriteLine();
                Program.Print("As a reward of getting lvl: 2 you gain 2 Potions.");
                Program.currentPlayer.potions += 2;
            }
           */ // zrobic to w lvlup.

        }
        public static string GetName()
        {
            
            switch (rand.Next(0, 3))
            {
                case 0:
                    return "Skeleton";

                case 1:
                    return "Zombie";
                
                case 2:
                    return "Grave Robber";



            }
            
            return "Vampire";
            

        }
        
    }
}
