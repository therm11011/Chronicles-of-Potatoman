// See https://aka.ms/new-console-template for more information
using System;
namespace exercise
{
    class character
    {
        private string name;
        private int hp;
        private int speed;
        private int lvl;

        public string charName
        {
            get { return name; }
            set { name = value; }
        }
        public int charHP
        {
            get { return hp; }
            set { hp = value; }
        }
        public int charSpeed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int charLvl
        {
            get { return lvl; }
            set { lvl = value; }
        }
        public void speech()
        {
            Console.Write("TANGINA KA ");
        }
    }

    class hero : character 
    {
        public void heroSpeech() 
        {
            Console.WriteLine("Ako si PotatoMan");
        }

        public void attackPlayer(character target)
        {
            Console.WriteLine("You Attacked " + target.charName);
            target.charHP -= 1;

            if (target.charHP == 0)
            {
                Console.WriteLine("You slain " + target.charName);
                
            }
        }
    }

    class enemy : character
    {
        public void enemySpeech() 
        {
            Console.WriteLine("Ako si Pena");
        }
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            hero hero1 = new hero();
            enemy enemy1 = new enemy();

            hero1.charName = "POTATOMAN";
            hero1.charHP = 10;
            hero1.charSpeed = 2;
            hero1.charLvl = 1;
            
            enemy1.charName = "PENA";
            enemy1.charHP = 10;
            enemy1.charSpeed = 2;
            enemy1.charLvl = 1;

            hero1.heroSpeech();
            Console.WriteLine(hero1.charName + "Stats: " + hero1.charHP + " " + hero1.charSpeed + " " + hero1.charLvl);
            enemy1.enemySpeech();
            Console.WriteLine(enemy1.charName + "Stats: " + enemy1.charHP + " " + enemy1.charSpeed + " " + enemy1.charLvl);

            hero1.speech();
            Console.WriteLine(enemy1.charName + ". " + hero1.charName + " said.");
            enemy1.speech();
            Console.WriteLine(hero1.charName + ". " + enemy1.charName + " said.");

            while (true)
            {
                hero1.attackPlayer(enemy1);
                Console.WriteLine(enemy1.charName + " HP: " + enemy1.charHP);
                if (enemy1.charHP == 0) 
                { 
                    break;
                }
            }
        }
    }
}
