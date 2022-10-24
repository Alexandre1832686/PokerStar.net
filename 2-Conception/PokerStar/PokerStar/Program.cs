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

            for (int i = 0; i < 10; i++)
            {
                Carte macarte = monPaquet.GetTopCarte();
                Console.WriteLine(macarte.valeur + " " + macarte.couleur);
            }

            Console.ReadLine();

        }
    }
}
