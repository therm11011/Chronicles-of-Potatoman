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

        public void attackPlayer(character character , character target)
        {
            Random expectedDamage = new Random();
            int actualDamage = expectedDamage.Next(10);
            target.charHP -= actualDamage;
            Console.WriteLine(character.charName + " Attacked " + target.charName + "! With a damage of " + actualDamage + "! Current HP: " + target.charHP);

            if (target.charHP <= 0)
            {
                Console.WriteLine("You slain " + target.charName);
            }
        }

        
    }

    class hero : character 
    {
        private int exp;
        public void heroSpeech() 
        {
            Console.WriteLine("Ako si PotatoMan");
        }

        public int charExp
        {
            get { return exp; }
            set { exp = value; }
        }

        public void levelCheck()
        {
            if (charExp == 10)
            {
                charLvl += 1;
                charExp = 0;
                Console.WriteLine("You level up to Level " + charLvl);
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

    class story
    {
        private string script;

        public string charScript 
        {
            get { return script; }
            set { script = value; }
        }
        public void displayScript(string targetScript)
        {
            if (targetScript.Contains('.'))
            {
                targetScript += '\n';
            }
            foreach (char c in targetScript) 
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            story firstPage = new story();
            hero hero1 = new hero();
            enemy enemy1 = new enemy();

            firstPage.charScript = "Once upon a time, there was a hero named PotatoMan.";
            firstPage.displayScript(firstPage.charScript);
            firstPage.charScript = "Potato Man was a man made of Potato, he has a talent of spreading potatoes.";
            firstPage.displayScript(firstPage.charScript);
            firstPage.charScript = "He was currently fighting a person who has a skin of spikes named Pena." + "\n";
            firstPage.displayScript(firstPage.charScript);


            hero1.charName = "POTATOMAN";
            hero1.charHP = 10;
            hero1.charSpeed = 2;
            hero1.charLvl = 1;
            hero1.charExp = 9;
            
            enemy1.charName = "PENA";
            enemy1.charHP = 10;
            enemy1.charSpeed = 2;
            enemy1.charLvl = 1;

            hero1.heroSpeech();
            Console.WriteLine(hero1.charName + " Stats: " + hero1.charHP + " " + hero1.charSpeed + " " + hero1.charLvl);
            Thread.Sleep(3000);
            enemy1.enemySpeech();
            Console.WriteLine(enemy1.charName + " Stats: " + enemy1.charHP + " " + enemy1.charSpeed + " " + enemy1.charLvl);
            Thread.Sleep(3000);

            hero1.speech();
            Console.WriteLine(enemy1.charName + ". " + hero1.charName + " said.");
            Thread.Sleep(3000);

            enemy1.speech();
            Console.WriteLine(hero1.charName + ". " + enemy1.charName + " said.");
            Thread.Sleep(3000);


            Random turn = new Random();
            int firstTurn = turn.Next(10);
            Console.WriteLine(firstTurn);

            if (firstTurn % 2 == 0)
            {
                Console.WriteLine(hero1.charName + " Turns First!");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine(enemy1.charName + " Turns First!");
                Thread.Sleep(3000);
            }

            while (true)
            {
                if (firstTurn % 2 == 0)
                {
                    if (enemy1.charHP > 0 && hero1.charHP > 0) 
                    {
                        hero1.attackPlayer(hero1, enemy1);
                        if (hero1.charHP > 0 && enemy1.charHP > 0)
                        {
                            enemy1.attackPlayer(enemy1, hero1);
                            
                        }
                        Thread.Sleep(3000);
                    }

                }
                else
                {
                    if (hero1.charHP > 0 && enemy1.charHP > 0)
                    {
                        enemy1.attackPlayer(enemy1,hero1);
                        if (enemy1.charHP > 0 && hero1.charHP > 0)
                        {
                            hero1.attackPlayer(hero1, enemy1);
                            
                        }
                        Thread.Sleep(3000);
                    }
                }


                if (enemy1.charHP <= 0)
                {
                    hero1.charExp += 1;
                    Console.WriteLine(hero1.charName.ToUpper() + " WINS!");
                    break;
                }
                else if(hero1.charHP  <= 0)
                {
                    Console.WriteLine(enemy1.charName.ToUpper() + " WINS!");
                    break;
                }
                
            }
            hero1.levelCheck();
        }
    }
}
