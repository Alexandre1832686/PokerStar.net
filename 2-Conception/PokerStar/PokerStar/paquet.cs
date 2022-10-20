﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    public class paquet
    {
        Carte[] paquetDeCarte = new Carte[52];

        public paquet()
        {
           paquetDeCarte = InstantierPaquet();
        }


        public void Brasser()
        {
            Random rand = new Random();

            for (int n = paquetDeCarte.Length - 1; n > 0; --n)
            {
                int k = rand.Next(n + 1);
                Carte temp = paquetDeCarte[n];
                paquetDeCarte[n] = paquetDeCarte[k];
                paquetDeCarte[k] = temp;
            }
        }

        public Carte[] InstantierPaquet()
        {
            List<Carte> paquet = new List<Carte>();

            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.Coeur, i +1);
                paquet.Add(carte);
            }
            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.Pique, i + 1);
                paquet.Add(carte);
            }
            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.treffle, i + 1);
                paquet.Add(carte);
            }
            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.Carreau, i + 1);
                paquet.Add(carte);
            }

            return paquet.ToArray();
        }

        public Carte GetTopCarte()
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
