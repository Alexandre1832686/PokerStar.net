using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    public class Carte
    {
        bool visible { get; set; }
        public Couleur couleur;
        public int valeur;

        public Carte(Couleur couleur_p, int valeur_p){
            couleur = couleur_p;
            valeur = valeur_p;
            visible = false;
        }

        public void retourner(bool RendreVisible)
        {
            if(RendreVisible)
            {
                visible = true;
            }
            else 
            {
                visible = false;
            }
        }

        public int Comparer(Carte carte)
        {
            return carte.valeur;
        }
                
        
    }
}
