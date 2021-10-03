using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectEuler.DataValidators;

namespace ProjectEuler.Problems
{
    public class Problem01
    {
        public static int SumOfMultiples(int[] multiples, int maxNumber)
        {
            int sum = 0;

            for (int i = 0; i < maxNumber; i++)
            {
                if (multiples.Any(m => i % m == 0))
                {
                    sum += i;
                }
            }

            return sum;
        }
    }

    public class Problem02
    {
        public static int EvenFibonacciNumbers(int maxValue, bool evenNumbers = true)
        {
            var sum = 0;
            int[] previousNumbers = new[] { 1, 1 };



            for (int i = 0; i < maxValue; i = previousNumbers.Sum())
            {



                if (evenNumbers && i % 2 == 0)
                {
                    sum += i;
                }
                else if (!evenNumbers && i % 2 > 0)
                {
                    sum += i;
                }

                previousNumbers[0] = previousNumbers[1];
                previousNumbers[1] = i;


            }

            return sum;
        }
    }

    public class Problem03
    {
        public static async Task<long> LargestPrimeFactor(long number)
        {
            long largestPrimeNumber = 0;
            List<long> primeNumberFactors = new List<long>();

            for (long i = 1; i < number; i++)
            {
                // Number must be divisible by the number and be a prime number
                if (number % i != 0 || !await PrimeNumberValidator.IsNumberPrime(i)) continue;

                primeNumberFactors.Add(i);

                if (primeNumberFactors.Aggregate<long, long>(1, (current, primeNumberFactor) => current * primeNumberFactor) != number) continue;

                largestPrimeNumber = i;
                break;

            }

            return largestPrimeNumber;
        }
    }

    public class Problem04
    {
        public static int PalindromicNumber(int numberOfDigits)
        {
            string maxNumberString = "1" + new string('0', numberOfDigits - 1);
            int maxNumber = int.Parse(maxNumberString);
            int largestPalindromicNumber = 0;

            for (int i = maxNumber * 10 - 1; i > maxNumber; i--)
            {
                for (int z = maxNumber * 10 - 1; z > maxNumber; z--)
                {
                    if (string.Join("", (i * z).ToString().Reverse().ToList()) == (z * i).ToString() && (i * z) > largestPalindromicNumber)
                    {
                        largestPalindromicNumber = (z * i);
                        break;
                    }
                }
            }

            return largestPalindromicNumber;
        }
    }

    public class Problem05
    {
        public static int SmallestMultiple(int fromNumber, int toNumber)
        {
            int numberTest = toNumber;
            List<int> numberRange = new List<int>();
            for (int i = fromNumber; i <= toNumber; i++)
            {
                numberRange.Add(i);
            }

            while (true)
            {
                if (numberRange.Any(n => numberTest % n > 0))
                {
                    numberTest++;
                    continue;
                }
                return numberTest;
            }
        }
    }

    public class Problem06
    {
        public static long SumSquareDifference(int fromNumber, int toNumber)
        {
            List<int> numberRange = new List<int>();

            for (int i = fromNumber; i <= toNumber; i++)
            {
                numberRange.Add(i);
            }

            long sumOfSquaredNumbers = numberRange.Sum(n => (long) Math.Pow(n,2));
            long squareOfSummedNumbers = (long) Math.Pow(numberRange.Sum(), 2);

            return squareOfSummedNumbers - sumOfSquaredNumbers;

        }
    }

    public class Problem07
    {
        public static async Task<long> FindNthPrimeNumber(int sequenceNumber)
        {
            int currentSequence = 0;
            long primeNumberTest = 1;

            while (true)
            {
                if (await PrimeNumberValidator.IsNumberPrime(primeNumberTest))
                {
                    currentSequence++;
                }

                if (currentSequence >= sequenceNumber) break;
                primeNumberTest += primeNumberTest > 2 ? 2 : 1;
            }

            return primeNumberTest;
        } 
    }

    public class Problem08
    {
        public static long LargestProductInASeries(int numberOfAdjacentNumbers, string numbers)
        {
            long largestProduct = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                // n-'0' converts number to int
                var numberTest = numbers.Skip(i).Take(numberOfAdjacentNumbers).Select(n => long.Parse(n.ToString()));
                long product = numberTest.Aggregate<long, long>(1, (total, number) => total * number);
                if (product > largestProduct) largestProduct = product;
            }

            return largestProduct;
        }
    }

    public class Problem09
    {
        public static long PythagoreanTriplet(int targetSum)
        {
            for (int a = 1; a < targetSum; a++)
            {
                for (int b = 1; b < targetSum; b++)
                {
                    for (int c = 1; c < targetSum; c++)
                    {
                        if (a * a + b * b == c * c && (a + b + c == targetSum))
                        {
                            return a * b * c;
                        }
                    }
                }
            }

            return 0;
        }
    }

    public class Problem10
    {
        public static async Task<long> SumOfPrimes(long primeNumbersBelowNumber)
        {
            long currentNumber = 1;
            List<long> primeNumbers = new List<long>();
            while (currentNumber < primeNumbersBelowNumber)
            {
                if (await PrimeNumberValidator.IsNumberPrime(currentNumber))
                {
                    primeNumbers.Add(currentNumber);
                }
                currentNumber += currentNumber > 2 ? 2 : 1;
            }
            return primeNumbers.Sum();
        }
    }
}
