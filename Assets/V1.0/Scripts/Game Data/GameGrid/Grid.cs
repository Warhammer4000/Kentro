

using System;
using System.Collections.Generic;
using System.Linq;

namespace Kentro
{
    [Serializable]
    public class Grid
    {
        #region Variable
        public  List<Card> Cards;
        public Position Goal { get; set; }
        /*public Player Player1;
        public Player Player2;*/
        public int GridSize;
        #endregion

        #region Constructor

        public Grid(int gridSize)
        {
            GridSize = gridSize;
            Cards = new List<Card>();
            
            Goal = new Position((GridSize - 1) / 2, (GridSize - 1) / 2);

            
        }

        #endregion

        public Card GetCard(Position position)
        {
            return Cards.FirstOrDefault(r => r.Position==position);
        }

        public void SetCard(Card card)
        {
            Cards.Add(card);
        }

    }
}
