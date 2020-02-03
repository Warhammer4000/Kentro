using System.Collections.Generic;

namespace Kentro
{

    public class PSwap:IPowerUp
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

        public void Operation(Player player, List<Card> grid,
            params object[] arguments)
        {
            int temp;
            Card card1 = (Card)arguments[0];
            Card card2 = (Card)arguments[1];

            temp = card1.value;
            card1.value = card2.value;
            card2.value = temp;
        }
    }
}