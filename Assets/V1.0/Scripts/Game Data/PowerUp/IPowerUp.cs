

using System.Collections.Generic;

namespace Kentro
{
    public interface IPowerUp
    {
        int getProbability();
        void Operation(Player player1,Player player2, Dictionary<Position, Card> grid, 
            params object[] arguments);

        
    }
}
