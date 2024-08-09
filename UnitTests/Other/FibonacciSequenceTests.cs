using Albin.AlgorithmsAndDataStructures.Core.Other;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Other;

public class FibonacciSequenceTests
{
    [Theory]
    [InlineData(50, new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
    [InlineData(144, new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 })]
    public void Execute_ReturnsFibonacciSequence(int limit, int[] expectedSequence)
    {
        FibonacciSequence.Execute(limit).Should().BeEquivalentTo(expectedSequence);
    }
}
