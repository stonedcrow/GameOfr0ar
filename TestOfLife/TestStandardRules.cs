using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryOfLife;
using NUnit.Framework;

namespace TestOfLife
{
    [TestFixture]
    public class TestStandardRules
    {

        [Test]
        public void TestCellGeneration()
        {
            //Given
            IRulesProvider rules = new StandardRules();
        }

    }
}
