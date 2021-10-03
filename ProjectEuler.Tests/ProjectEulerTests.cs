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
        public async Task Problem07_SixthPrimeNumber_ShouldBe13()
        {
            Assert.AreEqual(13,  await Problems.Problem07.FindNthPrimeNumber(6));
        }

        [TestMethod]
        public void Problem08_FourAdjacentNumbersIn1000DigitNumber_ShouldBe5832()
        {
            Assert.AreEqual(5832, Problems.Problem08.LargestProductInASeries(4, "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450"));
        }

        [TestMethod]
        public void Problem09_PythagoreanTripletWithSumOf12_ProductShouldBe60()
        {
            Assert.AreEqual(60, Problems.Problem09.PythagoreanTriplet(12));
        }

        [TestMethod]
        public async Task Problem10_SumOfPrimeNumbersBelow10_ShouldBe17()
        {
            Assert.AreEqual(17, await Problems.Problem10.SumOfPrimes(10));
        }

    }
}
