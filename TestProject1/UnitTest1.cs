using ExprLib;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("123 + 123") == "CCXLVI");
        }

        [TestMethod]
        public void TestMethod2()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("(123 + 123)") == "CCXLVI");
        }

        [TestMethod]
        public void TestMethod3()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("(1 + 1) + 223") == "CCXXV");
        }

        [TestMethod]
        public void TestMethod4()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("(1 + 1)") == "II");
        }

        [TestMethod]
        public void TestMethod5()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("1 + 1") == "II");
        }

        [TestMethod]
        public void TestMethod6()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("1 + 1 + 1") == "III");
        }

        [TestMethod]
        public void TestMethod7()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("(1 + 1 + 1) + 1") == "IV");
        }

        [TestMethod]
        public void TestMethod8()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("(1 + 1) + (1 + 1)") == "IV");
        }

        [TestMethod]
        public void TestMethod10()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("1 + 1 - 1") == "I");
        }

        [TestMethod]
        public void TestMethod13()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("2*2") == "IV");
        }

        [TestMethod]
        public void TestMethod14()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("(3 + 2) * 2") == "X");
        }

        [TestMethod]
        public void TestMethod15()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("(3 + 2) * (2 + 1)") == "XV");
        }

        [TestMethod]
        public void TestMethod16()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("4 * (2 + 1)") == "XII");
        }

        [TestMethod]
        public void TestMethod17()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("(2 + 1) * 2 + 3") == "IX");
        }

        [TestMethod]
        public void TestMethod18()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("2 * (20 - 1) * 2") == "LXXVI");
        }

        [TestMethod]
        public void TestMethod19()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("II + II") == "IV");
        }

        [TestMethod]
        public void TestMethod20()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("(MMMDCCXXIV - MMCCXXIX) * II") == "MMCMXC");
        }

        [TestMethod]
        public void TestMethod21()
        {
            RomanHelper helper = new RomanHelper();
            Assert.IsTrue(helper.Evaluate("(MMMDCCXXIV - MMCCXXIX) * II + IIIVIVIX") == "MMMIX");
        }
    }
}