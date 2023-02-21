using Microsoft.VisualStudio.TestTools.UnitTesting;
using moxpass.Secret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moxpass.Secret.Tests
{
    [TestClass()]
    public class GeneratorTests
    {
        [TestMethod()]
        [DataRow(16)]
        public void GenerateTest(int len)
        {

            int[] stats = new int[256];
            //Generate 10000 times bytes, and store data
            for (int i = 0; i < 100000; i++)
            {
                Span<byte> b = Generator.Generate(len,
                    (a, b) => a < b.Lower || a > b.Upper);


                Generator.RecordResult(b.ToArray(), stats);

            }

            Generator.PrintHisto(stats);

            Assert.IsTrue(true);
        }
    }
}