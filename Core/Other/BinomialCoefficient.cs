namespace Albin.AlgorithmsAndDataStructures.Core.Other;

public static class BinomialCoefficient
{
    public static int Execute(int n, int k)
        => Factorial.Execute(n) / (Factorial.Execute(k) * Factorial.Execute(n - k));
}

/*
1. Combinations
Combinations refer to the selection of items from a larger set where the order of selection does not matter. 
In other words, combinations focus on "how many ways can you choose a subset" of a given size from a larger set, 
without regard to the order of the elements in that subset.

For example, if you have a set of three fruits: {apple, banana, cherry}, and you want to choose two, the possible combinations are:
- {apple, banana}
- {apple, cherry}
- {banana, cherry}

2. Binomial Coefficient
The Binomial Coefficient ("n choose k") represents the number of ways to choose k elements from a set of n elements, 
without regard to the order. 
It is directly related to combinations and is calculated using the following formula: n! / k!(n-k)!
*/