using System;
using System.Windows;

namespace Utilities
{
    public struct RectJ
    {
        public Double Width;
        public Double Height;

        public Double X
        {
            get
            {
                return TopLeft.X;
            }
        }

        public Double Y
        {
            get
            {
                return TopLeft.Y;
            }
        }

        public Point TopLeft;

        public Point TopRight
        {
            get
            {
                return new Point(TopLeft.X + Width, TopLeft.Y);
            }
        }

        public Point BottomLeft
        {
            get
            {
                return new Point(TopLeft.X, TopLeft.Y - Height);
            }
        }



        public Point BottomRight
        {
            get
            {
                return new Point(TopLeft.X + Width, TopLeft.Y - Height);
            }
        }

        public Line TopEdge
        {
            get
            {
                return new Line(TopLeft, TopRight);
            }
        }
        public Line LeftEdge
        {
            get
            {
                return new Line(BottomLeft, TopLeft);
            }
        }
        public Line BottomEdge
        {
            get
            {
                return new Line(BottomLeft, BottomRight);
            }
        }
        public Line RightEdge
        {
            get
            {
                return new Line(TopRight, BottomRight);
            }
        }

        public RectJ(double topLeftX, double topLeftY, double width, double height)
        {
            TopLeft = new Point(topLeftX, topLeftY);
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            return TopLeft.ToString() + "," + Width + "," + Height;
        }

        public bool Contains(Point p)
        {
            return (p.X.InBetweenInclusive(TopLeft.X, BottomRight.X)
                && p.Y.InBetweenInclusive(TopLeft.Y, BottomRight.Y));
        }

        public bool Contains(Line l)
        {
            return Contains(l.p1) && Contains(l.p2);
        }
    }
}
