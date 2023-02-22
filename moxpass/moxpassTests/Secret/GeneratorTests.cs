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
        [DataRow(Complexity.Full)]
        [DataRow(Complexity.Lowers)]
        [DataRow(Complexity.Uppers)]
        [DataRow(Complexity.AlphaOnly)]
        [DataRow(Complexity.NoSymbol)]
        public void GetSeedTableTest(Complexity cpx)
        {
            Generator g = new Generator(cpx);

            g.GetSeedTable();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        [DataRow(Complexity.Full, 8, 16)]
        [DataRow(Complexity.Lowers, 8, 16)]
        [DataRow(Complexity.Uppers, 8, 16)]
        [DataRow(Complexity.AlphaOnly, 8, 16)]
        [DataRow(Complexity.NoSymbol, 8, 16)]
        public void SpewTest(Complexity cpx, int lower, int higher)
        {
            Generator g = new Generator(cpx);

            Console.WriteLine("The complexity is: {0}", cpx.ToString());
            for (int i = lower; i <= higher; i++)
            {
                Console.WriteLine(g.Spew(i));
            }
            Assert.IsTrue(true);
        }
    }
}