using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOfLife
{
    public class StandardCell : ICell
    {
        private readonly bool _isAlive;
        public bool IsAlive { get { return _isAlive; } }
        public StandardCell(bool alive)
        {
            _isAlive = alive;
        }
        public StandardCell()
        {
            _isAlive = false;
        }
    }

}
