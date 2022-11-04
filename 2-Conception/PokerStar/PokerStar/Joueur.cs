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
        MainJoueur main;
        public int nbActionDansTour;

        //Constructeur de Joueur
        public Joueur(string nom, string pseudo){
            nbActionDansTour = 0;
            this.nom = nom;
            this.pseudo = pseudo;
            argent = 300;
            actif = false;
            ResetMain();
            }

        /// <summary>
        /// s'occupe de miser et de calculer la somme total que je joueur à miser 
        /// </summary>
        /// <param name="montant"></param>
        /// <returns></returns>
        private void Miser(int montant, int montantMinimum)
        {
            
            
            

            //public void Miser(int montant, int montantMinimum)
            //{

            bool verif = false;
            int reponse;

            //si le montant que le joueur veux miser est supérieur à son montant total lui offre l'optin de all-in ce qu'il lui reste
            //et si c'est correct 
            if (montant >= argent)
            {
                allIn(montantMinimum);
            }
            else if (montant < montantMinimum)
            {
                Console.WriteLine("mise invalide, pour que la mise soit valide miser le double de la somme déja miser (minimum "+montantMinimum+")");
                do
                {
                    Console.WriteLine("Voulez-vous : ");
                    Console.WriteLine("1- miser une autre somme ");
                    Console.WriteLine("2- Vous couchez ");
                    verif = int.TryParse(Console.ReadLine(), out reponse);
                } while (verif == false && reponse == 1 || reponse == 2);

                if (reponse == 1)
                {
                    raise(montantMinimum / 2);
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Voulez-vous : ");
                        Console.WriteLine("1- miser une plus petite somme ");
                        Console.WriteLine("2- Vous couchez ");
                        verif = int.TryParse(Console.ReadLine(), out reponse);
                    } while (verif == false && reponse == 1 || reponse == 2);

                    if (reponse == 1)
                    {
                        do
                        {
                            Console.WriteLine("Combien voulez-vous miser (reste " + argent + "$)");
                            verif = int.TryParse(Console.ReadLine(), out reponse);
                        } while (verif == false && reponse > 0);

                    }
                    else
                    {
                        Coucher();
                        
                    }
                }
            }
            else
            {
                argent -= montant;
                bet += montant;
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
            actif= true;
            main = new MainJoueur();

        }

        public string GetNom()
        {
            return nom;
        }

        public int GetBet()
        {
            return bet;
        }

        public void ResetBet()
        {
             bet = 0;
        }

        public int GetArgent()
        {
            return argent;
        }


        public MainJoueur GetMain()
        {
            return main;
        }

        public bool GetEtat()
        {
            return actif;
        }

        public void raise(int montantBase)
        {
            bool verif = false;
            int mise;
            do {
                Console.WriteLine("Combien voulez-vous miser (reste (" + argent + "$) minimum (" + (2 * montantBase) + "$)): ");
                verif = Int32.TryParse(Console.ReadLine(),out mise);
            } while(verif == false);
           
            Miser(mise,(2*montantBase));
        }

        public void call(int montantBase)
        {
            bool verif = false;
            string reponse;
            if (argent <= montantBase)
            {
                allIn(montantBase);
            }
            else
            {
                Miser(montantBase, montantBase);
            }

            
        }
        private void allIn(int montantMinimum)
        {
            bool verif;
            int reponse;
            do
            {
                Console.WriteLine("All in de " + argent + "?");
                Console.WriteLine("1- Oui");
                Console.WriteLine("2- Non");
                verif = int.TryParse(Console.ReadLine(), out reponse);
            } while (verif == false && reponse > 3 || reponse < 0);

            if (reponse == 1)
            {
                
                bet += argent;
                argent = 0;
            }

            else
            {
                do
                {
                    Console.WriteLine("Voulez-vous : ");
                    Console.WriteLine("1- miser une autre somme ");
                    Console.WriteLine("2- Vous couchez ");
                    verif = int.TryParse(Console.ReadLine(), out reponse);
                } while (verif == false && reponse == 1 || reponse == 2);

                if (reponse == 1)
                {
                    raise(montantMinimum / 2);

                }

                else
                {
                    Coucher();
                }
            }
        }

        public void AddArgent(int montant)
        {
            argent += montant;
        }
    }
}
