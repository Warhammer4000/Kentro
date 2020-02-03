

using System.Collections.Generic;

namespace Kentro
{
    public interface IPowerUp
    {
        int getProbability();
        void Operation(Player player1,Player player2, List<Card> grid, 
            params object[] arguments);

        PowerupEnum getType();
    }
}
