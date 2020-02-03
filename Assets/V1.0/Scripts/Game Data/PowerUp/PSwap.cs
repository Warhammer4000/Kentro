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

        public void Operation(Player player1, Player player2, List<Card> grid,
            params object[] arguments)
        {
            int[] values = new int[2];
            

            for(int i=0;i<=grid.Count;++i)
            {
                for(int k = 0; k < 2; ++k)
                {
                    if (grid[i].value == (int)arguments[k])
                    {
                        values[k] = (int)arguments[k];
                    }
                } 
            }

            //a = grid[(Position)arguments[0]].value;
            //b = grid[(Position)arguments[1]].value;
            //grid[(Position)arguments[0]].value = b;
            //grid[(Position)arguments[1]].value = a;
        }
    }
}