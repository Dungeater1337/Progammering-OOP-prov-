using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Progammering_OOP_prov_
{

    // En Enemy class som ärver från Character 
    class Enemy : Character
    {

        // skapar en damage variabel
        private int damage; 

        // Konstruktor för Enemy
        public Enemy(string name, int health, int damage) : base(name, health) 
        {
            this.damage = damage;
        }

        // hämtar damage
        public int Getdamage() => damage;

        // Metod för int Attack()
        public override int Attack()
        {
            Console.WriteLine($"{GetName()} attacks for {damage} damage!");
            return damage;
        }
    }
}