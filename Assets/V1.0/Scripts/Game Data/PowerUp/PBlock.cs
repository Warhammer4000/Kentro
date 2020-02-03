using System;
using System.Collections.Generic;

namespace Kentro
{
    public class PBlock:IPowerUp
    {
        public PowerupEnum id = PowerupEnum.Block;
        private int probability = 5;

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
            Card card = (Card) arguments[0];
            card.blocked = true;
        }

    }
}
