using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOfLife
{
    public class World
    {
        #region Class Members

        private readonly ICell _defaultCell;
        private Dictionary<ICoordinate, ICell> _cells;
        private IRulesProvider _rules;

        #endregion // Class Members

        #region Constructors 

        public World()
        {
            _cells = new Dictionary<ICoordinate, ICell>();
            _defaultCell = new DefaultCell();
        }

        #endregion // Constructors

        #region Properties

        public ICell DefaultCell { get { return _defaultCell; } }

        public int CellCount
        {
            get { return _cells.Count; }
        }

        #endregion // Properties

        #region Methods 

        public ICell CellAt(ICoordinate coord)
        {
            ICell cell;
            if (_cells.TryGetValue(coord, out cell))
            {
                return cell;
            }
            return DefaultCell;
        }

        #endregion // Methods

    }

    public class DefaultCell : ICell
    {
        
    }
}
