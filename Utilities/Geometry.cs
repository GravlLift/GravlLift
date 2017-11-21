using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Utilities
{
    public static class Geometry
    {
        /// <summary>
        /// Determines if a line segment intersects a rectangle
        /// </summary>
        /// <param name="p1">First endpoint of the line</param>
        /// <param name="p2">Second endpoint of the line</param>
        /// <param name="r">Rectangle to check against</param>
        /// <returns>Returns true if the line intersects with the rectangle's edges or is contained by the rectangle, false otherwise</returns>
        public static bool LineIntersectsRect(Line line, RectJ r)
        {
            return LineIntersectsLine(line, r.TopEdge) ||
                   LineIntersectsLine(line, r.LeftEdge) ||
                   LineIntersectsLine(line, r.RightEdge) ||
                   LineIntersectsLine(line, r.BottomEdge) ||
                   (r.Contains(line.p1) && r.Contains(line.p2));
        }

        /// <summary>
        /// Determines if a two line segments intersect
        /// </summary>
        /// <param name="l1p1">First endpoint of the first line</param>
        /// <param name="l1p2">Second endpoint of the first line</param>
        /// <param name="l2p1">First endpoint of the second line</param>
        /// <param name="l2p2">Second endpoint of the second line</param>
        /// <returns>Returns true if the lines intersect, false otherwise</returns>
        /// 
        public static bool LineIntersectsLine(Point l1p1, Point l1p2, Point l2p1, Point l2p2)
        {
            return LineIntersectsLine(new Line(l1p1, l1p2), new Line(l2p1, l2p2));
        }

        /// <summary>
        /// Determines if a two line segments intersect
        /// </summary>
        /// <param name="l1">First line</param>
        /// <param name="l2">Second line</param>
        /// <returns>Returns true if the lines intersect, false otherwise</returns>
        public static bool LineIntersectsLine(Line l1, Line l2)
        {
            if (!(l1.p1.X.InBetweenInclusive(l2.p1.X, l2.p2.X)
                || l1.p2.X.InBetweenInclusive(l2.p1.X, l2.p2.X)
                || l2.p1.X.InBetweenInclusive(l1.p1.X, l1.p2.X)
                || l2.p2.X.InBetweenInclusive(l1.p1.X, l1.p2.X)))
                return false;

            if (!(l1.p1.Y.InBetweenInclusive(l2.p1.Y, l2.p2.Y)
                || l1.p2.Y.InBetweenInclusive(l2.p1.Y, l2.p2.Y)
                || l2.p1.Y.InBetweenInclusive(l1.p1.Y, l1.p2.Y)
                || l2.p2.Y.InBetweenInclusive(l1.p1.Y, l1.p2.Y)))
                return false;

            

            return true;
        }

        /// <summary>
        /// Determines the distance between two points.
        /// </summary>
        /// <returns>The distance between p1 and p2</returns>
        public static double Distance(Point p1, Point p2)
        {
            if (p1 == null) throw new ArgumentNullException(nameof(p1));
            if (p2 == null) throw new ArgumentNullException(nameof(p2));
            double a = Math.Abs(p1.Y - p2.Y);
            double b = Math.Abs(p1.X - p2.X);

            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            return c;
            //return ((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        public static Point? GetIntersection(Line l1, Line l2)
        {
            double deltaACy = l1.p1.Y - l2.p1.Y;
            double deltaDCx = l2.p2.X - l2.p1.X;
            double deltaACx = l1.p1.X - l2.p1.X;
            double deltaDCy = l2.p2.Y - l2.p1.Y;
            double deltaBAx = l1.p2.X - l1.p1.X;
            double deltaBAy = l1.p2.Y - l1.p1.Y;

            double denominator = deltaBAx * deltaDCy - deltaBAy * deltaDCx;
            double numerator = deltaACy * deltaDCx - deltaACx * deltaDCy;

            if (denominator == 0)
            {
                if (numerator == 0)
                {
                    // collinear. Potentially infinite intersection points.
                    // Check and return one of them.
                    if (l1.p1.X >= l2.p1.X && l1.p1.X <= l2.p2.X)
                    {
                        return l1.p1;
                    }
                    else if (l2.p1.X >= l1.p1.X && l2.p1.X <= l1.p2.X)
                    {
                        return l2.p1;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                { // parallel
                    return null;
                }
            }

            double r = numerator / denominator;
            if (r.InBetweenInclusive(0, 1))
            {
                return null;
            }

            double s = (deltaACy * deltaBAx - deltaACx * deltaBAy) / denominator;
            if (s.InBetweenInclusive(0, 1))
            {
                return null;
            }

            return new Point((l1.p1.X + r * deltaBAx), (l1.p1.Y + r * deltaBAy));
        }
    }
}
