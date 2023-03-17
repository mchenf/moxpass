using Microsoft.VisualStudio.TestTools.UnitTesting;
using moxpass_gui.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moxpass_gui.Data.Tests
{
    [TestClass()]
    public class AuthHandlerTests
    {
        [TestMethod()]
        [DataRow("fuck@ass", "ThisIsMyPassW0rd")]
        [DataRow("shit@fuck", "lkjdsoij8@(90")]
        [DataRow("bitch@ass", "mkcjidueyyr&")]
        public void AuthenticateTest(string email, string password)
        {
            AuthHandler authHand = new AuthHandler();
            bool checkResult = authHand.CheckAccountExist(email);
            Console.WriteLine($"1/4: Checking if {email} exist: {checkResult}");

            Assert.IsFalse(checkResult);

            bool regiResult = authHand.RegisterAccount(email, password);

            Console.WriteLine($"2/4: Checking if {email} registered correctly: {regiResult}");

            Assert.IsTrue(regiResult);

            bool authResult = authHand.Authenticate(email, "ThisIsWrongPassword");

            Console.WriteLine($"3/4: Checking if can block wrong pass: {authResult}");

            Assert.IsFalse(authResult);

            authResult = authHand.Authenticate(email, password);

            Console.WriteLine($"4/4: Checking if can authen right pass: {authResult}");

            Assert.IsTrue(authResult);
        }
    }
}