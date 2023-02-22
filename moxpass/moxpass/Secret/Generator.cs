using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace moxpass.Secret
{

    public class Generator
    {
        private static char[] getChars(char start, int len)
        {
            char[] result = new char[len];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (char)(start + i);
            }

            return result;
        }
        private static char[] getLowers() => getChars('a', 26);
        private static char[] getUppers() => getChars('A', 26);
        private static char[] getNumbers() => getChars('0', 10);
        private static char[] getSymbol1() => getChars('!', 15);
        private static char[] getSymbol2() => getChars(':', 7);
        private static char[] getSymbol3() => getChars('[', 6);
        private static char[] getSymbol4() => getChars('{', 4);

        private char[] seed = new char[256];
        private void fillSeed(Complexity complexity)
        {
            switch (complexity)
            {
                case Complexity.Lowers:
                    char[] iteration = getLowers();
                    
                    break;
                case Complexity.Uppers:
                    break;
                case Complexity.Numbers:
                    break;
                case Complexity.Symbols:
                    break;
                case Complexity.NoSymbol:
                    break;
                case Complexity.AlphaOnly:
                    break;
                case Complexity.Full:
                    break;
                default:
                    break;
            }
        }
        public Generator(int length, Complexity complexity = Complexity.Full)
        {

        }


        public static Span<byte> Generate(int length, Complexity complexity = Complexity.Full)
        {
            Span<byte> span = new Span<byte>(new byte[length]);

            RandomNumberGenerator.Fill(span);

            return span;

        }


        public struct Bounds
        {
            public int Lower, Upper;
            public static Bounds Set(int l, int u)
            {
                return new Bounds { Lower = l, Upper = u };
            }
        }

        public static Span<byte> Generate(int length, 
            Func<byte, Bounds, bool> continueCheck, 
            Complexity complexity = Complexity.Full)
        {
            Span<byte> span = Generate(length, complexity);

            Bounds bounds = Bounds.Set(33, 126);

            for (int i = 0; i < span.Length; i++)
            {
                while (continueCheck.Invoke(span[i], bounds))
                {
                    span[i] += 92;
                }
            }

            return span;

        }

        public static void RecordResult(byte[] bytes, int[] result)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                result[bytes[i]]++;
            }
        }

        public static void PrintHisto(int[] result)
        {
            int max = 0;
            int total = 0;
            foreach (int kvp in result)
            {
                max = kvp > max ? kvp : max;
                total += kvp;
            }
            for (int i = 0; i < result.Length; i++)
            {
                double tmp = (double)result[i] / (double)max;
                int steps = (int)(tmp * 1000);
                Console.Write(i.ToString().PadLeft(3, '0'));
                Console.Write("\t");
                Console.Write(getProgressBar(steps));
                Console.Write("\t\t");
                double freq = (double)result[i] / (double)total;
                Console.Write("{0:P2}", freq);
                Console.WriteLine();
            }

        }

        private readonly static char prog1 = '\u258e';
        private readonly static char prog2 = '\u258c';
        private readonly static char prog3 = '\u258a';
        private readonly static char prog4 = '\u2588';

        private static string getProgressBar(int progress)
        {
            if (progress == 0)
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            while (progress >= 0)
            {
                builder.Append(prog4);
                progress -= 4;
            }

            switch (progress)
            {
                case 1: builder.Append(prog1); break;
                case 2: builder.Append(prog2); break;
                case 3: builder.Append(prog3); break;
                default:
                    break;
            }

            return builder.ToString();
        }
    }

    [Flags]
    public enum Complexity
    {
        Lowers          = 0b_0000_0000_0000_0001,
        Uppers          = 0b_0000_0000_0000_0010,
        Numbers         = 0b_0000_0000_0000_0100,
        Symbols         = 0b_0000_0000_0000_1000,

        NoSymbol        = Lowers | Uppers | Numbers,
        AlphaOnly       = Lowers | Uppers,

        Full            = 0b_1111_1111_1111_1111,
    }
}
