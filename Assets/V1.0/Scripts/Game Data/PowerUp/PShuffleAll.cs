using System;
using System.Collections.Generic;

namespace Kentro
{
    
     public class PShuffleAll:IPowerUp
    {
        public PowerupEnum id = PowerupEnum.ShuffleAll;
        private int probability = 5;
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
            for (int i = 0; i < grid.Count; i++)
            {
                if (grid[i].Pawn == null)
                    grid[i].Hide();
            }
        }

        //public void Operation(Player player,
        //    List<Card> grid, params object[] arguments)
        //{
        //    for(int i = 0; i < grid.Count; i++)
        //    {
        //        if(grid[i].Pawn == null)
        //            grid[i].Hide();
        //    }

        //}  
    }
}
