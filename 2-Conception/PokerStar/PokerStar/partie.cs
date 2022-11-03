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
        Joueur[] joueurs;
        public partie(Joueur[] j)
        {
            joueurs = j;
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

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("        Total : " + total + " $");

            if (!joueurs[c].GetEtat())
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("   |    | |    |");

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

            for(int i =0;i<5;i++)
            {
                AfficherCartePub(i);
            }
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

            switch(choix)
            {
                case 1:
                    //joueurs[indJoueurCourrant].Call();
                    break;
                case 2:
                    joueurs[indJoueurCourrant].Miser();
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
            int posx = 30;
            int posy = 5;
            Console.SetCursorPosition(posx, posy);
            Console.WriteLine(" ____   ____");
            Console.SetCursorPosition(posx +10, posy);
            Console.WriteLine("|    | |    |");
            Console.SetCursorPosition(posx + 20, posy);
            Console.WriteLine("|    | |    |");
            Console.SetCursorPosition(posx + 30, posy);
            Console.WriteLine("|    | |    |");
            Console.SetCursorPosition(posx + 40, posy);
            Console.WriteLine(" ----   ----");
        }
    }
}
