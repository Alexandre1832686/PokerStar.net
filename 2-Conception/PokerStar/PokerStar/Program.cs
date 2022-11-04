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
           
            //initialisation
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
            //vas rouler tant que la partie n'est pas fini
            while(!gameisover)
            {
                //si la partie est terminer, demande de rejouer, si repond non, ne change rien et ca vas sortir de la boucle. si repond oui, recommence une partie
                if (Tour.GameisOver)
                {
                    
                    AskToPlayAgain();
                }
                else
                {
                    //sort à la fin de l'étape
                    do
                    {
                        //deroulement d'un étape
                        p.AfficherJeu();
                        if (joueurs[p.indJoueurCourrant].GetEtat() || joueurs[p.indJoueurCourrant].GetArgent()==0)
                        {
                            p.SelectionAction(joueurs[p.indJoueurCourrant]);
                        }
                    } while (!toutLeMondeAJoue(joueurs, joueurs[p.indJoueurCourrant]) || !betisequal(joueurs, p));

                    //change l'étape et reset les bets
                    for (int i = 0; i < 4; i++)
                    {
                        joueurs[i].ResetBet();
                    }
                    p.AugmenterEtatTour();
                }
            }
        }

        /// <summary>
        /// verifie si tout les bets sont égaux
        /// </summary>
        /// <param name="j"></param>
        /// <param name="p"></param>
        /// <returns></returns>
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

        /// <summary>
        /// verifie si tout le monde à joué au moin une fois dans l'étape
        /// </summary>
        /// <param name="j"></param>
        /// <param name="joueurActu"></param>
        /// <returns></returns>
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

        //demande les nom et pseudo pour la création du joueur
        static Tuple<string,string> NomPseudo()
        {
            string nom, pseudo;
            

            Console.WriteLine("Joueur " + x + " Quel est votre nom :");
            nom = Console.ReadLine();
            Console.WriteLine("Joueur " + x + " Quel est votre Pseudo :");
            pseudo = Console.ReadLine();
            x++;
            return Tuple.Create <string,string>(nom,pseudo);
        }

        //demande si on veut rejoué et effectue les action nessessaire pour concordé en fonction de la réponse de l'utilisateur 
        static void AskToPlayAgain()
        {
            bool verif = false;
            int rep;
            string[] imagineCallLeMain = new string[] { "a" };
            do
            {
                Console.WriteLine("Voulez-vous rejouer ?:");
                Console.WriteLine("1 - oui 2 - non");
                verif = int.TryParse(Console.ReadLine(), out rep);
            } while (!verif && rep != 1 && rep != 2);
            if (rep == 1)
            {
                Main(imagineCallLeMain);
            }
            else 
                Console.ReadKey();
        }
    }
}
