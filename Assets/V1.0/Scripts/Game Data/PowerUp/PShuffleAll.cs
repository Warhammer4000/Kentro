using System;
using System.Collections.Generic;

namespace Kentro
{
    
     public class PShuffleAll:IPowerUp
    {
        public PowerupEnum id = PowerupEnum.ShuffleAll;
        private int probability = 7;
        public int getProbability()
        {
            return probability;
        }

        public PowerupEnum getType()
        {
            return id;
        }

        public void Operation(Player player1, Player player2,
            List<Card> grid, params object[] arguments)
        {
            for(int i = 0; i < grid.Count; i++)
            {
                if(grid[i].Pawn == null)
                    grid[i].flipped = false;
            }
            
        }

        
    }
}
