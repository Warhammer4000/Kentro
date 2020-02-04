using System;
using System.Collections.Generic;

namespace Kentro
{
    public class PChangeNumber : IPowerUp
    {
        public PowerupEnum id = PowerupEnum.ChangeNumber;
        private int probability = 2;
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

            grid[0].ChangeNumber(value);
        }

        //public void Operation(Player player, List<Card> grid,
        //    params object[] arguments)
        //{
        //    //grid[(Position)arguments[0]].value = (int)arguments[1];
        //    Card card = (Card) arguments[0];
        //    card.value = (int) arguments[1];
        //}


    }
}
