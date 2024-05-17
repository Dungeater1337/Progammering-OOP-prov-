using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Progammering_OOP_prov_
{
    class Game
    {

        // Spelaren
        private Player player;

        // Lista av fiender som spelaren måste döda
        private List<Enemy> enemies;

        // Lista med poäng
        private List<int> scores; 

        public Game()
        {
            player = new Player("Player", 150); // Intielera spelaren samt liv
            enemies = new List<Enemy>()
            {
                // fiender  med hp och damage
                new Skeleton("Skeleton", 100, 0, 25) 
            };
            scores = new List<int>();
        }

        private void SaveScore()
        {
            scores.Add(player.GetHealth());
            scores = scores.OrderByDescending(s => s).Take(3).ToList();

            using(StreamWriter writer = new StreamWriter("scores.txt"))
            {
                foreach (var score in scores)
                {
                    writer.WriteLine(score);
                }
            }
        }

        public void Play()
        {
            bool running = true;
            while (running == true)
            {
                Console.WriteLine("\n|--------------|Dark Dungeon I : Legacy of the Flame|--------------|");
                Console.WriteLine("          |-------------+A New Battle Begins!+-----------|\n");

                foreach (var enemy in enemies)
                {
                    Console.WriteLine($"  A wild {enemy.GetName()} appears!\n");
                    while( player.GetHealth() > 0 && enemy.GetHealth() > 0)
                    {
                        Console.WriteLine("|----------------------------------------------|");
                        Console.WriteLine($"  {player.GetName()} Health: {player.GetHealth()}\n  {enemy.GetName()} Health: {enemy.GetHealth()}");
                        Console.WriteLine("|----------------------------------------------|");
                        Console.WriteLine("\nChoose an action:\n1. Attack\n2. Attempt Heal\n");
                        string choice = Console.ReadLine();
                        Console.WriteLine("");

                        if(choice == "1")
                        {
                            enemy.SetHealth(enemy.GetHealth() - player.Attack());
                            if(enemy.GetHealth() > 0)
                            {
                                player.SetHealth(player.GetHealth() - enemy.Attack());
                                
                            }
                        }

                        else if(choice == "2")
                        {
                            player.Heal();
                        }

                        if(player.GetHealth() <= 0)
                        {
                            Console.WriteLine("YOU DIED!");
                            return;
                        }

                        if (enemy.GetHealth() <= 0)
                        {
                            Console.WriteLine($"You've deafted the {enemy.GetName()}!");   
                        }
                    }

                    Console.WriteLine("\nYou've won the Battle!");
                    SaveScore();
                    Console.WriteLine("Play again? (y/n)");
                    if(Console.ReadLine() !=  "y")
                    {
                        running = false;
                    }
                    player.SetHealth(150);
                }
            }
        }
    }
}