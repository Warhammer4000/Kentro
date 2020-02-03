using System;
using System.Collections.Generic;

namespace Kentro
{
    public class PChangeNumber:IPowerUp
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

        public void Operation(Player player1, Player player2, Dictionary<Position, Card> grid,
            params object[] arguments)
        {
            grid[(Position)arguments[0]].value = (int)arguments[1];
        }

       
    }
}
