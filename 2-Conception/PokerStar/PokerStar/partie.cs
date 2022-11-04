using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    internal class partie
    {
        //variables
        Joueur[] joueurs;
        Tour tour;
        public int indJoueurCourrant = 0;
        public static int total = 0;

        //constructeur
        public partie(Joueur[] j)
        {
            joueurs = j;
            tour = new Tour();
            tour.SetJoueurs(joueurs);
        }
        
        /// <summary>
        /// Affichage : l'indice du joueur
        /// courrant permet de savoir à quel élément du tableau de joueur
        /// on doit faire apparêtre les cartes les autres joueurs ont leurs
        /// carte tourné mais on garde la trace de ceux-ci pour afficher dans
        /// le bon ordre leur nom, argent, et la couleur des cartes
        /// représente l'état. les cartes publiques sont affichés dans le coin
        /// et leurs valeur et couleur apparet seulement si la carte est tournée(bool visible)
        /// 
        /// Affiche le nom, l'argent,  le bet de la ronde en cours et l'état(grace a la couleur des cartes) de
        /// tout les joueurs et affiche le total a gagner a la fin de la ronde
        /// </summary>
        public void AfficherJeu()
        {


            if (indJoueurCourrant<3)
            {
                indJoueurCourrant++;
            }
            else
            {
                indJoueurCourrant = 0;
            }
            
            int a=0, b=0, c =0;

            switch(indJoueurCourrant)
            {
                case 0: a = 1; b = 2; c = 3; break;
                case 1: a = 2; b = 3; c = 0; break;
                case 2: a = 3; b = 0; c = 1; break;
                case 3: a = 0; b = 1; c = 2; break;
                default: break;
            }

            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                AfficherCartePub(i);
            }

            Console.SetCursorPosition(10, 15);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("        Total : " + total + " $");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("______________________________________________");
            Console.WriteLine("                   " + joueurs[b].GetPseudo() + "(" + joueurs[b].GetArgent() + " $)");
            if (!joueurs[b].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("                    ____   ____");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                    ----   ----");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                        " + joueurs[b].GetBet() + " $");
            Console.WriteLine("");
            Console.WriteLine(""); 
            Console.WriteLine("" + joueurs[a].GetPseudo() + "(" + joueurs[a].GetArgent() + " $)" + "                     " + joueurs[c].GetPseudo() + "(" + joueurs[c].GetArgent() + " $)");


            

            if (!joueurs[a].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write(" ____   ____");

            if (!joueurs[c].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("                        ____   ____");

            if (!joueurs[a].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write("|    | |    |");

            

            if (!joueurs[c].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("                      |    | |    |");

            if (!joueurs[a].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("|    | |    |");

            

            if (!joueurs[c].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("                      |    | |    |");

            if (!joueurs[a].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write("|    | |    |");



            if (!joueurs[c].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("                      |    | |    |");


            Console.ForegroundColor = ConsoleColor.White;

            if (!joueurs[a].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write(" ____   ____");

            if (!joueurs[c].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("                        ____   ____");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("     " + joueurs[a].GetBet() + " $                               " + joueurs[c].GetBet() + " $");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                   " + joueurs[indJoueurCourrant].GetPseudo() + "(" + joueurs[indJoueurCourrant].GetArgent() + " $)");
            Console.WriteLine("                    ____   ____");
            Console.WriteLine("                   |    | |    |");
            Console.WriteLine("                   |  " + ConvertirValeur(joueurs[indJoueurCourrant].GetMain().GetCarte(0).valeur) + "| |  " + ConvertirValeur(joueurs[indJoueurCourrant].GetMain().GetCarte(1).valeur) + "|");
            Console.WriteLine("                   |  " + ConvertirCouleur(joueurs[indJoueurCourrant].GetMain().GetCarte(0).couleur) + " | |  " + ConvertirCouleur(joueurs[indJoueurCourrant].GetMain().GetCarte(1).couleur) + " |");
            Console.WriteLine("                    ----   ----");
            Console.WriteLine("                        " + joueurs[indJoueurCourrant].GetBet() + " $");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("|     1-Call     |     2-Raise     |     3-fold     |");
            Console.WriteLine("---------------------------------------------------------------------");

            Console.SetCursorPosition(10, 15);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("        Total : " + total + " $");
            Console.SetCursorPosition(0, 32);

        }

        /// <summary>
        /// deamande une entré corespondante au actions et appelle les fonctions relatives à la selection(Call Raise et Fold)
        /// </summary>
        /// <param name="j"></param>
        public void SelectionAction(Joueur j)
        {
            int choix;
            bool verif = false;
            do
            {
                string rep = Console.ReadLine();
                verif = int.TryParse(rep, out choix);

                if (choix > 3 || choix < 1)
                {
                    verif = false;
                }

            } while (verif == false);

            List<int> l = new List<int>();
            foreach(Joueur joueur in joueurs)
            {
                l.Add(joueur.GetBet());
            }
            int betTotalMax = l.Max();

            switch (choix)
            {
                
                case 1:
                    joueurs[indJoueurCourrant].call(betTotalMax - joueurs[indJoueurCourrant].GetBet());
                    total += joueurs[indJoueurCourrant].GetBet();
                    break;
                case 2:
                    joueurs[indJoueurCourrant].raise(betTotalMax - joueurs[indJoueurCourrant].GetBet() *2);
                    total += joueurs[indJoueurCourrant].GetBet();
                    break;
                case 3:
                    joueurs[indJoueurCourrant].Coucher();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Convertie la couleur (Text) en couleur (signe)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string ConvertirCouleur(Couleur a)
        {
            string retour;
            switch(a)
            {
                case Couleur.Pique:
                    retour = "\u2663";
                    break;
                case Couleur.Coeur:
                    retour = "\u2665";
                    break;
                case Couleur.treffle:
                    retour = "\u2660";
                    break;
                case Couleur.Carreau:
                    retour = "\u2666";
                    break;
                    default :
                    retour = "";
                    break;
            }
            return retour;
        }

        /// <summary>
        /// Transforme la valeur numérique en Lettres Lorsque nessessaire
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string ConvertirValeur(int a)
        {
            string retour;
            if(a == 11)
            {
                retour = "J ";
            }
            else if (a == 12)
            {
                retour = "Q ";
            }
            else if (a == 13)
            {
                retour = "K ";
            }
            else if(a == 10)
            {
                retour = "10";
            }
            else if (a == 1)
            {
                retour = "A";
            }
            else
            {
                retour = a + " ";
            }
            return retour;
        }

        //Affiche les Carte publiques à un endroit précis et affiche leurs force et couleur seulement si les cartes sont tournés
        void AfficherCartePub(int ind)
        {
            if(GetCartePublic(ind).visible)
            {
                int posx = 60;
                int posy = 3;
                Console.SetCursorPosition(posx + 8 * ind, posy);
                Console.Write(" ____");
                Console.SetCursorPosition(posx + 8 * ind, posy + 1);
                Console.Write("|    |");
                Console.SetCursorPosition(posx + 8 * ind, posy + 2);
                Console.Write("| " + ConvertirValeur(GetCartePublic(ind).valeur) + " |");
                Console.SetCursorPosition(posx + 8 * ind, posy + 3);
                Console.Write("|  " + ConvertirCouleur(GetCartePublic(ind).couleur) + " | ");
                Console.SetCursorPosition(posx + 8 * ind, posy + 4);
                Console.Write(" ----");
                
            }
            else
            {
                int posx = 60;
                int posy = 3;
                Console.SetCursorPosition(posx + 8 * ind, posy);
                Console.Write(" ____");
                Console.SetCursorPosition(posx + 8 * ind, posy + 1);
                Console.Write("|    |");
                Console.SetCursorPosition(posx + 8 * ind, posy + 2);
                Console.Write("|    |");
                Console.SetCursorPosition(posx + 8 * ind, posy + 3);
                Console.Write("|    | ");
                Console.SetCursorPosition(posx + 8 * ind, posy + 4);
                Console.Write(" ----");

                Console.SetCursorPosition(0, 0);
            }
            
        }

        //Renvoie une carte publique seulon l'indice envoyé en parametre
        public Carte GetCartePublic(int ind)
        {
            return tour.carteCommune[ind];
        }

        //passe à l'état suivant dans la partie (retourne des cartes)
        public void AugmenterEtatTour()
        {
            tour.AugmenterEtatTour();
        }

        //donne le pot à un joeur
        public void distribuerPot(Joueur j)
        {
            j.AddArgent(total);
            total = 0;
        }

        //verifie si la partie est terminer
        public void CheckIfGameIsOver(List<Joueur> joueurs)
        {
            for(int i = 0; i < 4;)
            {
                if (joueurs[i].GetArgent() == 0)
                {

                }
            }
        }

    }
}
