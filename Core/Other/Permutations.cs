namespace Albin.AlgorithmsAndDataStructures.Core.Other;

public static class Permutations
{
    public static int Execute(int n, int k)
        => Factorial.Execute(n) / Factorial.Execute(n - k);
}

/*
Permutations refer to the arrangement of items in a specific order. Unlike combinations, where the order does not matter, permutations take the order of selection into account. 
In other words, permutations focus on "how many ways can you arrange" a set of items.

If you have 3 items: {A, B, C}, the number of possible permutations is 3!=3×2×1=63!=3×2×1=6. The possible permutations are:
- ABC
- ACB
- BAC
- BCA
- CAB
- CBA

If you want to find the number of permutations of k items chosen from a set of n items, the formula is: n! / (n-k)!
*/
