using System;

namespace csharpExpert.features
{
    public class FuncsAndActions : IFeature
    {
        public void ShowFeature()
        {
            "funcs".WriteLine();
            
            // the last type is the return type
            // and others are input parameters.
            Func<int, int, string> addFunc = (a, b) => (a+b).ToString();
            "12 + 32 = ".Write();
            addFunc(12, 32).WriteLine();

            Action<int, int> addAction = (a, b) => (a + b).WriteLine();
            "32 + 43 = ".Write();
            addAction(32, 43);
            
            // the difference between action and func is, actions doesn't return anything
            // but funcs have a return value.
        }
    }
}