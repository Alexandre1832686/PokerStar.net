using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{


    public class Joueur
    {
        //déclaration des variables
        string nom;
        string pseudo;
        int argent;
        int bet;
        bool actif;
        MainJoueur main = new MainJoueur();

        //Constructeur de Joueur
        public Joueur(string nom, string pseudo){
            this.nom = nom;
            this.pseudo = pseudo;
            argent = 300;
            actif = false;
            }

        /// <summary>
        /// s'occupe de miser et de calculer la somme total que je joueur à miser 
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        public int Miser(int montant)
        {
            //si le montant que le joueur veux miser est supérieur à son montant total lui offre l'optin de all-in ce qu'il lui reste
            //et si c'est correct 
            if (montant >= argent)
            {
                bool verif = false;
                int reponse;
                do {
                    Console.WriteLine("All in de " + argent + "?");
                    Console.WriteLine("1- Oui");
                    Console.WriteLine("2- Non");
                    verif = int.TryParse(Console.ReadLine(), out reponse);
                } while (verif==false || (reponse != 1 && reponse != 2));

                if (reponse == 1)
                {
                    bet += argent;
                    return argent;
                }

                else
                {
                    do
                    {
                        Console.WriteLine("Voulez-vous : ");
                        Console.WriteLine("1- miser une plus petite somme ");
                        Console.WriteLine("2- Vous couchez ");
                        verif = int.TryParse(Console.ReadLine(), out reponse);
                    } while (verif == false || (reponse != 1 && reponse != 2));

                    if (reponse == 1)
                    {
                        do
                        {
                            Console.WriteLine("Combien voulez-vous miser (reste " + argent + "$)");
                            verif = int.TryParse(Console.ReadLine(), out reponse);
                        } while (verif == false && reponse > 0);

                        return Miser(reponse);

                    }

                    else
                    {
                        Coucher();
                        return 0;
                    }
                }

                
            }
            else
            {
                argent -= montant;
                bet += montant;
                return montant;
            }
        }

        public void Check()
        {
            actif = true;
        }

        public void Coucher()
        {
            actif= false;
        }    

        public void ResetMain()
        {
            actif= true;
            main = new MainJoueur();
        }

        public string getNom()
        {
            return nom;
        }

        public int getBet()
        {
            return bet;
        }

        public void ResetBet()
        {
             bet = 0;
        }

        public int getArgent()
        {
            return argent;
        }

        public MainJoueur getMain()
        {
            return main;
        }

        public bool getEtat()
        {
            return actif;
        }
    }
}
