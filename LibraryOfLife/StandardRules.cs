using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOfLife
{
    public class StandardRules : IRulesProvider
    {

        public Coordinate MakeCoordinate(params object[] parts)
        {
            if (parts.Length != StandardCoordinate.GetPartCount())
                throw new ArgumentException("Standard coordinates require an x and y value");
            var partyTypes = StandardCoordinate.GetPartTypes();
            if (!(parts[0].GetType() == partyTypes[0] && parts[1].GetType() == partyTypes[1]))
                throw new ArgumentException("Both parts must be integers");

            var x = (int)parts[0];
            var y = (int)parts[1];

            return new StandardCoordinate(x, y);
        }

    }
}
