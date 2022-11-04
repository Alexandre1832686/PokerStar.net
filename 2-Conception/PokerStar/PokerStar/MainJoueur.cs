using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public static int[] CalculerForce(Carte[] carteCommune)
        {
            int[] valeurForce = new int[6];
            List<int> listeDeValeur = new List<int>();
            List<int> listPair = new List<int>();
            List<int> listNonPair = new List<int>();
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
                    listPair.Add(listeDeValeur[i]);
                    listPair.Sort();
                    nbCarteValeurIdentique++;
                }
                else// ajouter les carte non paire pour les rajouter a listpair a la fin 
                {
                    listNonPair.Add(listeDeValeur[i]);
                    listNonPair.Sort();
                }
            }
            
            //si le nb de carte identique est plus grand que 0 
            if (nbCarteValeurIdentique > 0)
            {
                if (nbCarteValeurIdentique == 3)//une four of a kind ou full house
                {
                    return valeurForce = VerifSiFourFullHouse(listPair, listeDeValeur,listNonPair);
                }
                else if (nbCarteValeurIdentique == 2)//double paire ou un triple
                {
                    return valeurForce = VerifSiDouleOuTriplePair(listPair, listeDeValeur, listNonPair);
                }
                else if (nbCarteValeurIdentique == 1)//une paire 
                {
                    return valeurForce = InséréValeurDansTableau(9, listeDeValeur);
                }
            }
            else
            {
               //si c'est une suite alors commence vérification des suite pour straight /flush royal flush[...]
                if(UneSuite(listeDeValeur))
                {
                    //straight flush ou royal flush
                    if(MemeSorte(carteCommune))
                    {
                        if (carteCommune[0].valeur==10)
                        { return valeurForce = InséréValeurDansTableau(1, listeDeValeur); }
                        return valeurForce=InséréValeurDansTableau(2,listeDeValeur);
                    }
                    //straight
                    return valeurForce = InséréValeurDansTableau(6, listeDeValeur);
                }
                //si c'est une suite donc c'est un flush
                if(MemeSorte(carteCommune))
                {
                    return valeurForce= InséréValeurDansTableau(9,listeDeValeur);
                }
            }
            //high card
            return valeurForce = InséréValeurDansTableau(10, listeDeValeur);
        }
        private static bool MemeSorte(Carte[]carteCommunes)
        {
            bool verif = false;
            if (carteCommunes[0].couleur == carteCommunes[1].couleur && carteCommunes[0].couleur == carteCommunes[2].couleur && carteCommunes[0].couleur 
                == carteCommunes[3].couleur && carteCommunes[0].couleur == carteCommunes[4].couleur )
            {
                verif = true;
                return verif;
            }
            return verif;
        }
        /// <summary>
        /// vérifie si c'est une suite
        /// </summary>
        /// <param name="listeDeValeur"></param>
        /// <returns></returns>
        private static bool UneSuite(List<int>listeDeValeur)
        {
            bool verif = false;
            if (listeDeValeur[0] == listeDeValeur[1]-1 && listeDeValeur[0] == listeDeValeur[2] - 2 && listeDeValeur[0] == listeDeValeur[3] - 3 
                && listeDeValeur[0] == listeDeValeur[4] - 4 )
            {
                verif = true;
                return verif;
            }
            else return false;
        }
        /// <summary>
        /// Vérifie si les cartes forme un full house ou un four of a kind
        /// </summary>
        /// <param name="listPair"></param>
        /// <param name="valeurForce"></param>
        /// <param name="listeDeValeur"></param>
        private static int[] VerifSiFourFullHouse(List<int> listPair, List <int> listeDeValeur, List<int> listNonPair)
        {
            //si la .count est égale a 4  c'est un four of a kind et si la valeur de point count est égale a 5 c'est une fullhouse
            if(listPair.Count==4)//four of a kind
            {
                for(int i=0;i<listNonPair.Count;i++)
                {
                    listPair.Add(listNonPair[i]);
                }
               return InséréValeurDansTableau( 3, listPair);
            }
            else //full house
            {
                for (int i = 0; i < listNonPair.Count; i++)
                {
                    listPair.Add(listNonPair[i]);
                }
                return InséréValeurDansTableau( 4, listPair);
            }
        }
        /// <summary>
        /// vérifie si c'est une double pair ou un triple
        /// </summary>
        /// <param name="listPair"></param>
        /// <param name="valeurForce"></param>
        /// <param name="listeDeValeur"></param>
        private static int [] VerifSiDouleOuTriplePair(List<int> listPair,  List<int> listeDeValeur, List<int> listNonPair)
        {
            //si la .count est égale a 4  c'est un double pair et si la valeur de point count est égale a 3 c'est un triple
            if (listPair.Count==4)//double pair
            {
                for (int i = 0; i < listNonPair.Count; i++)
                {
                    listPair.Add(listNonPair[i]);
                }
                return InséréValeurDansTableau( 8, listPair);
            }
            else //three of a kind
            {
                for (int i = 0; i < listNonPair.Count; i++)
                {
                    listPair.Add(listNonPair[i]);
                }
                return InséréValeurDansTableau(  7, listPair);
            }
        }
        /// <summary>
        /// sert à inséré des valeurs dans le tableau
        /// </summary>
        /// <param name="valeurForce"></param>
        /// <param name="powerRank"></param>
        /// <param name="listeDeValeur"></param>
        private static int[] InséréValeurDansTableau(  int powerRank, List<int> listeDeValeur)
        {
            int[] valeurForce = new int[6];
            valeurForce[0] = powerRank;
            for (int i = 1; i < valeurForce.Length; i++)
            {
                valeurForce[i] = listeDeValeur[i];
            }
            return valeurForce; 
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
