namespace Albin.AlgorithmsAndDataStructures.Core.Other;

public static class Euclidean
{
    public static int GCD(int a, int b)
    {
        var remainder = a % b;

        if (remainder is 0)
        {
            return b;
        }

        return GCD(b, remainder);
    }
}

/*
Euclid's algorithm is a method to compute the greatest common divisor (GCD) of two integers. The GCD is the largest number that divides both integers without leaving a remainder.

The algorithm is based on the principle that the GCD of two numbers also divides their difference. 
If you keep replacing the larger number by the remainder of dividing the larger by the smaller, eventually, 
the smaller number will become the GCD when the remainder becomes zero.

Steps:
- Given two integers, divide the larger number by the smaller number.
- Replace the larger number with the smaller number, and the smaller number with the remainder from step 1.
- The non-zero remainder from the last division before reaching zero is the GCD.
*/