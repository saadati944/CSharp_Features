using System;
using System.Linq;

namespace csharpExpert.features
{
    public class Lambda : IFeature
    {
        public void ShowFeature()
        {
            "lambda".WriteLine();
            "numbers : ".Write();
            int[] numbers = new[] {1, 2, 3, 4, 5};
            string.Join(", ", numbers).WriteLine();
            
            "squares : ".Write();
            // first mod :
            // var squareNumbers = numbers.Select(x => x * x);
            
            // second mod :
            Func<int, int> square = x => x * x;
            // for more than one parameter, cover input parameters in parentheses :
            // Func<int, int, int> square = (x, y) => x * y;
            // in a lambda you can even specify the input parameters type like this :
            // Func<int, int> square = (int x) => x * x;
            var squareNumbers = numbers.Select(square);
            
            string.Join(", ", squareNumbers).WriteLine();
            
            
            "lambda with no parameters :".WriteLine();
            "number is :".Write();
            GetNumber getn = () => 10;
            // this part [() => 10] is a lambda
            // and the getn is a delegate
            // delegate is something like a container that we put our functions into.
            getn().WriteLine();
        }
        private delegate int GetNumber();
    }
}