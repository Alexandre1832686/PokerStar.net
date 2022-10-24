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
        Tour()
        {
            
        }
        /// <summary>
        /// 
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
                carteCommune[i].retourner();
            }
        }
        public void ResetTour()
        {
            // carteCommune= Paquet.Distribuer(t: Tour)
        }
        public void AugmenterEtatTour()
        {etatTour++;}

    }
}
