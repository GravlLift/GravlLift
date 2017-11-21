using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using System.Windows;

namespace Utilities.Test
{
    [TestClass]
    public class GeometryTest
    {
        [TestMethod]
        public void GetIntersection()
        {
            Assert.IsTrue(Geometry.GetIntersection(new Line(new Point(0, 0), new Point(2, 2)), new Line(new Point(0, 2), new Point(2, 0))) == new Point(1, 1));
        }

        [TestMethod]
        public void LineIntersectsLine()
        {
            Assert.IsTrue(Geometry.LineIntersectsLine(new Line(new Point(0, 0), new Point(2, 0)), new Line(new Point(1, 1), new Point(1, -1))));
            Assert.IsTrue(Geometry.LineIntersectsLine(new Line(new Point(0, 0), new Point(200, 200)), new Line(new Point(2, 0), new Point(0, 2))));
            Assert.IsTrue(Geometry.LineIntersectsLine(new Point(4, 2), new Point(2, 2), new Point(2.5, 2.5), new Point(2.5, 1.5)));

            Assert.IsFalse(Geometry.LineIntersectsLine(new Line(new Point(0, 0), new Point(2, 0)), new Line(new Point(-1, 1), new Point(-1, -1))));
            Assert.IsFalse(Geometry.LineIntersectsLine(new Line(new Point(0, 0), new Point(2, 0)), new Line(new Point(0, 1), new Point(2, 1))));
        }

        [TestMethod]
        public void Distance()
        {
            Assert.IsTrue(Geometry.Distance(new Point(0, 0), new Point(0, 2)) == 2);
            Assert.IsTrue(Geometry.Distance(new Point(0, 0), new Point(-3, 4)) == 5);
        }
    }
}
