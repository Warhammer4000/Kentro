using System;
using System.Collections.Generic;

namespace Kentro
{
    public class PShow:IPowerUp
    {
        private int probability = 4;
        public int getProbability()
        {
            return probability;
        }

        public void Operation(Player player1, Player player2, Dictionary<Position, Card> grid, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        
    }
}
