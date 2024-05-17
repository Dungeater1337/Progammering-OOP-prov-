using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Progammering_OOP_prov_
{
    class Skeleton : Enemy 
    {
        private int darkMagics;
        public Skeleton(string name, int health, int damage, int darkmagics) : base (name, health, damage) 
        {
            this.darkMagics = darkmagics;
        }
 

        public int GetDarkMagics()
        {
            return darkMagics;
        }

        public override int Attack()
        {
            Random rnd = new Random();
            // Spelaren har 25% att träffa critical-strike
            if(rnd.Next(1, 5) == 1)
            {
                int damage = rnd.Next(21, 35);
                Console.WriteLine($"{GetName()} lands crit for {damage} damage!");
                return damage;
            }
            else
            {
                int damage = rnd.Next(10, 21);
                Console.WriteLine($"{GetName()} hits attack for {damage} damage!");
                return damage;
            }
        }

    }
}