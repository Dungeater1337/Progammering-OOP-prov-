using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Progammering_OOP_prov_
{

    //Ram för alla karaktärer
    abstract class Character
    {
        private string name;
        protected int health;

        // Alla karaktärer (inklusive spelaren) har ett namn och hitpoints
        public Character (string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        // Gettermetoder så andra klasser kan använda variablerna
        public string GetName() => name;
        public int GetHealth() => health;

        // Setmetod för att sätta hp 
        public void SetHealth(int value) => health = value;
        

        // Alla karaktärer i spelet ska kunna använda Attack() metoden
        public abstract int Attack();
    }
}