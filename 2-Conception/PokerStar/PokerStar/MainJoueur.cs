using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    internal class MainJoueur
    {
        Carte[] laMain = new Carte[2];
        int force;
            
        public MainJoueur(Carte[] carteDonner)
        {
            laMain = carteDonner;
        }
        public int Comparer(MainJoueur lautreMAin)
        {
            return 0;
        }
        public void CalculerForce()
        {
               
        }
    }
   
}
