using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class StringExtensions
    {
        public static char ToUpper(this char c)
        {
            return char.ToUpper(c);
        }

        public static char ToLower(this char c)
        {
            return char.ToLower(c);
        }

        public static string[] Split(this string str, string separator)
        {
            return str.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }
        
    }
}
