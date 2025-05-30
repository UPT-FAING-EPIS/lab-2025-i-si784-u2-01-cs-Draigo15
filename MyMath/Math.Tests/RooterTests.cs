using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math.Lib;

namespace Math.Tests
{
     [TestClass]
    public class RooterTests
    {
        [TestMethod]
        public void BasicRooterTest()
        {
            Rooter rooter = new Rooter();
            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);
        }

        [TestMethod]
        public void RooterValueRange()
        {
            Rooter rooter = new Rooter();
            for (double expected = 1e-8; expected < 1e+8; expected *= 3.2)
            {
                RooterOneValue(rooter, expected);
            }
        }

        private void RooterOneValue(Rooter rooter, double expectedResult)
        {
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000);
        }

        [TestMethod]
        public void RooterTestNegativeInput()
        {
            Rooter rooter = new Rooter();
            try
            {
                rooter.SquareRoot(-10);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, "El valor ingresado es invalido, solo se puede ingresar números positivos");
                return;
            }
            Assert.Fail("Expected ArgumentOutOfRangeException for negative input with a specific message.");
        }

        [TestMethod]
        public void RooterTestZeroInput()
        {
            Rooter rooter = new Rooter();
            try
            {
                rooter.SquareRoot(0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains(ex.Message, "El valor ingresado es invalido, solo se puede ingresar números positivos");
                return;
            }
            Assert.Fail("Expected ArgumentOutOfRangeException for input zero with a specific message.");
        }

        [TestMethod]
        public void RooterTestOneInput()
        {
            Rooter rooter = new Rooter();
            double expectedResult = 1.0;
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000);
        }

    }

}