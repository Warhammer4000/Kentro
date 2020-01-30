

using System;

namespace Kentro
{
    [Serializable]
    public class Position
    {
        public int X, Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Position);
        }
        public bool Equals(Position obj)
        {
            return obj != null && obj.X == X && obj.Y == Y;
        }


    }
}
