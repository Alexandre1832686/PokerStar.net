using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    public class Tour
    {
        Carte[] carteCommune;
        int etatTour=0;
        Tour( Carte[] LesCarteCommune)
        {
            carteCommune = LesCarteCommune;
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
            for(int i=0;i<lesJoueur.Length;i++)
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
        }

    }
}
