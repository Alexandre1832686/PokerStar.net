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
                Tuple<string, string> Joueur = NomPseudo();
                Joueur j = new Joueur(Joueur.Item1, Joueur.Item2);
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
        //variable pour compter les joueurs
        static int x = 1;
        static System.Tuple<string,string> NomPseudo()
        {
            string nom, pseudo;
            

            Console.WriteLine("Joueur " + x + " Quel est votre nom :");
            nom = Console.ReadLine();
            Console.WriteLine("Joueur " + x + " Quel est votre Pseudo :");
            pseudo = Console.ReadLine();
            x++;
            return System.Tuple.Create <string,string>(nom,pseudo);
        }
    }
}
