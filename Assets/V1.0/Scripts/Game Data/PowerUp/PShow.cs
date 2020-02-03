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

        public void Operation(Player player1, Player player2, Dictionary<Position, Card> grid, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        
    }
}
