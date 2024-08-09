namespace Albin.AlgorithmsAndDataStructures.Core.Other;

public static class SieveOfEratosthenes
{
    public static int[] Execute(int n) 
    {
        var numbers = new Dictionary<int, bool>();
        for (var i = 2; i <= n; i++)
        {
            numbers.Add(i, true);
        }

        for (var i = 2; i * i <= n; i++)
        {
            if (numbers[i] is false) 
            {
                continue;
            }

            for (var multiple = i * i; multiple <= n; multiple += i)
            {
                numbers[multiple] = false;
            }
        }

        return numbers
            .Where(x => x.Value is true)
            .Select(x => x.Key)
            .ToArray();
    }
}

/*
The Sieve of Eratosthenes is an ancient algorithm used to find all prime numbers up to a specified integer. 

It works by iteratively marking the multiples of each prime number starting from 2, the first prime number. 
The remaining unmarked numbers are primes.
*/