using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Progammering_OOP_prov_
{

    // Spelarklass
    class Player : Character
    {
        public Player(string name, int health) : base(name, health) { }

        public override int Attack()
        {
            Random rnd = new Random();
            // Spelaren har 25% att träffa critical-strike
            if(rnd.Next(1, 5) == 1){
                int damage = rnd.Next(25, 46);
                Console.WriteLine($"{GetName()} attacks for {damage} damage!");
                return damage;
            }
            else{
                int damage = rnd.Next(10, 21);
                Console.WriteLine($"{GetName()} attacks for {damage} damage!");
                return damage;
            }
        }

        public void Heal()
        {
            Random rnd = new Random();
            // 30% att healing misslyckas
            if(rnd.Next(1, 4) == 1)
            {
                Console.WriteLine($"Healing failed!");
            }
            // 50% att få en "Good Heal"
            else if(rnd.Next(1, 3) == 1)
            {
                Console.WriteLine($"{GetName} achieved a good heal!");
                health += 40;
            }
            else
            {
                Console.WriteLine($"{GetName} achieved a normal heal!");
                health += 20;
            }
            health = (int)MathF.Min(health,100);
        }
    }
}