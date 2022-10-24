using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    internal class partie
    {
        Joueur[] Joueurs = new Joueur[4];
        int indJoueurCourrant;

        void AfficherJeu()
        {
            int a, b, c =0;
            switch(indJoueurCourrant)
            {
                case 0: a = 1; b = 2; c = 3; break;
                case 1: a = 2; b = 3; c = 0; break;
                case 2: a = 3; b = 0; c = 1; break;
                case 3: a = 0; b = 1; c = 2; break;
            }


            Console.WriteLine("______________________________________________");
            Console.WriteLine("                     " + j.getNom());
            Console.WriteLine("                    ____   ___");
            Console.WriteLine("                   |    | |   |");
            Console.WriteLine("                   |    | |   |");
            Console.WriteLine("                   |    | |   |");
            Console.WriteLine("                    ----   ---");
            Console.WriteLine("                     " + j.GetBet() + " $");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("" + j.getNom()+"               " + j.getNom);
            Console.WriteLine(" ____   ___                        ____   ___");
            Console.WriteLine("|    | |   |                      |    | |   |");
            Console.WriteLine("|    | |   |                      |    | |   |");
            Console.WriteLine("|    | |   |                      |    | |   |");
            Console.WriteLine(" ----   ---                        ----   ---");
            Console.WriteLine(j.GetBet() + " $            " + j.GetBet() + " $");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                   " + Joueurs[indJoueurCourrant].getNom());
            Console.WriteLine("                    ____   ___");
            Console.WriteLine("                   |    | |   |");
            Console.WriteLine("                   |    | |   |");
            Console.WriteLine("                   |    | |   |");
            Console.WriteLine("                    ----   ---");
            Console.WriteLine("                      " + Joueurs[indJoueurCourrant].GetBet() + " $");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("|     1-Bet     |     2-Call     |     3-Raise     |     4-fold     |");
            Console.WriteLine("---------------------------------------------------------------------");


        }
    }
}
