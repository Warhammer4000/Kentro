

using System.Collections.Generic;

namespace Kentro
{
    public interface IPowerUp
    {
        int getProbability();
        void Operation( List<Card> grid, 
            int value);

        PowerupEnum getType();
    }
}
