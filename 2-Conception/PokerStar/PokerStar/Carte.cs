using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    public class Carte
    {
        //variable
        public bool visible;
        public Couleur couleur;
        public int valeur;

        //constructeur
        public Carte(Couleur couleur_p, int valeur_p){
            couleur = couleur_p;
            valeur = valeur_p;
            visible = false;
        }

        /// <summary>
        /// Change la valeur de la variable visible en fonction du paramètre
        /// </summary>
        /// <param name="RendreVisible"></param>
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
    }
}
