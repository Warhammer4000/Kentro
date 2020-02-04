using System;
using System.Collections.Generic;

namespace Kentro
{
    public class PFreeze:IPowerUp
    {
        public PowerupEnum id = PowerupEnum.Freeze;
        private int probability = 3;
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
            grid[0].Pawn.frozen = 2;
        }

        //public void Operation(Player player, List<Card> grid,
        //    params object[] arguments)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
