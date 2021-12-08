using System;
using System.Collections.Generic;
using System.Text;

namespace Gra_Tekstowa
{
    [Serializable]
    public class Player
    {

        //Random rand = new Random();



        public string name;
        public int id;
        public int coins = 10000;
        public int health = 15;
       // public int damage = 1;
        public int armorValue = 0;
        public int potions = 5;
        public int weaponValue = 1;

        public int level = 1;
        public int xp = 0;
        public int mods = 0;
        public int RP = 0;// Rp zeby wlaczyc kolejnego raida po 1 bossie rp=1 itd.

        public enum PlayerClass { Mage, Archer, Warrior};
        public PlayerClass currentClass = PlayerClass.Warrior;

        public int GetHealth()
        {
            int upper = (2 * mods +level+ 5);
            int lower = (mods + 2);
            return Program.rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * mods +level+ 2);
            int lower = (mods + 2);
            return Program.rand.Next(lower, upper);
        }
        public int GetCoins()
        {
            int upper = (15 * mods + 50);
            int lower = (10 * mods + 10);
            return Program.rand.Next(lower, upper);
        }
        public int GetXP()
        {
            int upper = (20 * mods + 50);
            int lowe = (15 * mods + 10);
            return Program.rand.Next(lowe, upper);
        }

        public int GetLevelUpValue()
        {
            return 100 * level + 400;
        }
        public bool CanLevelUp()
        {
            if (xp >= GetLevelUpValue())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void LevelUp()
        {
            while (CanLevelUp())
            {
                xp -= GetLevelUpValue();
                level++;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Program.Print("You just leveled up.");
            Console.WriteLine();
            Program.Print("You are now level " + level+".");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Program.Print("As you lvl up, your potions restore now +1HP");
            Console.ResetColor();


            if (Program.currentPlayer.level == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Program.Print("As a reward of getting lvl 2 you gain 2 Potions.");
                Program.currentPlayer.potions += 2;
                Console.ResetColor();

            }
            if (Program.currentPlayer.level == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Program.Print("As a reward of getting lvl 3 you gain +1 to your weapon and armor values.");
                Program.currentPlayer.weaponValue += 1;
                Program.currentPlayer.armorValue += 1;
                Console.ResetColor();

            }
            if (Program.currentPlayer.level >= 4)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Program.Print("As a reward of getting lvl "+Program.currentPlayer.level+ " you gain +1 to your weapon and armor values.");
                Program.currentPlayer.weaponValue += 1;
                Program.currentPlayer.armorValue += 1;
                Console.ResetColor();
            }

            
            Console.ResetColor();
        }
    }
}
