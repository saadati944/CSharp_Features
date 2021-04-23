using System.Collections.Generic;

namespace csharpExpert.features
{
    public class Goto : IFeature
    {
        public void ShowFeature()
        {
            "goto feature".WriteLine();
            Stack<char> hello = new Stack<char>(new []{'h', 'e', 'l', 'l', 'o'});
            
            "extracting the stack elements with while : ".Write();
            char c;
            while (hello.TryPop(out c))
            {
                c.Write();
            }
            
            "\nextracting the elements with goto : ".Write();
            
            // we popped all elements so we have to reproduce them again
            hello = new Stack<char>(new []{'h', 'e', 'l', 'l', 'o'});
            
            myLabel:
            if (hello.TryPop(out c))
            {
                c.Write();
                goto myLabel;
            }
            
            "\nwe are using the stack to store our elements it is why we get them reversed.".WriteLine();
        }
    }
}