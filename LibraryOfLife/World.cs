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
        private Dictionary<Coordinate, ICell> _cells;
        private IRulesProvider _rules;

        #endregion // Class Members

        #region Constructors 

        public World()
        {
            _cells = new Dictionary<Coordinate, ICell>();
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

        public ICell CellAt(Coordinate coord)
        {
            ICell cell;
            if (_cells.TryGetValue(coord, out cell))
            {
                return cell;
            }
            return DefaultCell;
        }

        public void SetCell(Coordinate coordinate, ICell cell)
        {
            var existing = CellAt(coordinate);
            if (existing != DefaultCell)
            {
                _cells[coordinate] = cell;
            }
            else
            {
                _cells.Add(coordinate, cell);
            }
        }

        public void Tick()
        {
            
        }

        #endregion // Methods
        
    }

    public class DefaultCell : ICell
    {
        
    }
}
