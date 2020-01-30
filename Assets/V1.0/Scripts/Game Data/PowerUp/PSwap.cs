using System.Collections.Generic;

namespace Kentro
{

    public class PSwap:IPowerUp


    {
        private int probability = 6;
        public int getProbability()
        {
            return probability;
        }

        public void Operation(Player player1, Player player2, Dictionary<Position, Card> grid,
            params object[] arguments)
        {
            int a, b;

            a = grid[(Position)arguments[0]].value;
            b = grid[(Position)arguments[1]].value;
            grid[(Position)arguments[0]].value = b;
            grid[(Position)arguments[1]].value = a;
        }
    }
}