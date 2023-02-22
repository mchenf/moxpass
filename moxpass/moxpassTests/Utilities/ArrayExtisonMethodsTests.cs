using Microsoft.VisualStudio.TestTools.UnitTesting;
using moxpass.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moxpass.Utilities.Tests
{
    [TestClass()]
    public class ArrayExtisonMethodsTests
    {
        [TestMethod()]
        [DataRow(
            new int[] {0, 0, 0, 0, 0}, 
            new int[] {1, 2},
            new int[] {1, 2, 1, 2, 1})]
        public void SegmentFillTest(int[] arg1, int[] arg2, int[] expected)
        {
            arg1.SegmentFill(arg2);

        }
    }
}