using System.Collections.Generic;

namespace Kentro
{

    public class PSwap : IPowerUp
    {
        public PowerupEnum id = PowerupEnum.Swap;
        private int probability = 6;
        public int getProbability()
        {
            return probability;
        }

        public PowerupEnum getType()
        {
            return id;
        }

        public void Operation(List<Card> grid, int value)
        {
            int card1 = grid[0].value;
            int card2 = grid[1].value;

            grid[0].ChangeNumber(card2);

            grid[1].ChangeNumber(card1);

        }

        //public void Operation(Player player, List<Card> grid,
        //    params object[] arguments)
        //{
        //    int temp;
        //    Card card1 = (Card)arguments[0];
        //    Card card2 = (Card)arguments[1];

        //    temp = card1.value;
        //    card1.value = card2.value;
        //    card2.value = temp;
        //}
    }
}