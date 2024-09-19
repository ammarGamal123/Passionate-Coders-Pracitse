using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmahdy_Csharp_Advacned.Extension
{
    public static class NumberExtension
    {
        public static bool NumberIsBetweenRange(this int value , int min , int max)
        {
            return value >= min && value <= max;
        }
    }
}
