using System;
using System.Threading.Tasks;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Problem01: Sum of the multiples of {0} is: {1}", 1000, Problem01.SumOfMultiples(new[] {3, 5}, 1000));
            Console.WriteLine("Problem02: Even fibonacci numbers below {0} is: {1}", 4000000, Problem02.EvenFibonacciNumbers(4000000));
            Console.WriteLine("Problem03: The largest prime factor of {0} is: {1}", 600851475143, Task.Run(async () => await Problem03.LargestPrimeFactor(600851475143)).Result);
            Console.WriteLine("Problem04: The largest {0}-digit palindrome is: {1}", 3, Problem04.PalindromicNumber(3));
            Console.WriteLine("Problem05: The smallest multiple of numbers 1 to 20 is: {0}", Problem05.SmallestMultiple(1,20));
            Console.WriteLine("Problem06: {0}", Problem06.SumSquareDifference(1, 100));
            Console.ReadKey();
        }
    }
}
