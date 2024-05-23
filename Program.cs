using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Progammering_OOP_prov_;

class Program
{

    //Härifrån körs kallas själva spelet
    static void Main(string[] args)
    {
        //skapar ett objekt av game
        Game game = new Game();
        //kallar 'play metoden' där spelets sätts ihop
        game.Play();
    }
}
