using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LibraryOfLife;

namespace TestOfLife
{
    [TestFixture]
    public class TestStandardRules
    {
        [Test]
        public void TestCellGenerationValidation()
        {
            //Given:
            //new standard rules
            IRulesProvider rules = new StandardRules();

            //With
            //nothing

            //Check
            //That too few or too many coordinates fail
            Assert.Throws<ArgumentException>(() => rules.MakeCoordinate(1), "Should not accept a single coordinate");
            Assert.Throws<ArgumentException>(() => rules.MakeCoordinate(1, 2, 3), "Should not accept more than 2 coordinates");

            //That the types are checked correctly
            Assert.Throws<ArgumentException>(() => rules.MakeCoordinate("1", "2"), "Should only accept ints");
            Assert.Throws<ArgumentException>(() => rules.MakeCoordinate(1, "2"), "Should only accept if all params are ints");

        }

        [Test]
        public void TestCellGeneration()
        {
            //Given:
            //new standard rules
            IRulesProvider rules = new StandardRules();

            //With:
            //a new coordinate
            var stdCoord = rules.MakeCoordinate(1, 2) as StandardCoordinate;

            //Check:
            //that the new coordinate is a StandardCoordinate
            Assert.IsNotNull(stdCoord, "the coordinate returned should be a StandardCoordinate");
            //the coordinates are correct
            Assert.AreEqual(1, stdCoord.X, "The X value should be 1");
            Assert.AreEqual(2, stdCoord.Y, "The Y value should be 2");
            //the new coordinate equals a specifically made one
            var coord = new StandardCoordinate(1, 2);
            Assert.AreEqual(stdCoord, coord, "the coordinate returned should be the same as a specifically created coordinate");
        }
    }

}
