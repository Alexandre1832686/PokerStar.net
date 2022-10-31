using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    internal class partie
    {

        public partie(Joueur[] j)
        {
            Joueurs = j;
        }

        Joueur[] Joueurs = new Joueur[4];
        int indJoueurCourrant=0;
        int total = 5;
        public void AfficherJeu()
        {
            int a=0, b=0, c =0;

            switch(indJoueurCourrant)
            {
                case 0: a = 1; b = 2; c = 3; break;
                case 1: a = 2; b = 3; c = 0; break;
                case 2: a = 3; b = 0; c = 1; break;
                case 3: a = 0; b = 1; c = 2; break;
                default: break;
            }


            Console.WriteLine("______________________________________________");
            Console.WriteLine("                   " + Joueurs[b].getNom() + "(" + Joueurs[b].getArgent() + " $)");
            Console.WriteLine("                    ____   ____");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                    ----   ----");
            Console.WriteLine("                        " + Joueurs[b].getBet() + " $");
            Console.WriteLine("");
            Console.WriteLine(""); 
            Console.WriteLine("" + Joueurs[a].getNom() + "(" + Joueurs[a].getArgent() + " $)" + "                     " + Joueurs[c].getNom() + "(" + Joueurs[c].getArgent() + " $)");
            Console.WriteLine(" ____   ____                        ____   ____");
            Console.WriteLine("|    | |    |                      |    | |    |");
            Console.WriteLine("|    | |    |     Total : "+total+" $      |    | |    |");
            Console.WriteLine("|    | |    |                      |    | |    |");
            Console.WriteLine(" ----   ----                        ----   ----");
            Console.WriteLine("     "+Joueurs[a].getBet() + " $                               " + Joueurs[c].getBet() + " $");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                   " + Joueurs[indJoueurCourrant].getNom() +"("+ Joueurs[indJoueurCourrant].getArgent()+" $)");
            Console.WriteLine("                    ____   ____");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                   |  " + Joueurs[indJoueurCourrant].getMain().GetCarte(0).valeur + " | |  " + Joueurs[indJoueurCourrant].GetMain().GetCarte(1).valeur +" |");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                    ----   ----");
            Console.WriteLine("                        " + Joueurs[indJoueurCourrant].getBet() + " $");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("|     1-Bet     |     2-Call     |     3-Raise     |     4-fold     |");
            Console.WriteLine("---------------------------------------------------------------------");


        }
    }
}
