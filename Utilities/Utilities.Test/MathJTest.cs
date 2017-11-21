using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Utilities.Test
{
    [TestClass]
    public class MathJTest
    {
        [TestMethod]
        public void InBetweenInclusive()
        {
            Assert.IsTrue(MathJ.InBetweenInclusive(1, 0, 2));
            Assert.IsTrue(MathJ.InBetweenInclusive(1, 2, 0));

            Assert.IsFalse(MathJ.InBetweenInclusive(3, 0, 2));
            Assert.IsFalse(MathJ.InBetweenInclusive(3, 2, 0));
        }
    }
}
