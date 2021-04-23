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
                new Delegtes(),
                new FuncsAndActions(),
                new Goto()
            };
            
            Console.WriteLine("C# features");
            
            int i = 1;
            foreach (IFeature f in features)
            {
                $"\nfeature_{i}".WriteLine();
                f.ShowFeature();
                i++;
            }
        }
    }

    // this is also a c# feature
    // the extension methods
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