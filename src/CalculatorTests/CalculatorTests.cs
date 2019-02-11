using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestAddMethod()
        {
            var answer = CalculaterLibrary.Calculator.Add(1, 2);
            Assert.AreEqual(3, answer);
        }

        [TestMethod]
        public void TestSubtractMethod()
        {
            var answer = CalculaterLibrary.Calculator.Subtract(2, 1);
            Assert.AreEqual(1, answer);
        }

        [TestMethod]
        public void TestDivideMethod()
        {
            var answer = CalculaterLibrary.Calculator.Divide(4, 2);
            Assert.AreEqual(2, answer);
        }

        [TestMethod]
        public void TestMultiplyMethod()
        {
            var answer = CalculaterLibrary.Calculator.Multiply(3, 2);
            Assert.AreEqual(6, answer);
        }
    }
}
