using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class MathJ
    {

        /// <summary>
        /// Determines if a number lies between two other numbers, inclusive.
        /// </summary>
        /// <param name="num">The number for comparison.</param>
        /// <param name="limit1">A limit to check against.</param>
        /// <param name="limit2">A limit to check against.</param>
        /// <returns>True if the number lies between or equals the other two numbers, false otherwise.</returns>
        public static bool InBetweenInclusive(this double num, double limit1, double limit2)
        {
            if (limit1 == limit2)
            {
                return num == limit1;
            }
            else if (limit1 > limit2)
            {
                return num <= limit1 && num >= limit2;
            }
            else
            {
                return num >= limit1 && num <= limit2;
            }
        }

        public static bool InBetweenInclusive(this int num, double limit1, double limit2)
        {
            return InBetweenInclusive((double)num, limit1, limit2);
        }

        /// <summary>
        /// Determines if a number lies between two other numbers, exclusive.
        /// </summary>
        /// <param name="num">The number for comparison.</param>
        /// <param name="limit1">A limit to check against.</param>
        /// <param name="limit2">A limit to check against.</param>
        /// <returns>True if the number lies between the other two numbers, false otherwise.</returns>
        public static bool InBetween(this double num, double limit1, double limit2)
        {
            if (limit1 == limit2)
            {
                return false;
            }
            else if (limit1 > limit2)
            {
                return num < limit1 && num > limit2;
            }
            else
            {
                return num > limit1 && num < limit2;
            }
        }

        public static bool InBetween(this int num, double limit1, double limit2)
        {
            return InBetween((double)num, limit1, limit2);
        }

        public static double Max(params double[] vals)
        {
            return Enumerable.Max(vals);
        }
        public static double Min(params double[] vals)
        {
            return Enumerable.Min(vals);
        }

        public static double StandardDeviation(IEnumerable<double> values)
        {
            if (values.Count() < 2)
                throw new Exception("Standard deviation calculation requires at least 2 values.");

            double average = values.Average();
            double sumOfSquaresOfDifferences = values.Sum(val => Math.Pow(val - average, 2));
            return Math.Sqrt(sumOfSquaresOfDifferences / (values.Count() - 1));
        }
    }
}
