﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    internal class partie
    {
        Joueur[] joueurs;
        Tour tour;


        public partie(Joueur[] j)
        {
            joueurs = j;
            tour = new Tour();
            tour.SetJoueurs(joueurs);
        }
        
        public int indJoueurCourrant=0;
        int total = 0;
        public void AfficherJeu()
        {
            total = 0;
            foreach(Joueur joueur in joueurs)
            {
                total += joueur.GetBet();
            }
            

            if(indJoueurCourrant<3)
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
            Console.WriteLine("                   " + joueurs[b].GetNom() + "(" + joueurs[b].GetArgent() + " $)");
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
            Console.WriteLine("" + joueurs[a].GetNom() + "(" + joueurs[a].GetArgent() + " $)" + "                     " + joueurs[c].GetNom() + "(" + joueurs[c].GetArgent() + " $)");


            

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
            Console.WriteLine("                   " + joueurs[indJoueurCourrant].GetNom() + "(" + joueurs[indJoueurCourrant].GetArgent() + " $)");
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
                    break;
                case 2:
                    joueurs[indJoueurCourrant].raise(betTotalMax - joueurs[indJoueurCourrant].GetBet() *2);
                    break;
                case 3:
                    joueurs[indJoueurCourrant].Coucher();
                    break;
                default:
                    break;
            }
        }

        string ConvertirCouleur(Couleur a)
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
        string ConvertirValeur(int a)
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
            else
            {
                retour = a + " ";
            }
            return retour;
        }

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
        public Carte GetCartePublic(int ind)
        {
            return tour.carteCommune[ind];
        }
        public void AugmenterEtatTour()
        {
            tour.AugmenterEtatTour();
        }

        public void distribuerPot(Joueur j)
        {
            j.AddArgent(total);
        }

        public void CheckIfGameIsOver()
        {
            
        }

    }
}
