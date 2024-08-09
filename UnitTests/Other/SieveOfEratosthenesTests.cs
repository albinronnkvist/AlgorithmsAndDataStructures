using Albin.AlgorithmsAndDataStructures.Core.Other;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Other;

public class SieveOfEratosthenesTests
{
    [Theory]
    [InlineData(10, new[] { 2, 3, 5, 7 })]
    [InlineData(20, new[] { 2, 3, 5, 7, 11, 13, 17, 19 })]
    [InlineData(47, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 })]
    [InlineData(100, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 })]
    public void Execute_ShouldReturnAllPrimeNumbersUpToLimit(int limit, int[] expectedPrimes)
    {
        SieveOfEratosthenes.Execute(limit).Should().BeEquivalentTo(expectedPrimes);
    }
}
