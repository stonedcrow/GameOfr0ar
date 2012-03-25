using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conway.LibraryOfLife;
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

    }
}
