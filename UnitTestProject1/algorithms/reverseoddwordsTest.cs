using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using training.algorithms;

namespace UnitTestProject1.algorithms
{
    [TestClass]
    public class reverseoddwordsTest
    {
        [TestMethod]
        public void ShouldReverseOddWords()
        {
            Assert.AreEqual("today is fake friday".reverseOddWords(), "today si fake yadirf ");
            Assert.AreEqual(" today is fake friday".reverseOddWords(), "today si fake yadirf ");
            Assert.AreEqual("today is fake  friday".reverseOddWords(), "today si fake yadirf ");
            Assert.AreEqual("today iss fake friday".reverseOddWords(), "today ssi fake yadirf ");
        }
    }
}
