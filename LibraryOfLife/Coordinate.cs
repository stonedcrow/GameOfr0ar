using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOfLife
{
    public abstract class Coordinate : IEquatable<Coordinate>
    {
        public static int GetPartCount<T>() where T : Coordinate
        {
            return (int)typeof(T).GetMethod("GetPartCount").Invoke(null, null);
        }
        public static List<Type> GetPartTypes<T>() where T : Coordinate
        {
            return (List<Type>)typeof(T).GetMethod("GetPartTypes").Invoke(null, null);

        }

        public abstract bool Equals(Coordinate other);
        public abstract IEnumerable<Coordinate> GetAdjacentCoords();
    }
}
