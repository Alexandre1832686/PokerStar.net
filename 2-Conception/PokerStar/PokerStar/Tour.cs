using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    public class Tour
    {
        public Carte[] carteCommune = new Carte[5];
        int etatTour=0;
        Joueur[] lesJoueurs;
        public Tour()
        {
            RéinitialiserCartesCommunes();
        }
        /// <summary>
        /// permet de rendre les carte visible a tous selon le tour 
        /// </summary>
        public void ChangerEtat()
        {
            int position = 0;
            int inbCarteAtourner = 0;
            if(etatTour==1)
            {
                position = 0;
                inbCarteAtourner = 3;
            }
            else if(etatTour==2 )
            {
                position = 3;
                inbCarteAtourner = 1;
            }
            else if(etatTour == 3)
            {
                position=4;
                inbCarteAtourner = 1;
            }
            else if(etatTour == 4)
            {
                etatTour = 0;
                ResetTour(lesJoueurs);
                RéinitialiserCartesCommunes();
            }

            for (int i = position; i < inbCarteAtourner; i++)
            {
                carteCommune[i].retourner(true);
            }
        }
        /// <summary>
        /// Permet de resetter les mains et l'état des joueur ainsi que remettre face cacher les carte commune
        /// </summary>
        /// <param name="lesJoueur"></param>
        public void ResetTour(Joueur[] lesJoueur)
        {
            
            for (int i=0;i<lesJoueur.Length;i++)
            {
                lesJoueur[i].ResetMain();
            }
            for(int i=0;i<carteCommune.Length;i++)
            {
               carteCommune[i].retourner(false);
            }
            paquet.Brasser();
        }
        public void AugmenterEtatTour()
        {
            this.etatTour++;
            ChangerEtat();
        }
        void RéinitialiserCartesCommunes()
        {
            Carte[] c = new Carte[5];
            for (int i = 0; i < 5; i++)
            {
                c[i] = paquet.GetTopCarte();
            }

            carteCommune = c;
        }

        public void SetJoueurs(Joueur[] j)
        {
            lesJoueurs = j;
        }
    }
}
