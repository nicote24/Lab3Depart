using Lab3Depart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Lab3Tests
{
    [TestClass]
    public class UnitTest1
    {
        IEnumerable<Fruit> fruits;
        LinqExo le;

        [TestInitialize]
        public void StartUp()
        {
            le = new LinqExo();

            fruits = new List<Fruit>()
            {
                new Fruit() { Nom = "Abricot"}, new Fruit() { Nom = "Banane"}, new Fruit() { Nom = "Cerise"}, new Fruit() { Nom = "Datte"},
            };
        }
        
        [TestMethod]
        public void TestContientA()
        {
            var reponse = le.ContientA(fruits);
            Assert.AreEqual(reponse.Count(), 3);
            Assert.IsTrue(reponse.Contains(fruits.ElementAt(0)));
            Assert.IsTrue(reponse.Contains(fruits.ElementAt(1)));
            Assert.IsTrue(reponse.Contains(fruits.ElementAt(3)));
        }

        [TestMethod]
        public void TestContientAVide()
        {
            Assert.AreEqual(le.ContientA(new List<Fruit>(){ new Fruit() { Nom = "Cerise" }}).Count(), 0);
            Assert.AreEqual(le.ContientA(new List<Fruit>()).Count(), 0);
        }

        [TestMethod]
        public void TestPlusde18ans()
        {
            Assert.AreEqual(le.EnfantsR(new List<Personne>() { new Personne() { Nom = "Nico",Age=19,Genre='M' } }).Count(),0);
        }

        [TestMethod]
        public void Test2PlusVieux()
        {
            Assert.AreNotEqual(le.LaPlusVieille(new List<Personne>() { new Personne() { Nom = "Nico", Age = 19, Genre = 'M' },new Personne() { Nom = "Marie", Age = 12, Genre = 'F' } }).Age,12);
        }

        [TestMethod]
        public void testBonPopulaire()
        {
            var fruits = new List<Fruit>()
            {
                new Fruit() { Nom = "Abricot"},   new Fruit() { Nom = "Banane"},    new Fruit() { Nom = "Cerise"},  new Fruit() { Nom = "Datte"},
                new Fruit() { Nom = "Framboise"}, new Fruit() { Nom = "Grenade"},   new Fruit() { Nom = "Kiwi"},    new Fruit() { Nom = "Lime"},
                new Fruit() { Nom = "Mangue"},    new Fruit() { Nom = "Nectarine"}, new Fruit() { Nom = "Olive"},   new Fruit() { Nom = "Pomme"}
            };

            var personnes = new List<Personne>()
            {
                new Personne() { Nom = "Alice", Genre = 'F', Age = 22,   FruitsAimes = new List<Fruit>() { fruits[0], fruits[1], fruits[10] } },
                new Personne() { Nom = "Bob", Genre = 'M', Age = 12,     FruitsAimes = new List<Fruit>() { fruits[4], fruits[0], fruits[6], fruits[7], fruits[8] } },
                new Personne() { Nom = "Charlie", Genre = 'M', Age = 31, FruitsAimes = new List<Fruit>() { fruits[0], fruits[1], fruits[4], fruits[11] } },
                new Personne() { Nom = "Diane", Genre = 'F', Age = 45,   FruitsAimes = new List<Fruit>() { fruits[2], fruits[0] } },
                new Personne() { Nom = "Eve", Genre = 'F', Age = 4,      FruitsAimes = new List<Fruit>() { } },
            };
            Assert.IsTrue(le.PlusPopulaire(personnes).First().Nom=="Abricot");
        }
    }
}
