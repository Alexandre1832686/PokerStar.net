using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    public static class paquet
    {
        //liste de 52 carte représentant le paquet
       static List<Carte> paquetDeCarte = new List<Carte>();

        /// <summary>
        /// Echange l'ordre de tout les cartes en les interchangant.
        /// </summary>
        public static void Brasser()
        {
            Random rand = new Random();
            paquet.InstantierPaquet();
            //passe sur tout les position de la liste de carte et l'échange avec une carte 
            for (int n = paquetDeCarte.Count - 1; n > 0; --n)
            {
                int k = rand.Next(n + 1);
                Carte temp = paquetDeCarte[n];
                paquetDeCarte[n] = paquetDeCarte[k];
                paquetDeCarte[k] = temp;
            }
        }

        /// <summary>
        /// Crée des cartes et les mets dans le paquet en ordre
        /// </summary>
        /// <returns></returns>
        public static List<Carte> InstantierPaquet()
        {
            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.Coeur, i +1);
                paquetDeCarte.Add(carte);
            }
            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.Pique, i + 1);
                paquetDeCarte.Add(carte);
            }
            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.treffle, i + 1);
                paquetDeCarte.Add(carte);
            }
            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.Carreau, i + 1);
                paquetDeCarte.Add(carte);
            }
            
            return paquetDeCarte;
        }

        /// <summary>
        /// Premd la premiere carte sur laquel il tombe qui n'est pas null, il la remplace par un null et renvoie la carte.
        /// </summary>
        /// <returns></returns>
        public static Carte GetTopCarte()
        {
            for(int i = 51; i>=0; i--)
            {
                if(paquetDeCarte[i] != null)
                {
                    Carte maCarte = paquetDeCarte[i];
                    paquetDeCarte[i] = null;
                    return maCarte;
                }
            }
            return null;
        }
        
    }
}
