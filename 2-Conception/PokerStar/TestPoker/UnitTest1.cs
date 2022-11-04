using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PokerStar;
using System.Linq;

namespace TestPoker
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFlush()
        {
            int[] force;
            Carte deux = new Carte(Couleur.Coeur,2);
            Carte trois = new Carte(Couleur.Coeur, 3);
            Carte quatre = new Carte(Couleur.Coeur, 4);
            Carte cinq = new Carte(Couleur.Coeur, 9);
            Carte six = new Carte(Couleur.Coeur, 7);
            Carte[] flush = new Carte[] { deux, trois, quatre, cinq, six };

            force = MainJoueur.CalculerForce(flush);

            //verifi si bien ordonner et si la force corespond
            if (force[5] != 5 && force[4] != 9)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestStraight()
        {
            int[] force;
            Carte deux = new Carte(Couleur.Coeur, 2);
            Carte trois = new Carte(Couleur.Coeur, 3);
            Carte quatre = new Carte(Couleur.treffle, 4);
            Carte cinq = new Carte(Couleur.Coeur, 4);
            Carte six = new Carte(Couleur.Pique, 5);
            Carte[] flush = new Carte[] { deux, trois, quatre, cinq, six };

            force = MainJoueur.CalculerForce(flush);

            //verifi si bien ordonner et si la force corespond
            if (force[5] != 6 && force[4] != 5)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestFullHouse()
        {
            int[] force;
            Carte deux = new Carte(Couleur.Coeur, 2);
            Carte trois = new Carte(Couleur.Coeur, 2);
            Carte quatre = new Carte(Couleur.treffle, 2);
            Carte cinq = new Carte(Couleur.Coeur, 3);
            Carte six = new Carte(Couleur.Pique, 3);
            Carte[] flush = new Carte[] { deux, trois, quatre, cinq, six };

            force = MainJoueur.CalculerForce(flush);

            //verifi si bien ordonner et si la force corespond
            if (force[5] != 4 && force[4] != 3)
            {
                Assert.Fail();
            }
        }
    }
}
