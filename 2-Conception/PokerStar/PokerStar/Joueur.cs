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
        //Mainjoueur mainJoueur;

        //Constructeur de Joueur
        public Joueur(string nom, string pseudo){
            this.nom = nom;
            this.pseudo = pseudo;
            argent = 300;
            actif = false;
            }

        public int Miser(int montant)
        {
            bet += montant;
            if (montant <= argent)
            {
                bool verif = false;
                int reponse;
                do {
                    Console.WriteLine("All in de " + argent + "?");
                    Console.WriteLine("1- Oui");
                    Console.WriteLine("2- Non");
                    verif = int.TryParse(Console.ReadLine(), out reponse);
                } while (verif==false || reponse == 1 && reponse == 2);

                if (reponse == 1)
                {
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
                    } while (verif == false || reponse == 1);
                    
                }

                if (reponse == 1)
                {

                }
                return montant;
            }
            else
            {
                return argent;
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
            //mainJoueur = new MainJoueur
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
    }
}
