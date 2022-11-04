using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    public class Tour
    {
        public static bool GameisOver; 
        public Carte[] carteCommune = new Carte[5];
        int etatTour=0;
        Joueur[] lesJoueurs;
        public Tour()
        {
            GameisOver = false;
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
            else if(etatTour==2)
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
                foreach(Joueur joueur in lesJoueurs)
                {
                    if(joueur.GetEtat())
                    {
                        Carte[] ToutLesCartes = new Carte[7];
                        for(int i =0;i<5;i++)
                        {
                            ToutLesCartes[i] = carteCommune[i];
                        }
                        ToutLesCartes[5] = joueur.GetMain().GetCarte(0);
                        ToutLesCartes[6] = joueur.GetMain().GetCarte(1);
                        
                        MainJoueur.CalculerForce(DemanderCartesAPrendre(joueur, ToutLesCartes));
                        
                    }
                }
                etatTour = 0;
                ResetTour(lesJoueurs);
                RéinitialiserCartesCommunes();



                //***********************************************      ICI POUR LEVALUATIION DU GAGNANT        *****************************************************//
                EndTour(IsWinner(lesJoueurs));
            }

            for (int i = position; i < inbCarteAtourner+position; i++)
            {
                carteCommune[i].retourner(true);
            }
        }
        private Joueur IsWinner(Joueur[]lesJoueurs)
        {
            Joueur gagnant = lesJoueurs[0];
            Carte[][] mainsFinals = new Carte[lesJoueurs.Length][];


            //Attribuer des vvaleurs à mains final
            


            int[][] valeurForce = new int[4][];

            for (int i = 0; i < mainsFinals.Length;i++)
            {
                valeurForce[i] = MainJoueur.CalculerForce(mainsFinals[i]);
            }

            //comparer les valeurs force pis les si le plus fort ses valeurForce[2][], gagnant = lesjoeuurs[2]
           for(int i=0;i<valeurForce.Length;i++)
            {
                for(int j = 0; j < valeurForce[i].Length;j++)
                {

                }
            }
            return gagnant; 
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
            foreach(Joueur j in lesJoueurs)
            {
                j.nbActionDansTour = 0;
            }

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

        void EndTour(Joueur winer)
        {
            
            int total = 0;
            foreach(Joueur j in lesJoueurs)
            {
                total += j.GetBet();
                j.ResetBet();
            }
            winer.AddArgent(total);
            foreach (Joueur j in lesJoueurs)
            {
                if(j.GetArgent() == 0)
                {
                    GameisOver = true;
                }
            }
        }

        Carte[] DemanderCartesAPrendre(Joueur j, Carte[] cartes)
        {
            Carte[] renvoie = new Carte[5];
            bool verifFinal = false;
            do
            {
                Console.WriteLine("Quel Carte voulez vous prendre, en choisir 5 : ");
                Console.WriteLine("(ecrire les chiffres devant les cartes sans espaces)");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(i + 1 + " ");
                    AfficherUneCarte(carteCommune[i].valeur, carteCommune[i].couleur);
                }
                for (int i = 0; i < 2; i++)
                {
                    Console.Write(i + 6 + " ");
                    AfficherUneCarte(j.GetMain().GetCarte(i).valeur, j.GetMain().GetCarte(i).couleur);
                }

                string rep = Console.ReadLine();
                int nb1 = 0, nb2 = 0, nb3 = 0, nb4 = 0, nb5 = 0;

                bool verif = int.TryParse(rep, out int repInt);

                if (verif)
                {
                    if ((float)repInt / 10000f > 1 && (float)repInt / 100000f < 1)
                    {
                        bool verif1 = int.TryParse(rep[0].ToString(), out nb1);
                        bool verif2 = int.TryParse(rep[1].ToString(), out nb2);
                        bool verif3 = int.TryParse(rep[2].ToString(), out nb3);
                        bool verif4 = int.TryParse(rep[3].ToString(), out nb4);
                        bool verif5 = int.TryParse(rep[4].ToString(), out nb5);

                        if (verif1 && verif2 && verif3 && verif4 && verif5)
                        {
                            renvoie = new Carte[5];
                            renvoie[0] = cartes[nb1];
                            renvoie[1] = cartes[nb2];
                            renvoie[2] = cartes[nb3];
                            renvoie[3] = cartes[nb4];
                            renvoie[4] = cartes[nb5];
                            return renvoie;
                        }
                    }
                }
               
            } while (renvoie[0] != null);
            return renvoie;
        }
        void AfficherUneCarte(int valeur, Couleur couleur)
        {
            Console.WriteLine("   ---");
            Console.WriteLine("   |"+partie.ConvertirCouleur(couleur)+"|");
            Console.WriteLine("   |" + partie.ConvertirValeur(valeur) + "|");
            Console.WriteLine("   ---");
            Console.WriteLine("---");
        }
    }
}
