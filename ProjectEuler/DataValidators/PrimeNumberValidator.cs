using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler.DataValidators
{
    public class PrimeNumberValidator
    {
        public static async Task<bool> IsNumberPrime(long number)
        {
            if (number == 1 || number == 0) return false;
            if (number == 2 || number == 5) return true;
            if (number % 2 == 0 || number % 5 == 0) return false;

            // The only way this number is a prime number at this point is if it is divisible by numbers ending with 1, 3, 7, and 9.
            var squareRootValue = Math.Ceiling(Math.Sqrt(number));

            List<Task<bool>> primeTasks = new List<Task<bool>>(4);
            int[] lowestPrimeNumbers = { 11, 3, 7, 9 };
            var cancellationToken = new CancellationTokenSource();

            foreach (var endingPrimeNumber in lowestPrimeNumbers)
            {
                primeTasks.Add(PrimeNumberTask(squareRootValue, endingPrimeNumber, number, cancellationToken.Token));
            }


            while (primeTasks.Count > 0)
            {
                var completedTask = await Task.WhenAny(primeTasks);

                if (!await completedTask)
                {
                    cancellationToken.Cancel();
                    return false;
                }

                primeTasks.Remove(completedTask);
            }

            return true;
        }

        private static Task<bool> PrimeNumberTask(double squareRootValue, long startNumber, long primeNumberTest, CancellationToken token)
        {
            return Task.Run(() =>
            {
                for (var i = startNumber; i <= squareRootValue; i += 10)
                {
                    if (primeNumberTest % i != 0) continue;

                    return false;
                }

                return true;
            }, token);
        }
    }
}