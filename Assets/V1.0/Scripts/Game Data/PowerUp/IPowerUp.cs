

using System.Collections.Generic;

namespace Kentro
{
    public interface IPowerUp
    {
        int getProbability();
        void Operation(Player player, List<Card> grid, 
            params object[] arguments);

        PowerupEnum getType();
    }
}
