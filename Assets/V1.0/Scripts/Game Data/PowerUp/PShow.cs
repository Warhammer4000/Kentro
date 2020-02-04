using System;
using System.Collections.Generic;

namespace Kentro
{
    public class PShow:IPowerUp
    {
        public PowerupEnum id = PowerupEnum.ShowCard;
        private int probability = 4;
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
            for (int i = 0; i < arguments.Length; ++i)
            {
                Card card = (Card) arguments[i];
                if (card.flipped != true)
                {
                    card.Reveal();
                }
            }
        }

        
    }
}
