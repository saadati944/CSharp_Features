using System;
using System.Collections.Generic;
using System.Linq;

namespace csharpExpert.features
{
    public class Linq : IFeature
    {
        public void ShowFeature()
        {
            "linq".WriteLine();
            var people = SampleListGenerator();
            
            "sorting people by their years of experience:".WriteLine();
            // sorting with linq
            // foreach (var person in people.OrderBy(x=>x.LastName).ThenByDescending(x=>x.FirstName))
            foreach (var person in people.OrderBy(x=>x.Experience))
                person.WriteLine();
            
            // here our list stores objects of type Person, so the .OrderBy() 
            // and .Then() extension methods get Func<Person, TKey> as their input.
            
            // filtering with linq
            
            /*"showing people with more than 10 years of experience:".WriteLine();
            foreach (var person in people.Where(x=>x.Experience>=10))
                person.WriteLine();
            
            "showing people older than 35:".WriteLine();
            foreach (var person in people.Where(x=>(DateTime.Now - x.Birthday).Days/365 >= 35))
                person.WriteLine();*/
            
            "showing people older than 35 and more than 10 years of experience:".WriteLine();
            foreach (var person in people.Where(x=>(DateTime.Now - x.Birthday).Days/365 >= 35).Where(x=>x.Experience>=10))
                person.WriteLine();
            
            // sum
            // people.Sum(x=>x.Experience).WriteLine();
            "total years of experience of people with more than 10 years of experience: ".Write();
            people.Where(x=>x.Experience>=10).Sum(x=>x.Experience).WriteLine(); 
            
            // The Where() clause gets Func<Person, bool> as input.
        }

        private List<Person> SampleListGenerator()
        {
            var people = new List<Person>();
            people.Add(new Person { FirstName = "Karlene", LastName = "Corey    ", Experience = 6, Birthday = new DateTime(1970, 08, 12)});
            people.Add(new Person { FirstName = "Floretta", LastName = "Nat Lovell", Experience = 17, Birthday = new DateTime(1972, 09, 20)});
            people.Add(new Person { FirstName = "Quintus", LastName = "Georgius", Experience = 29, Birthday = new DateTime(1985, 08, 27)});
            people.Add(new Person { FirstName = "Thracius", LastName = "Otho    ", Experience = 8, Birthday = new DateTime(1993, 01, 19)});
            people.Add(new Person { FirstName = "Octavius", LastName = "Valerius", Experience = 3, Birthday = new DateTime(1996, 02, 12)});
            people.Add(new Person { FirstName = "Diadumenianus", LastName = "Damianos", Experience = 40, Birthday = new DateTime(1960, 11, 19)});
            return people;
        }
        private class Person
        {
            public string FirstName { get; set; }
            
            public string LastName { get; set; }
            public int Experience { get; set; }
            public DateTime Birthday { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName}\t\t@ {Birthday.ToShortDateString()}\texp:{Experience}";
            }
        }
    }
    
}