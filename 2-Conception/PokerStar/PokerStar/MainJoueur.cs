using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    public class MainJoueur
    {
        Carte[] laMain = new Carte[2];
        int force;
        Random rnd = new Random();
        public MainJoueur()
        {
            for (int i = 0; i < laMain.Length; i++)
            {
                laMain[i] = paquet.GetTopCarte();
            }
        }
        public int Comparer(MainJoueur lautreMAin)
        {

            //force = rnd.Next(0, 1000);
            return force;
        }
        /// <summary>
        /// Calcul la plus grande puissance de la main puis retourne un tableau de int étant la puissance des carte utilisée
        /// https://www.cardplayer.com/rules-of-poker/hand-rankings
        /// </summary>
        /// <param name="jeuxCarte"></param>
        /// <returns></returns>
        public int[] CalculerForce(Carte[] carteCommune)
        {
            int[] valeurForce = new int[6];
            List<int> listeDeValeur = new List<int>();
            /*vérification en ordre de puissance 1(royal flush)[...],10(highCard)*/



            //pour chaque carte dans les cartesCommune insère la valeur(int) dans la listsDeValeur
            for (int i = 0; i < carteCommune.Length; i++)
            {
                listeDeValeur.Add(carteCommune[i].valeur);
            }
            listeDeValeur.Sort();


            /*Pair de carte 9  et double pair:8 et triple7 si il y'a une paire ou plus, alors  indique dans le tableau de int
            le rank du combo ainsi que la valeur(int) des carte dans le tableau en commancant par ceux utilisé dans le 
           jeux puis en ordre de puissance */
            int nbCarteValeurIdentique = 0;
            for (int j = 0, i = 0; i < listeDeValeur.Count - 1; i++, j++)
            {
                if (listeDeValeur[i] == listeDeValeur[j + 1])
                {
                    nbCarteValeurIdentique++;
                }
            }
            if (nbCarteValeurIdentique == 3)//une four of a kind
            {
                inséréValeurDansTableau(ref valeurForce, 4, listeDeValeur);
            }
            else if (nbCarteValeurIdentique == 3)//un tripe
            {
                inséréValeurDansTableau(ref valeurForce, 7, listeDeValeur);
            }
            else if (nbCarteValeurIdentique == 2)//double pair
            {
                inséréValeurDansTableau(ref valeurForce, 8, listeDeValeur);
            }
            else if (nbCarteValeurIdentique == 1)//une paire 
            {
                inséréValeurDansTableau(ref valeurForce, 9, listeDeValeur);
            }
            ///////////////////////////////////////////////////////////////
            /*flush 5 si toute les carte ne sont pas une suite et qu'ils ont toute la même sorte, 
             alros c'est une flush */
            return valeurForce;
        }

        private void VérifSiTriple()
        {
        }

        /// <summary>
        /// sert à inséré des valeurs dans le tableau
        /// </summary>
        /// <param name="valeurForce"></param>
        /// <param name="powerRank"></param>
        /// <param name="listeDeValeur"></param>
        private void inséréValeurDansTableau(ref int[] valeurForce, int powerRank, List<int> listeDeValeur)
        {
            valeurForce[0] = powerRank;
            for (int i = 1; i < valeurForce.Length; i++)
            {
                valeurForce[i] = listeDeValeur[i];
            }
        }
        public Carte GetCarte(int ind)
        {
            Carte carte = laMain[0];
            if (ind < laMain.Length && ind >=0)
            {
                carte = laMain[ind];
            }
           
            return carte;
        }
    }
   
}
