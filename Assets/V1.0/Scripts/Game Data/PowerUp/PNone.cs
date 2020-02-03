using System;
using System.Collections.Generic;

namespace Kentro
{

   public class PNone:IPowerUp

    {
        public PowerupEnum id = PowerupEnum.None;
        private int probability = 1;
        public int getProbability()
        {
            return probability;
        }

        public PowerupEnum getType()
        {
            return id;
        }

        public void Operation(Player player1, Player player2, List<Card> gridd,
            params object[] arguments)
        {
            throw new NotImplementedException();
        }

        
    }
}
