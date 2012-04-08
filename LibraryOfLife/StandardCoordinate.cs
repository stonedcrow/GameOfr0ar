using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOfLife
{
    public class StandardCoordinate : Coordinate
    {
        private readonly int _x;
        private readonly int _y;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        
        public StandardCoordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is StandardCoordinate)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as StandardCoordinate);
        }

        public bool Equals(StandardCoordinate coord)
        {
            if (ReferenceEquals(this, coord)) return true;
            return _x == coord._x && _y == coord._y;
        }

        public override bool Equals(Coordinate coord)
        {
            if (!(coord is StandardCoordinate)) return false;
            return Equals(coord as StandardCoordinate);
        }


        public static int GetPartCount()
        {
            return 2;
        }

        public static List<Type> GetPartTypes()
        {
            return new List<Type> { typeof(int), typeof(int) };
        }
    }
}
