using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Tests
{
    [TestClass]
    public class ProjectEulerTests
    {

        // MethodName_Condition_Expectation
        [TestMethod]
        public void Problem01_MultiplesOf3And5Below10_ShouldReturn23()
        {
            Assert.AreEqual(23, Problems.Problem01.SumOfMultiples(new[] { 3, 5 }, 10));
        }

        [TestMethod]
        public void Problem02_EvenFibonacciNumberFirstTen_ShouldReturn44()
        {
            Assert.AreEqual(44, Problems.Problem02.EvenFibonacciNumbers(90));
        }

        [TestMethod]
        public async Task Problem03_LargestPrimeNumberOf13195_ShouldBe29()
        {
            Assert.AreEqual(29, await Problems.Problem03.LargestPrimeFactor(13195));
        }

        [TestMethod]
        public void Problem04_LargestTwoDigitPalindromicNumber_ShouldBe9009()
        {
            Assert.AreEqual(9009, Problems.Problem04.PalindromicNumber(2));
        }

        [TestMethod]
        public void Problem05_SmallestMultipleFromOneToTen_ShouldBe2520()
        {
            Assert.AreEqual(2520, Problems.Problem05.SmallestMultiple(1,10));
        }

        [TestMethod]
        public void Problem06_SumSquareDifferenceFromOneToTen_ShouldBe2640()
        {
            Assert.AreEqual(2640, Problems.Problem06.SumSquareDifference(1, 10));
        }

        [TestMethod]
        public async void Problem07_SixthPrimeNumber_ShouldBe13()
        {
            Assert.AreEqual(13, await Problems.Problem07.FindPrimeNumber(6));
        }
    }
}
