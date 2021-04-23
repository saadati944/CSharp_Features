using System;

namespace csharpExpert.features
{
    public class Funcs : IFeature
    {
        public void ShowFeature()
        {
            "funcs".WriteLine();
            
            // the last type is the return type
            // and others are input parameters.
            Func<int, int, string> add = (a, b) => (a+b).ToString();
            "12 + 32 = ".Write();
            add(12, 32).WriteLine();
        }
    }
}