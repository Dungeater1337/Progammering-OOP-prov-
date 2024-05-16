using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Progammering_OOP_prov_
{
    class Enemy : Character
    {
        private int damage; 

        public Enemy(string name, int health, int damage) : base(name, health) 
        {
            this.damage = damage;
        }

        public int Getdamage() => damage;

        public override int Attack()
        {
            Console.WriteLine($"{GetName()} attacks for {damage} damage!");
            return damage;
        }
    }
}