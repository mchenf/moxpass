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
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', 'm', 'o' },
            DisplayName = "Long orign short filler")]
        [DataRow(
            new char[] { '0', '0', '0', '0' },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', },
            new char[] { 'm', 'o', 'x', 'p' },
            DisplayName = "Short orign long filler")]
        [DataRow(
            new char[] { '0', '0', '0', '0', '0', '0' },
            new char[] { 'm', 'o' },
            new char[] { 'm', 'o', 'm', 'o', 'm', 'o' },
            DisplayName = "Very long origin with short filler")]
        public void SegmentFillTest(char[] arg1, char[] arg2, char[] expected)
        {
            arg1.SegmentFill(arg2);

            Console.WriteLine($"arg1={{{string.Join(',', arg1)}}}");
            CollectionAssert.AreEqual(expected, arg1);
        }

        [TestMethod()]
        [DataRow(
            new char[] { '0', '1', '2', '3', '4', '5', '6', '7' },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', },
            new char[] { '0', '1', '2', '3', '4', '5', '6', '7', 'm', 'o', 'x', 'p', 'a', 's' },
            DisplayName = "Long head short tail")]
        [DataRow(
            new char[] { '0', '2', '3', '4' },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', },
            new char[] { '0', '2', '3', '4', 'm', 'o', 'x', 'p', 'a', 's' },
            DisplayName = "Short orign long filler")]
        [DataRow(
            new char[] { '0', '3', '5', '6', '7', '8' },
            new char[] { 'm', 'o' },
            new char[] { '0', '3', '5', '6', '7', '8', 'm', 'o' },
            DisplayName = "Very long origin with short filler")]
        [DataRow(
            new char[] { '0', '3', '5', '6', '7', '8' },
            new char[0] { },
            new char[] { '0', '3', '5', '6', '7', '8' },
            DisplayName = "Trying to glue empty")]
        public void GlueWithTest(char[] arg1, char[] arg2, char[] expected)
        {
            char[] result = arg1.GlueWith(arg2);
            Console.WriteLine($"arg1={{{string.Join(',', result)}}}");
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        [DataRow(
            new char[] { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', },
            new char[] { 'y', 'r', 't'},
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', 'y', 'r', 't', 'y', 'r', 't', 'y', 'r', 't', 'y' },
            DisplayName = "Long origin, short head, repeat filler >1 times")]
        [DataRow(
            new char[] { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' },
            new char[0] { },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', 'm', 'o', 'x', 'p', 'a', 's', 'm', 'o', 'x', 'p' },
            DisplayName = "Long origin, no head, repeat filler >1 times")]
        [DataRow(
            new char[] { '0', '0', '0', '0' },
            new char[] { 'y', 'r', 't' },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', },
            new char[] { 'y', 'r', 't', 'm' },
            DisplayName = "Short orign, short head, filler <1 times")]
        [DataRow(
            new char[] { '0', '0' },
            new char[] { 'm', 'o', 'x', 'p', 'a', 's', },
            new char[] { 'y', 'r', 't' },
            new char[] { 'm', 'o' },
            DisplayName = "Short origin, long head, no filler")]

        public void SegmentFillTest1(
            char[] arg1, 
            char[] arg2, 
            char[] arg3, 
            char[] expected)
        {
            arg1.SegmentFill(arg2, arg3);
            Console.WriteLine($"arg1={{{string.Join(',', arg1)}}}");
            CollectionAssert.AreEqual(expected, arg1);
        }
    }
}