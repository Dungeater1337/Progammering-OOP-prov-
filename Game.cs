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
            // lista över alla fiender 
            enemies = new List<Enemy>()
            {
                // fiender med hp och damage
                new Skeleton("Skeleton", 100, 0), 
                new Orc("Orc", 120, 30, 0)
            };
            scores = new List<int>();
        }

        // funktion för att kunan spara poäng utifrån spelarens hälsa varje drabbning
        private void SaveScore()
        {
            // lägger till poäng utifrån spelarens hp
            scores.Add(player.GetHealth());
            // här får en lista över de tre högsta poängen från samlingen scores.
            scores = scores.OrderByDescending(s => s).Take(3).ToList();

            // Skapa en StreamWriter-instans för att skriva till filen "scores.txt"
            // 'using' säkerställer att StreamWriter stängs och resurser frisläpps när blocket avslutas
            using(StreamWriter writer = new StreamWriter("scores.txt"))
            {
                // iterera  genom varje poäng i samlingen 'scores'
                foreach (var score in scores)
                {
                    // skriver ut poängen
                    writer.WriteLine(score);
                }
            }
        }

        // Play metoden där själva spelet körs 
        public void Play()
        {
            // Så länge running är sant så körs spelet. 
            bool running = true;
            while (running == true)
            {
                Console.WriteLine("\n|--------------|Dark Dungeon I : Legacy of the Flame|--------------|");
                Console.WriteLine("          |-------------+A New Battle Begins!+-----------|\n");

                // För varje fiende i listan enemies som spelaren kan möta
                foreach (var enemy in enemies)
                {
                    Console.WriteLine($"  A wild {enemy.GetName()} appears!\n");
                    // Så länge spelaren och fienden har över 0 hp fortsätter drabbningen 
                    while( player.GetHealth() > 0 && enemy.GetHealth() > 0)
                    {
                        Console.WriteLine("|----------------------------------------------|");
                        Console.WriteLine($"  {player.GetName()} Health: {player.GetHealth()}\n  {enemy.GetName()} Health: {enemy.GetHealth()}");
                        Console.WriteLine("|----------------------------------------------|");

                        // Spelare alternativ mellan att göra skada och heala
                        Console.WriteLine("\nChoose an action:\n1. Attack\n2. Attempt Heal\n");
                        string choice = Console.ReadLine();
                        Console.WriteLine("");

                        if(choice == "1")
                        {
                            // Sätter fienders hp som sedan tar damage från spelar-attackmetoden
                            enemy.SetHealth(enemy.GetHealth() - player.Attack());
                            // om fienden fortfarende har över '0' hp så kommer Enemy göra en attack tillbaka
                            if(enemy.GetHealth() > 0)
                            {
                                player.SetHealth(player.GetHealth() - enemy.Attack());
                            }
                        }

                        else if(choice == "2")
                        {
                            // Spelaren kan ta få hp tillbaka genom 'Heal()' metoden 
                            player.Heal();
                            // Sätter Spelarens hp som sedan tar damage från enemymetoden 
                            player.SetHealth(player.GetHealth() - enemy.Attack());
                        }

                        // Om spelarens hp blir eller gå under 0, så dör spelaren. 
                        if(player.GetHealth() <= 0)
                        {
                            Console.WriteLine("YOU DIED!");
                            return;
                        }

                        // Om fiendens hp blir eller går under 0,
                        // så kommer ett meddelande som säger att fienden dog
                        if (enemy.GetHealth() <= 0)
                        {
                            Console.WriteLine($"You've deafted the {enemy.GetName()}!");   
                        }
                    }
                    Console.WriteLine("\nYou've won the Battle!");
                    // Savescore-metoden för att spara spelarens hp som poäng. 
                    SaveScore();
                    Console.WriteLine("Play again? (y/n)");
                    // Input är skilt från "y" så sätts 'running' till false och loopen breaks 
                    if(Console.ReadLine() !=  "y")
                    {
                        running = false;
                    }
                    // Ställer om spelarens hp inför nästa drabbning 
                    player.SetHealth(150);
                }
            }
        }
    }
}