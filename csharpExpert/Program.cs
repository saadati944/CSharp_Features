using System;
using csharpExpert.features;

namespace csharpExpert
{
    class Program
    {
        static void Main(string[] args)
        {
            //add your features here
            IFeature[] features = new IFeature[]
            {
                new Lambda(),
                new AnonymousTypes(),
                new Delegtes()
            };
            
            Console.WriteLine("C# features");
            
            int i = 1;
            foreach (IFeature f in features)
            {
                $"\nfeature_{i}".WriteLine();
                f.ShowFeature();
            }
        }
    }

    public static class extensions
    {
        public static void WriteLine(this object obj)
        {
            Console.WriteLine(obj.ToString());            
        }
        public static void Write(this object obj)
        {
            Console.Write(obj.ToString());            
        }
    }
}