using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    internal class Carte
    {
        string sorte;
        Valeur valeur;

        Carte(string sorte_p, Valeur valeur_p){
            sorte = sorte_p;
            valeur = valeur_p;
        }

    }
}
