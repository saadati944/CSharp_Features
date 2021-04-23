namespace csharpExpert.features
{
    public class Generics : IFeature
    {
        public void ShowFeature()
        {
            "generics".WriteLine();
            new ManDrinker().Drink<Home, AppleJuice>();
            new WomanDrinker().Drink<Park, OrangeJuice>();
        }
        
        private abstract class Place {}
        private abstract class Juice {}
        
        private class Home : Place {}
        private class Park : Place {}

        private class AppleJuice : Juice
        {
            public string name = "AppleJuice";
        }
        private class OrangeJuice : Juice {}

        private class ManDrinker
        {
            public void Drink<P, J>()
                where P : Place
                where J : AppleJuice, new() // this new() makes it possible to create an
                                            // instance of this type in the method body
            {
                J juice = new J();
                $"he drinks {juice.name} in {typeof(P).Name}".WriteLine();
            }
        }

        private class WomanDrinker
        {
            public void Drink<P, J>() 
            {
                $"she drinks {typeof(J).Name} in {typeof(P).Name}".WriteLine();
            }
        }
    }
}