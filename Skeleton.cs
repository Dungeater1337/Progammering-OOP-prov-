using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Progammering_OOP_prov_
{
    class Skeleton : Enemy 
    {
        //Konstruktor för skelett 
        public Skeleton(string name, int health, int damage) : base (name, health, damage) { }

        //det här är Skeletons Attack metod
        public override int Attack()
        {
            //Använder random för att skapa 'chances' för att få crit eller inte
            Random rnd = new Random();
            // Skelett har 25% att träffa critical-strike
            if(rnd.Next(1, 5) == 1)
            {
                //om Crit träffas så kan skeleton göra 21 - 35 skada
                int damage = rnd.Next(21, 36);
                Console.WriteLine($"{GetName()} lands crit for {damage} damage!");
                //returna damage
                return damage;
            }
            else
            {
                //Om det inte är crit så kan skeleton endast skada 10 - 20 skada
                int damage = rnd.Next(10, 21);
                Console.WriteLine($"{GetName()} hits attack for {damage} damage!");
                // returna damage 
                return damage;
            }
        }

    }
}