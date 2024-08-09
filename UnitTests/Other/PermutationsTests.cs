using Albin.AlgorithmsAndDataStructures.Core.Other;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Other;

public class PermutationsTests
{
    [Theory]
    [InlineData(4, 2, 12)]
    [InlineData(5, 3, 60)]
    [InlineData(7, 3, 210)]
    public void Execute_ShouldReturnExpectedCount(int n, int k, int expected)
    {
        Permutations.Execute(n, k).Should().Be(expected);
    }
}
