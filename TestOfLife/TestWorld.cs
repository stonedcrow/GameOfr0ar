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

        private class Mock0DCoord : ICoordinate
        {
            public bool Equals(ICoordinate other)
            {
                return other is Mock0DCoord;
            }
        }

    }
}
