using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;
using System.Windows;

namespace Gra_Tekstowa
{
    public class Program
    {
        public static Random rand = new Random();
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }

            currentPlayer = Load(out bool newP);
            if (newP)
            {
                Encounters.FirstEncounter();
                Encounters.WizardEncounter(); // Wizard after rouge
                Encounters.RougeDungeonFightEncounter1(); //two fights with mobs
                Encounters.RougeDungeonFightEncounter2(); // ^
                Encounters.FirstBoss(); //1st boss
            }

            

            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }

        static Player NewStart(int i)
        {
            Console.Clear();
            Print("This game is created by Piotr Kasprzak, thanks for playing and appreciate any feedback.", 20);
            Console.WriteLine();
            Print("Version 0.0");
            Console.WriteLine();
            Print("Have fun!");
            Console.ReadKey();
            Console.Clear();
            Player p = new Player();
            Print("Guide:");
            Console.ReadKey();
            Console.WriteLine();
            Print("Please do not press Enter before a line of text ends. You might miss some valuable information.");
            Console.ReadKey();
            Console.WriteLine();
            Print("If u want perform action, enter its firts letter.");
            Console.ReadKey();
            Console.WriteLine();
            Print("For example: ");
            Console.WriteLine();
            Print("To (A)ttack, type \"a\".");
            Console.ReadKey();
            Console.WriteLine();
            Print("If u want to save game, go to town and quit the game. ");
            Console.WriteLine();
            Print("Game will save automatically as you hit 'Q'.");
            Console.ReadKey();
            Console.Clear();
            

            Print("Dungeon", 100);
            Console.ReadKey();
            Console.WriteLine();

            Print("Do you remember your name? ", 70);

            Console.WriteLine();
            p.name = Console.ReadLine();
            Console.Clear();
            Print("Select your characters class:");
            Console.WriteLine();
            Print("Warrior, Mage or Archer?");
            Console.WriteLine();
            Console.WriteLine();
            Print("Warrior- Basic Hero, no facilities.");
            Console.WriteLine();
            Print("Mage- Your potions heal you additional 5hp.");
            Console.WriteLine();
            Print("Archer- You have 100% chance of running to town.");
            Console.WriteLine();
            bool flag = false;
            while (flag==false)
            {
                flag = true;
                string input = Console.ReadLine().ToLower();
                if (input == "mage")
                {
                    p.currentClass = Player.PlayerClass.Mage;
                }
                else if (input == "archer")
                {
                    p.currentClass = Player.PlayerClass.Archer;
                }
                else if (input == "warrior")
                {
                    p.currentClass = Player.PlayerClass.Warrior;
                }
                else
                {
                    Console.WriteLine();
                    Print("Enter an existing class.");
                    flag = false;
                    Console.WriteLine();
                }
                

                
            }

            p.id = i;
            Console.Clear();
            Print("You awake in dark, cold room. You feel dizzy and that you are in trouble.");
            Console.ReadKey();
            Console.WriteLine();
            Print("You cant remember anything about your past.");
            Console.ReadKey();
            if (p.name == "")
            {
                Console.WriteLine();
                Print("You cant even remember your own name...");
                p.name = "Nameless";
            }
            else
            {
                Console.WriteLine();
                Print("All you know is that your name is " + p.name);
            }
            Console.ReadKey();
            Console.Clear();
            Print("You grope around in the complete darkness untill you find a door handle.");
            Console.ReadKey();
            Console.WriteLine();
            Print("You feel some resistance as you turn the handle but the rusty lock breaks with little effort.");
            Console.ReadKey();
            Console.WriteLine();
            Print("You see your captor standing with his back to you outside the door.");
            Console.ReadKey();

            return p;



        }

        public static void Quit()
        {
            Console.Clear();
            Save();
            
            Print("Your game is saved");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString() + ".level";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }

        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }

            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                Print("Choose your player:", 5);
                Console.WriteLine();

                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + ": " + p.name);
                }
                Console.WriteLine();
                Print("Please input player name or id (Id:# or playername).  ", 5);
                Console.WriteLine();
                Print("Additionally 'create' will start a new save.", 5);
                Console.WriteLine();

                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if (data[0] == "id")
                    {
                        if (int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if (player.id == id)
                                {
                                    return player;
                                }
                            }

                            Print("There is no player with that id!");
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Print("Your id need to be a number!");

                            Console.WriteLine();
                            Print("Press any key to continue.");
                            Console.ReadKey();


                        }
                    }
                    else if (data[0] == "create")
                    {
                        Player NewPlayer = NewStart(idCount);
                        newP = true;
                        return NewPlayer;


                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if (player.name == data[0])
                            {
                                return player;
                            }

                        }
                        Console.WriteLine();
                        Print("There is no player with that name!");
                        Console.ReadKey();

                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine();
                    Print("Your id need to be a number!");
                    Console.WriteLine();
                    Print("Press any key to continue.");
                    Console.ReadKey();
                }


            }



        }
        public static void Print(string text, int speed = 20)
        {
            SoundPlayer typingSound = new SoundPlayer("type/typewriter-1.wav");
            typingSound.PlayLooping();
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);

            }
            typingSound.Stop();
        }

        public static void ProgressBar(string fillerChar,string backGroundChar, decimal value,int size)
        {
            int dif = (int)(value * size);
            for(int i = 0; i < size; i++)
            {
                if (i < dif)
                    Console.Write(fillerChar);
                else
                    Console.Write(backGroundChar);
            }
        }
    }
}
