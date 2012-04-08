using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOfLife
{
    public interface IRulesProvider
    {
        Coordinate MakeCoordinate(params object[] parts);
    }
}
