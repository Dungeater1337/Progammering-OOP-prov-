using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Progammering_OOP_prov_
{
    class Orc : Enemy 
    {
        // Konstruktor för Orc
        public Orc(string name, int health, int damage, int berserk) : base (name, health, damage) { }

        // Attack metod för 'Orc'
        public override int Attack()
        {
            //Använder random för att skapa 'chances' för att få crit eller inte
            Random rnd = new Random();
            // Skelett har 25% att träffa critical-strike
            if(rnd.Next(1, 5) == 1)
            {
                //om Crit träffas så kan Orc göra 25 - 45 skada
                int damage = rnd.Next(25, 46);
                Console.WriteLine($"{GetName()} lands crit for {damage} damage!");
                //returna damage
                return damage;
            }
            else
            {
                //Om det inte är crit så kan Orc endast skada 15 - 30 skada
                int damage = rnd.Next(15, 31);
                Console.WriteLine($"{GetName()} hits attack for {damage} damage!");
                // returna damage 
                return damage;
            }
        }
    }
}