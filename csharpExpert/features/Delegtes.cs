using System;

namespace csharpExpert.features
{
    public class Delegtes : IFeature
    {
        public void ShowFeature()
        {
            "delegates".WriteLine();
            string juice = "water";
            
            DrinkAction modeOfDrinking = drinkWithSugar; 
            DoDrinking(modeOfDrinking, juice);
            // same as (with action):
            Action<string> modeOfDrinkingWithAction = drinkWithSugar; 
            DoDrinkingWithAction(modeOfDrinkingWithAction, juice);
        }

        private delegate void DrinkAction(string juice);

        private void DoDrinking(DrinkAction action, string juice)
        {
            action?.Invoke(juice);
            // same as :
            // if (action is not null)
            //     action(juice);
        }
        private void DoDrinkingWithAction(Action<string> action, string juice) => action?.Invoke($"{juice} By action");

        private void drinkWithSugar(string juice)
        {
            $"drinking {juice} with sugar".WriteLine();
        }
    }
}