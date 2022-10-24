using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            paquet monPaquet = new paquet();
            monPaquet.Brasser();

            Joueur[] joueurs = new Joueur[4];

            for(int i = 0; i < 4; i++)
            {
                Joueur j = new Joueur("alex"+rand.Next(0,200), "al");
                joueurs[i] = j;
            }
            
            partie p = new partie(joueurs);

            p.AfficherJeu();
            test.Miser(200);
            test.Miser(500);

            Console.WriteLine(test.getBet());

            Console.ReadKey();


        }
    }
}
