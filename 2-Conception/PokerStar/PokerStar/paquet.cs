using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    internal class paquet
    {
        public Carte[] paquetDeCarte = new Carte[52];




        public Carte[] RammasserUnPaquetBrasser()
        {
            Carte[] paquet = new Carte[52]; 
            return paquet;
        }

        public Carte[] InstantierPaquetTrier()
        {
            List<Carte> paquet = new List<Carte>();

            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.Coeur, i);
                paquet.Add(carte);
            }
            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.Pique, i);
                paquet.Add(carte);
            }
            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.treffle, i);
                paquet.Add(carte);
            }
            for (int i = 0; i < 13; i++)
            {
                Carte carte = new Carte(Couleur.Carreau, i);
                paquet.Add(carte);
            }

            return paquet.ToArray();
        }
    }
}
