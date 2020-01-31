

using System;
using JetBrains.Annotations;

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

        public static bool operator ==([NotNull] Position left,[NotNull] Position right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}
