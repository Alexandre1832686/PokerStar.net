using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{


    internal class Joueur
    {
        //déclaration des variables
        string nom;
        string pseudo;
        int argent;
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
            if (montant <= argent)
            {
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
    }
}
