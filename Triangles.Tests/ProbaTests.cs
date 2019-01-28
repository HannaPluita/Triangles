using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangles.Tests
{
    [TestClass]
    public class ProbaTests
    {
        [TestMethod]
        public void Proba_2plus3_expected5()
        {
            byte a = 2;
            byte b = 3;

            int c = a + b;
            byte exp = 5;

            Assert.AreEqual(c, exp, "\nError of adding.");
        }
    }
}
