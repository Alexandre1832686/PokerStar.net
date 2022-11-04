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
            //bug mise min
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
                if (Tour.GameisOver)
                {
                    //Ajouter jouer plusieurs games
                    //AskToPlayAgain();
                }
                else
                {
                    do
                    {
                        p.AfficherJeu();
                        if (joueurs[p.indJoueurCourrant].GetEtat())
                        {
                            p.SelectionAction(joueurs[p.indJoueurCourrant]);
                        }
                    } while (!toutLeMondeAJoue(joueurs, joueurs[p.indJoueurCourrant]) || !betisequal(joueurs, p));
                    p.AugmenterEtatTour();
                }
            }
        }


        static bool betisequal(Joueur[] j, partie p)
        {
            List<Joueur> joueurDebout = new List<Joueur>();
            

            foreach (Joueur joueur in j)
            {
                if(joueur.GetEtat())
                {
                    joueurDebout.Add(joueur);
                }
            }
            
            if(joueurDebout.Count()==1)
            {
                p.distribuerPot(joueurDebout[0]);
                return true;
            }
            else
            {
                bool verif = true;
                int maxBet = joueurDebout[0].GetBet();
                for (int i = 1; i < joueurDebout.Count; i++)
                {
                    if (joueurDebout[i].GetBet() != maxBet)
                    {
                        verif = false;
                    }
                }
                return verif;
            }
        }

        static bool toutLeMondeAJoue(Joueur[] j, Joueur joueurActu)
        { 
            joueurActu.nbActionDansTour++;

            bool verif = true;

            foreach(Joueur joueur in j)
            {
                if(joueur.nbActionDansTour==0)
                {
                    verif = false;
                }
            }

            return verif;
        }
    }
}
