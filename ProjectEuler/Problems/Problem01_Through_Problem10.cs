using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                if (number % i != 0 || !await IsNumberPrime(i)) continue;

                primeNumberFactors.Add(i);

                if (primeNumberFactors.Aggregate<long, long>(1, (current, primeNumberFactor) => current * primeNumberFactor) != number) continue;

                largestPrimeNumber = i;
                break;

            }

            return largestPrimeNumber;
        }

        public static async Task<bool> IsNumberPrime(long number)
        {
            if (number == 1 || number == 0) return false;
            if (number == 2 || number == 5) return true;

            if (number % 2 == 0 || number % 5 == 0)
            {
                Debug.WriteLine("Number is not prime because it is divisible by 2 or 5");
                return false;
            }

            // The only way this number is a prime number at this point is if it is divisible by numbers ending with 1, 3, 7, and 9.
            var squareRootValue = Math.Ceiling(Math.Sqrt(number));

            List<Task<bool>> primeTasks = new List<Task<bool>>(4);
            int[] lowestPrimeNumbers = {11, 3, 7, 9};
            var cancellationToken = new CancellationTokenSource();
            var cancelToken = cancellationToken.Token;

            try
            {
                foreach (var endingPrimeNumber in lowestPrimeNumbers)
                {
                    primeTasks.Add(PrimeNumberTask(squareRootValue, endingPrimeNumber, number, cancellationToken.Token));
                }

                var completedTask = Task.WhenAny(primeTasks);

                //cancellationToken.Cancel();
                if (!completedTask.Result.Result)
                {
                    cancellationToken.Cancel();
                    return false;
                }


                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
                return false;
            }

        }

        private static Task<bool> PrimeNumberTask(double squareRootValue, long startNumber, long primeNumberTest, CancellationToken token)
        {

            return Task.Factory.StartNew(() =>
            {
                try
                {
                    for (var i = startNumber; i <= squareRootValue; i += 10)
                    {
                        //token.ThrowIfCancellationRequested();

                        if (primeNumberTest % i == 0)
                        {
                            Debug.WriteLine("{0} is not a prime number because it is divisible by {1}.  Current Thread {2}", primeNumberTest, i, Thread.CurrentThread.ManagedThreadId);

                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }



            }, token);
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
        public static async Task<long> FindPrimeNumber(int sequenceNumber)
        {
            int currentSequence = 1;
            long primeNumberTest = 1;
            while (currentSequence < sequenceNumber)
            {
                if (await Problem03.IsNumberPrime(primeNumberTest))
                {
                    currentSequence++;
                }
                primeNumberTest++;
            }

            return primeNumberTest;
        } 
    }
}
