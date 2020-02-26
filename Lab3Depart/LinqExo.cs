using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3Depart
{
    public class LinqExo
    {
        public IEnumerable<Fruit> ContientA(IEnumerable<Fruit> fruits)
        {
            return fruits.Where(f => f.Nom.ToUpper().Contains("A"));
        }

        public IEnumerable<Personne> Enfants(IEnumerable<Personne> personnes)
        {
            return personnes.Where(f => f.Age<18);
        }

        public IEnumerable<Personne> EnfantsR(IEnumerable<Personne> personnes)
        {
            return from p in personnes
                   where p.Age < 18
                   select p;

        }
        public Personne LaPlusVieille(IEnumerable<Personne> personnes)
        {
            return personnes.Where(p => p.Age == personnes.Max(m => m.Age)).Max();
        }
        public Personne LaPlusVieilleR(IEnumerable<Personne> personnes)
        {
            var query= from p in personnes
                   where p.Age == personnes.Max(e => e.Age)
                   select p;

            return query.FirstOrDefault();

        }

        public IEnumerable<Fruit> PlusPopulaire(IEnumerable<Personne> personnes)
        {
            var fruits = personnes.SelectMany(p => p.FruitsAimes).GroupBy(f=>f.Nom);
            return fruits.OrderByDescending(f => f.Count()).Select(o => o.First());
        }



        public IEnumerable<Fruit> PlusPopulaireR(IEnumerable<Personne> personnes)
        {
            var query = from p in personnes
                        from f in p.FruitsAimes
                        group f by f.Nom into g
                        orderby g.Count() descending
                        select g.First();
            return query;

            
        }

        public void ParGenre(IEnumerable<Personne> personnes)
        {
           var genres = from p in personnes
                     group p by p.Genre into g
                     select new { G = g.Key, max = g.Max(p=>p.Age), min = g.Min(p=>p.Age), count=g.Count() };

            foreach (var g in genres)
            { 

                Console.WriteLine("genre de la personne : "+g.G );
                Console.WriteLine("Nb de personne de ce genre : " +g.count );
                Console.WriteLine("L'age dun plus vieux : " + g.max);
                Console.WriteLine("L'age dun plus vieux : " + g.min);

            }


        }

        public IEnumerable<Personne> PlusDefruit(IEnumerable<Personne> personnes)
        {
            var query = personnes.Where(p => p.FruitsAimes.Count == personnes.Max(g => g.FruitsAimes.Count()));

            return query;
        }

    }
}
