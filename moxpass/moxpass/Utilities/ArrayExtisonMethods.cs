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
        /// Fill <paramref name="original"/> with an usually smaller array <paramref name="filler"/>. Truncate at <paramref name="filler"/>'s tail.
        /// </summary>
        /// <typeparam name="T">Array Types in both <paramref name="original"/> and <paramref name="filler"/> should align</typeparam>
        /// <param name="original">The original array to be filled</param>
        /// <param name="filler">Filler pattern to be used</param>
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
        /// <summary>
        /// Fill <paramref name="original"/> with <paramref name="head"/> first, 
        /// and then the rest an usually smaller array <paramref name="filler"/>. 
        /// Truncate at <paramref name="filler"/>'s tail.
        /// </summary>
        /// <typeparam name="T">Array Types in both <paramref name="original"/> and <paramref name="filler"/> should align</typeparam>
        /// <param name="original">The original array to be filled</param>
        /// <param name="filler">Filler pattern to be used</param>
        public static void SegmentFill<T>(this T[] original, T[] head, T[] filler)
        {
            int hlen = head.Length;
            int tlen = original.Length > hlen ? original.Length - hlen : 0;

            T[] tail = new T[tlen];
            tail.SegmentFill(filler);
            T[] newArr = head.GlueWith(tail);
            int ilen = newArr.Length > original.Length ? original.Length : newArr.Length;
            for (int i = 0; i < ilen; i++)
            {
                original[i] = newArr[i];
            }

        }

        /// <summary>
        /// Attach <paramref name="tail"/> to the end of <paramref name="head"/>, thereby extending <paramref name="head"/>.
        /// </summary>
        /// <typeparam name="T">Array type for both <paramref name="tail"/> and <paramref name="head"/> should align</typeparam>
        /// <param name="head">The base, or head of the arrays</param>
        /// <param name="tail">The tail to be attached</param>
        /// <returns>The new <typeparamref name="T"/> array after glue</returns>
        public static T[] GlueWith<T>(this T[] head, T[] tail)
        {
            int tlen = tail.Length;
            int hlen = head.Length;

            T[] newArray = new T[tlen + hlen];

            for (int i = 0; i < hlen; i++)
            {
                newArray[i] = head[i];
            }

            for (int i = hlen; i < tlen + hlen; i++)
            {
                newArray[i] = tail[i - hlen];
            }

            return newArray;
        }
    }
}
