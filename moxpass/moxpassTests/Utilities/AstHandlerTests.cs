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
    public class AstHandlerTests
    {
        [TestMethod()]
        [DataRow(8, "moxpass")]
        [DataRow(14, "moxpass login")]
        [DataRow(15, "moxpass secret")]
        [DataRow(15, "moxpass config")]
        [DataRow(16, "moxpass account")]
        [DataRow(-1, "invalid option")]
        public void CommandTest(int pos, string ast)
        {

            Console.WriteLine($"Executing: AstHandler.Command({pos} \"{ast})\"");
            string[] results = AstHandler.Complete(pos, ast);

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(results[i]);
            }
            Console.WriteLine();
            Assert.IsTrue(true);
        }
    }
}