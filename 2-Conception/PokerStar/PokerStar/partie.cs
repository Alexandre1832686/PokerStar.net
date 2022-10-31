using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    internal class partie
    {
        Joueur[] joueurs;
        public partie(Joueur[] j)
        {
            joueurs = j;
        }

        
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
            Console.WriteLine("                   " + joueurs[b].GetNom() + "(" + joueurs[b].GetArgent() + " $)");
            Console.WriteLine("                    ____   ____");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                    ----   ----");
            Console.WriteLine("                        " + joueurs[b].GetBet() + " $");
            Console.WriteLine("");
            Console.WriteLine(""); 
            Console.WriteLine("" + joueurs[a].GetNom() + "(" + joueurs[a].GetArgent() + " $)" + "                     " + joueurs[c].GetNom() + "(" + joueurs[c].GetArgent() + " $)");
            Console.WriteLine(" ____   ____                        ____   ____");
            Console.WriteLine("|    | |    |                      |    | |    |");
            Console.WriteLine("|    | |    |     Total : "+total+" $      |    | |    |");
            Console.WriteLine("|    | |    |                      |    | |    |");
            Console.WriteLine(" ----   ----                        ----   ----");
            Console.WriteLine("     "+joueurs[a].GetBet() + " $                               " + joueurs[c].GetBet() + " $");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                   " + joueurs[indJoueurCourrant].GetNom() +"("+ joueurs[indJoueurCourrant].GetArgent()+" $)");
            Console.WriteLine("                    ____   ____");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                   |  " + joueurs[indJoueurCourrant].GetMain().GetCarte(0).valeur + " | |  " + joueurs[indJoueurCourrant].GetMain().GetCarte(1).valeur +" |");
            Console.WriteLine("                   |  " + joueurs[indJoueurCourrant].GetMain().GetCarte(0).couleur + " | |  " + joueurs[indJoueurCourrant].GetMain().GetCarte(1).couleur +" |");
            Console.WriteLine("                    ----   ----");
            Console.WriteLine("                        " + joueurs[indJoueurCourrant].GetBet() + " $");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("|     1-Bet     |     2-Call     |     3-Raise     |     4-fold     |");
            Console.WriteLine("---------------------------------------------------------------------");


        }
    }
}
