using Microsoft.VisualStudio.TestTools.UnitTesting;
using moxpass.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moxpass.Config.Tests
{
    [TestClass()]
    public class SettingsTests
    {
        [TestMethod()]
        [DataRow(@"c:\users\mochen\moxpass.setting")]
        public void SettingsTest(string arg1)
        {
            var s = new Settings(arg1);

            Console.WriteLine(File.ReadAllText(arg1));
            Assert.IsTrue(true);
        }


        [TestMethod()]
        [DataRow(@"c:\users\mochen\moxpass.setting", "joedoe@company.com", "12s")]
        public void SettingsReadTest(string arg1, string exp1, string exp2)
        {
            var s = new Settings(arg1);

            Assert.AreEqual(exp1, s["User.Email"]);
            Assert.AreEqual(exp2, s["Secret.DisplayTime"]);
        }

        [TestMethod()]
        [DataRow(@"c:\users\mochen\moxpass.setting", "joedoe@company.com", "12s")]
        public void SettingsSaveTest(string arg1, string arg2, string arg3)
        {
            var s = new Settings(arg1);

            s["User.Email"] = arg2;
            s["Secret.DisplayTime"] = arg3;

            s.Save();

            Console.WriteLine(File.ReadAllText(arg1));

            Assert.IsTrue(true);
        }


    }
}