﻿using System;
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
        Random rnd = new Random();
        public MainJoueur()
        {
            for(int i=0;i<laMain.Length;i++)
            {
                laMain[i] = paquet.GetTopCarte();
            }
          
        }
        public int Comparer(MainJoueur lautreMAin)
        {
          
            force = rnd.Next(0, 1000);
            return force;
        }
        public void CalculerForce()
        {
            
               force= rnd.Next(0,1000);
        }
    }
   
}
