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

        public void Operation(List<Card> grid, int value)
        {

            for(int i = 0; i < grid.Count; i++)
            {
                grid[i].Reveal();
            }
        }

       
    }
}
