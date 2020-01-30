

using System;

namespace Kentro
{
    public class Position
    {
        public int x, y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool equals(int v,int w)
        {
            if (v == x && w == y) return true;
            else
            {
                return false;
            }
        }

        public static explicit operator Position(int v)
        {
            throw new NotImplementedException();
        }
    }
}
