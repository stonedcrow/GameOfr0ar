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
            //That 2 coordinates pass
            Assert.DoesNotThrow(() => rules.MakeCoordinate(1, 1), "Legal call should not throw an exception");

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

        [Test]
        public void TestDefaultCell()
        {
            //Given:
            //new standard rules
            IRulesProvider rules = new StandardRules();
            //a world with those rules
            var world = new World(rules);

            //Check:
            //That the default cell is a dead StandardCell
            var cell = world.DefaultCell as StandardCell;
            Assert.IsNotNull(cell);
            Assert.IsFalse(cell.IsAlive);
            
        }

        [Test]
        public void TestTickRule()
        {
            //Given:
            //A new standard rules
            IRulesProvider rules = new StandardRules();
            //A alive central cell
            ICell liveCentral = new StandardCell(true);
            //A dead central cell
            ICell deadCentral = new StandardCell(false);

            //4 alive adjacent cells
            ICell live1 = new StandardCell(true);
            ICell live2 = new StandardCell(true);
            ICell live3 = new StandardCell(true);
            ICell live4 = new StandardCell(true);

            //8 dead ajacent cells
            ICell dead1 = new StandardCell();
            ICell dead2 = new StandardCell();
            ICell dead3 = new StandardCell();
            ICell dead4 = new StandardCell();
            ICell dead5 = new StandardCell();
            ICell dead6 = new StandardCell();
            ICell dead7 = new StandardCell();
            ICell dead8 = new StandardCell();
            
            //Check:
            //rule 1
            var result = (StandardCell)rules.GetNextGeneration(liveCentral, dead1, dead2, dead3, dead4, dead5, dead6, dead7, dead8);
            Assert.IsFalse(result.IsAlive);
            result = (StandardCell)rules.GetNextGeneration(liveCentral, live1, dead1, dead2, dead3, dead4, dead5, dead6, dead7);
            Assert.IsFalse(result.IsAlive);

            //rule 2
            result = (StandardCell)rules.GetNextGeneration(liveCentral, live1, live2, dead1, dead2, dead3, dead4, dead5, dead6);
            Assert.IsTrue(result.IsAlive);
            result = (StandardCell)rules.GetNextGeneration(liveCentral, live1, live2, live3, dead1, dead2, dead3, dead4, dead5);
            Assert.IsTrue(result.IsAlive);

            //rule 3
            result = (StandardCell)rules.GetNextGeneration(liveCentral, live1, live2, live3, live4, dead2, dead3, dead4, dead5);
            Assert.IsFalse(result.IsAlive);
            
            //rule 4
            result = (StandardCell)rules.GetNextGeneration(deadCentral, dead1, dead2, dead3, dead4, dead5, dead6, dead7, dead8);
            Assert.IsFalse(result.IsAlive);
            result = (StandardCell)rules.GetNextGeneration(deadCentral, live1, live2, live3, dead1, dead2, dead3, dead4, dead5);
            Assert.IsTrue(result.IsAlive);
            result = (StandardCell)rules.GetNextGeneration(deadCentral, live1, live2, live3, live4, dead1, dead2, dead3, dead4);
            Assert.IsFalse(result.IsAlive);
        }
    }

    [TestFixture]
    public class TestStandardCoordinate
    {
        [Test]
        public void TestParamInfo()
        {
            //Check:
            //That the standard part count is 2
            Assert.AreEqual(2, StandardCoordinate.GetPartCount(), "Partcount from StandardCoordinate must be 2");
            Assert.AreEqual(2, Coordinate.GetPartCount<StandardCoordinate>(), "Partcount from Coordinate for StandardCoordinate must be 2");

            //That the part types are both ints
            var parts = StandardCoordinate.GetPartTypes();
            var baseParts = Coordinate.GetPartTypes<StandardCoordinate>();
            Assert.AreEqual(typeof(int), parts[0], "Part 0 must be int from StandardCoordinate");
            Assert.AreEqual(typeof(int), parts[1], "Part 1 must be int from StandardCoordinate");
            Assert.AreEqual(typeof(int), baseParts[0], "Part 0 must be int from Coordinate for StandardCoordiante");
            Assert.AreEqual(typeof(int), baseParts[1], "Part 1 must be int from Coordinate for StandardCoordiante");
        }

        [Test]
        public void TestCoordinateEquality()
        {
            //Given:
            //an abitrary coordinate
            Coordinate coord1 = new StandardCoordinate(1, 1);
            //another identical coordinate
            Coordinate coord2 = new StandardCoordinate(1, 1);
            //another non-identical coordinate
            Coordinate coord3 = new StandardCoordinate(1, 2);
            //yet another non-identical coordinate
            Coordinate coord4 = new StandardCoordinate(2, 1);

            //Check
            //the identical coordinates are infact equal
            Assert.AreEqual(coord1, coord2, "Identical coordinates should return as equal");
            //The non-identical coordinates do not equate
            Assert.AreNotEqual(coord1, coord3, "Coordinates should not match");
            Assert.AreNotEqual(coord1, coord4, "Coordinates should not match");
        }

        [Test]
        public void TestAdjacentCoordinates()
        {
            //Given:
            //An abitrarily placed cell
            var rand = new Random();
            var x = rand.Next(10000);
            var y = rand.Next(10000);
            Coordinate centerCoord = new StandardCoordinate(x, y);
            //the expected list of adjacent coordiantes
            var coord1 = new StandardCoordinate(x - 1,  y - 1);
            var coord2 = new StandardCoordinate(x,      y - 1);
            var coord3 = new StandardCoordinate(x + 1,  y - 1);
            var coord4 = new StandardCoordinate(x - 1,  y);
            var coord5 = new StandardCoordinate(x + 1,  y);
            var coord6 = new StandardCoordinate(x - 1,  y + 1);
            var coord7 = new StandardCoordinate(x, y +  1);
            var coord8 = new StandardCoordinate(x + 1,  y + 1);

            //Check:
            var adjacent = centerCoord.GetAdjacentCoords().ToList();
            //That there are 8 adjacent coordinates
            Assert.AreEqual(8,adjacent.Count, "There should be 8 adjacent coordinates in the list");
            //That each of the expected coordinates are in the list
            Assert.IsTrue(adjacent.Contains(coord1));
            Assert.IsTrue(adjacent.Contains(coord2));
            Assert.IsTrue(adjacent.Contains(coord3));
            Assert.IsTrue(adjacent.Contains(coord4));
            Assert.IsTrue(adjacent.Contains(coord5));
            Assert.IsTrue(adjacent.Contains(coord6));
            Assert.IsTrue(adjacent.Contains(coord7));
            Assert.IsTrue(adjacent.Contains(coord8));
            //That the center coordinate IS NOT in the list
            Assert.IsFalse(adjacent.Contains(centerCoord));
        }
    }
}
