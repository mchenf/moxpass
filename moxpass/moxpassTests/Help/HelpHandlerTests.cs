using Microsoft.VisualStudio.TestTools.UnitTesting;
using moxpass.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moxpass.Help.Tests
{
    [TestClass()]
    public class HelpHandlerTests
    {
        [TestMethod()]
        [DataRow(@"https://developer.mozilla.org/en-US/docs/Web/HTML/Element/a", DisplayName = "Mozilla")]
        [DataRow(@"https://github.com/mchenf/moxpass/wiki/moxpass", DisplayName = "Github mchenf moxpass")]
        public async Task PrintHelpTest(string arg1)
        {
            await HelpHandler.PrintHelp(arg1);
            await Task.Run(() => { Assert.IsTrue(true); });
        }
    }
}