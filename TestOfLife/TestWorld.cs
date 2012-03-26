using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryOfLife;
using NUnit.Framework;

namespace TestOfLife
{
    [TestFixture]
    public class TestWorld
    {
        
        [Test]
        public void TestEmptyWorld()
        {
            //Given
            var world = new World();
            //With
                //nothing
            //Check
            Assert.AreEqual(0, world.CellCount);
        }

        [Test]
        public void TestEmptyWorldGetCell()
        {
            //Given
            var world = new World();
            //With
                //nothing
            //Check
            //That a random cell is a default type cell
            ICoordinate coord = new Mock0DCoord();
            ICell fetchedCell = world.CellAt(coord);
            Assert.IsTrue(fetchedCell.GetType() == world.DefaultCell.GetType());
        }

        [Test]
        public void TestSetCell()
        {
            //Given
            var world = new World();

            //With
            ICoordinate coord1 = new Mock0DCoord();

            world.SetCell(coord1, new MockCell());
            
            //Check
            //That the cell count is 1
            Assert.AreEqual(1, world.CellCount);

        }

        [Test]
        public void TestGetCell()
        {
            //Given
            var world = new World();
            
            //With
            ICoordinate coord1 = new Mock1DCoord(5);

            ICoordinate coord2 = new Mock1DCoord(9);
            ICoordinate coord3 = new Mock1DCoord(-30);

            ICell cell1 = new MockCell();
            ICell cell2 = new MockCell();
            ICell cell3 = new MockCell();

            world.SetCell(coord1, cell1);
            world.SetCell(coord2, cell2);
            world.SetCell(coord3, cell3);
            
            //Check
            //That the cell count is 3
            Assert.AreEqual(3,world.CellCount);

            //That each cell is where it is expected
            Assert.AreEqual(cell1, world.CellAt(coord1));
            Assert.AreEqual(cell2, world.CellAt(coord2));
            Assert.AreEqual(cell3, world.CellAt(coord3));

            //That cells are not in unexpected places
            Assert.AreNotEqual(cell1, coord2);
            Assert.AreNotEqual(cell1, coord3);
        }

        private class Mock0DCoord : ICoordinate
        {
            public bool Equals(ICoordinate other)
            {
                return other is Mock0DCoord;
            }
        }

        private class Mock1DCoord : ICoordinate
        {

            private readonly int _x;

            public Mock1DCoord(int x)
            {
                _x = x;
            }

            public bool Equals(ICoordinate other)
            {
                var other1D = other as Mock1DCoord;
                if(other1D == null) return false;
                return other1D._x == _x;
            }
        }

        private class MockCell : ICell
        {
            private readonly Guid _cellID;

            public MockCell()
            {
                _cellID = Guid.NewGuid();
            }

            public bool Equals(MockCell other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return other._cellID.Equals(_cellID);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (MockCell)) return false;
                return Equals((MockCell) obj);
            }

            public override int GetHashCode()
            {
                return _cellID.GetHashCode();
            }
        }
    }
}
