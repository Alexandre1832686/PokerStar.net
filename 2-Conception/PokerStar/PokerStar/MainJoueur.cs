﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
     public class MainJoueur
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
        public Carte GetCarte(int ind)
        {
            Carte carte = laMain[0];
            if (ind < laMain.Length && ind >=0)
            {
                carte = laMain[ind];
            }
           
            return carte;
        }
    }
   
}
