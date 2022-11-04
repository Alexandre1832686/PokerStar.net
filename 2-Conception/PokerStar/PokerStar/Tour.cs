using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
