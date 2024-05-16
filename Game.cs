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
                new Enemy("Skeleton", 100, 20),
                new Enemy("Bat", 55, 10),
                new Enemy("Orc", 120, 30)
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
            while (true)
            {
                Console.WriteLine("\n|-----------|Dark Dungeon IV|----------|");
                Console.WriteLine("|---------+A New Battle Begins!+--------|");

                foreach (var enemy in enemies)
                {
                    Console.WriteLine($"A wild {enemy.GetName()} appears!");
                    while( player.GetHealth() > 0 && enemy.GetHealth() < 0)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine($"{player.GetName} Health: {player.GetHealth()}\n{enemy.GetName()} Health: {enemy.GetHealth()}");
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("\nChoose an action:\n1. Attack\n2. Attempt Heal");
                        string choice = Console.ReadLine();

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

                        if(player.GetHealth() > 0)
                        {
                            Console.WriteLine("YOU DIED");
                            return;
                        }

                        if (enemy.GetHealth() <= 0)
                        {
                            Console.WriteLine($"You've deafted the {enemy.GetName()}!");   
                        }
                    }

                    Console.WriteLine("You've won the Battle!");
                    SaveScore();
                    Console.WriteLine("Play again? (y/n)");
                    if(Console.ReadLine() !=  "y")
                    {
                        break;
                    }
                    player.SetHealth(150);
                }
            }
        }
    }
}