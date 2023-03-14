using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using moxpass.Utilities;

namespace moxpass.Secret
{

    public class SecretGenerator
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
            char[] filler;
            char[] head = new char[0];
            switch (complexity)
            {
                case Complexity.Lowers:
                    filler = getLowers();
                    break;
                case Complexity.Uppers:
                    filler = getUppers();
                    break;
                case Complexity.Numbers:
                    filler = getNumbers();
                    break;
                case Complexity.Symbols:
                    filler = getSymbol1()
                        .GlueWith(getSymbol2())
                        .GlueWith(getSymbol3())
                        .GlueWith(getSymbol4());
                    break;
                case Complexity.NoSymbol:
                    filler = getLowers()
                        .GlueWith(getUppers())
                        .GlueWith(getNumbers());
                    break;
                case Complexity.AlphaOnly:
                    filler = getLowers()
                        .GlueWith(getUppers());
                    break;
                case Complexity.Full:
                    filler = getLowers()
                        .GlueWith(getUppers())
                        .GlueWith(getNumbers());
                    head = getSymbol1()
                        .GlueWith(getSymbol2())
                        .GlueWith(getSymbol3())
                        .GlueWith(getSymbol4());
                    break;
                default:
                    filler = new char[] {'x'}; 
                    break;
            }
            seed.SegmentFill(head, filler);
        }
        public SecretGenerator(Complexity complexity = Complexity.Full)
        {
            fillSeed(complexity);
        }

        public string Spew(int Length)
        {
            Span<byte> b = GetRandomBytes(Length);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < b.Length; i++)
            {
                sb.Append(seed[b[i]]);
            }

            return sb.ToString();
        }

        public void GetSeedTable()
        {
            int slen = seed.Length;
            for (int i = 0; i < slen; i++)
            {
                Console.Write("{0,5} : {1}", i, seed[i]);
                if (i % 8 == 7)
                {
                    Console.WriteLine();
                }
            }
        }
        public static Span<byte> GetRandomBytes(int length)
        {
            Span<byte> span = new Span<byte>(new byte[length]);

            RandomNumberGenerator.Fill(span);

            return span;

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
