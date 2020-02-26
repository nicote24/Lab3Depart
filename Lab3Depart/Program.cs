using System;
using System.Collections.Generic;

namespace Lab3Depart
{
    public class Program
    {
        static void Main(string[] args)
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
                new Personne() { Nom = "Bob", Genre = 'M', Age = 12,     FruitsAimes = new List<Fruit>() { fruits[4], fruits[5], fruits[6], fruits[7], fruits[8] } },
                new Personne() { Nom = "Charlie", Genre = 'M', Age = 31, FruitsAimes = new List<Fruit>() { fruits[0], fruits[1], fruits[4], fruits[11] } },
                new Personne() { Nom = "Diane", Genre = 'F', Age = 45,   FruitsAimes = new List<Fruit>() { fruits[2], fruits[4] } },
                new Personne() { Nom = "Eve", Genre = 'F', Age = 4,      FruitsAimes = new List<Fruit>() { } },
            };

            LinqExo le = new LinqExo();

            Console.WriteLine("Les fruits qui contiennent la lettre A sont : ");
            var reponse = le.ContientA(fruits);
            Console.WriteLine ($"{string.Join(separator: ", ", values: reponse)}");


            Console.WriteLine("Les personne qui sont mineurs sont : ");
            var reponse2 = le.Enfants(personnes);
            Console.WriteLine($"{string.Join(separator: ", ", values: reponse2)}");

            Console.WriteLine("La personne la plus vieille est : ");
            var reponse3 = le.LaPlusVieille(personnes);
            Console.WriteLine($"{string.Join(separator: ", ", values: reponse3)}");

            Console.WriteLine("les fruits le plus populaires  : ");
            var reponse4 = le.PlusPopulaire(personnes);
            Console.WriteLine($"{string.Join(separator: ", ", values: reponse4)}");

            Console.WriteLine("categorie par genre  : ");
            le.ParGenre(personnes);

            Console.WriteLine("la personne aimant le plus de fruit  : ");
            var reponse5 = le.PlusDefruit(personnes);
            Console.WriteLine($"{string.Join(separator: ", ", values: reponse5)}");

            Console.Read();

        }
    }
}
