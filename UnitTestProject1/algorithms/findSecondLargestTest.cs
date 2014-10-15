using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using training.algorithms;

namespace UnitTestProject1.algorithms
{
    [TestClass]
    public class findSecondLargestTest
    {
        [TestMethod]
        public void ShouldFindSecondLargest()
        {
            Assert.AreEqual(GeneralAlgorithms.findSecondLargest(new int[] { 1, 2, 3 }), 2);
            Assert.AreEqual(GeneralAlgorithms.findSecondLargest(new int[] { 5, 2, 3 }), 3);
            Assert.AreEqual(GeneralAlgorithms.findSecondLargest(new int[] { 20, 45, 18, 3, 90, 11 }), 45);
            Assert.AreEqual(GeneralAlgorithms.findSecondLargest(new int[] { 20, 45, 18, 3, 90, 50 }), 50);
        }
    }
}
