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
            new char[] { '0', '0', '0', '0', '0', '0', '0', '0' },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's',},
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', 'm', 'o'},
            DisplayName = "Long orign short filler")]
        [DataRow(
            new char[] { '0', '0', '0', '0' },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', },
            new char[] { 'm', 'o', 'x', 'p' },
            DisplayName = "short orign long filler")]
        [DataRow(
            new char[] { '0', '0', '0', '0' , '0', '0' },
            new char[] { 'm', 'o' },
            new char[] { 'm', 'o', 'm', 'o', 'm', 'o' },
            DisplayName = "very long origin with short filler")]
        public void SegmentFillTest(char[] arg1, char[] arg2, char[] expected)
        {
            arg1.SegmentFill(arg2);

            Console.WriteLine($"arg1={string.Join(',', arg1)}");
            CollectionAssert.AreEqual(expected, arg1);
        }
    }
}