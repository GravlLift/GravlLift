using System.Windows;

namespace Utilities
{
    public struct Line
    {
        public Point p1;
        public Point p2;

        public double Distance
        {
            get
            {
                return Geometry.Distance(p1, p2);
            }
        }

        public Line(double startX, double startY, double endX, double endY)
        {
            p1 = new Point(startX, startY);
            p2 = new Point(endX, endY);
        }

        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public override string ToString()
        {
            return "{" + p1.ToString() + "},{" + p2.ToString() + "}";
        }
    }
}
