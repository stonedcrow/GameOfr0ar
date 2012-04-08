using System.Collections.Generic;

namespace LibraryOfLife
{
    public class World
    {
        #region Class Members

        private Dictionary<Coordinate, ICell> _cells;
        private readonly IRulesProvider _rules;

        #endregion // Class Members

        #region Constructors 

        public World()
        {
            _rules = new StandardRules();
            _cells = new Dictionary<Coordinate, ICell>();
        }

        public World(IRulesProvider rules)
        {
            _cells = new Dictionary<Coordinate, ICell>();
            _rules = rules;
        }

        #endregion // Constructors

        #region Properties

        public ICell DefaultCell { get { return _rules.DefaultCell; } }

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
}
