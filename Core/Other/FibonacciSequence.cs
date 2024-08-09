namespace Albin.AlgorithmsAndDataStructures.Core.Other;

public static class FibonacciSequence
{
    public static int[] Execute(int limit)
    {
        var numbers = new List<int> { 0, 1 };

        int nextNumber = 0;
        while(nextNumber < limit)
        {
            nextNumber = numbers[^2] + numbers[^1];

            if(nextNumber > limit)
            {
                break;
            }

            numbers.Add(nextNumber);
        }

        return numbers.ToArray();
    }
}

/*
The Fibonacci sequence is a series of numbers in which each number (after the first two) is the sum of the two preceding ones. 

It starts with 0 and 1, and from there, each subsequent number is formed by adding the previous two numbers together.
*/