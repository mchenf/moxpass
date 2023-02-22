using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace moxpass.Utilities
{
    public static class ArrayExtisonMethods
    {
        /// <summary>
        /// Fill <paramref name="original"/> with an usually smaller array <paramref name="filler"/>. Truncate at tail.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original">The original array</param>
        /// <param name="filler">Pattern to be used</param>
        public static void SegmentFill<T>(this T[] original, T[] filler)
        {
            int j = 0;
            int olen = original.Length;
            int flen = filler.Length;
            for (int i = 0; i < olen; i++)
            {
                original[i] = filler[j];
                j = (j + 1) % flen;
            }

        }
    }
}
