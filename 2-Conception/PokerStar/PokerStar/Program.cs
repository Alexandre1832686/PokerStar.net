using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            paquet.Brasser();
            
            
            Joueur[] joueurs = new Joueur[4];
            Random rand = new Random();
             for(int i = 0; i < 4; i++)
             {
                 Joueur j = new Joueur("alex"+rand.Next(0,200), "al");
                 joueurs[i] = j;
             }
            
            partie p = new partie(joueurs);

            bool gameisover = false;
            while(!gameisover)
            {
                do
                {   
                    p.AfficherJeu();
                    if (joueurs[p.indJoueurCourrant].GetEtat())
                    {
                        p.SelectionAction(joueurs[p.indJoueurCourrant]);
                    }
                } while (!betisequal(joueurs));
                p.AugmenterEtatTour();
            }
        }
        static bool betisequal(Joueur[] j)
        {
            bool verif = true;
            int maxBet = j[0].GetBet();
            for(int i=1; i < j.Length; i++)
            {
                if(j[i].GetBet() != maxBet)
                {
                    verif = false;
                }
            }
            return verif;
        }
    }
}
