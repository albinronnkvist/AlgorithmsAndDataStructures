using Albin.AlgorithmsAndDataStructures.Core.Other;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Other;

public class BinomialCoefficientTests
{
    [Theory]
    [InlineData(4, 2, 6)]
    [InlineData(5, 3, 10)]
    [InlineData(7, 3, 35)]
    [InlineData(8, 4, 70)]
    [InlineData(10, 5, 252)]
    public void Execute_ShouldReturnExpectedCount(int n, int k, int expected)
    {
        BinomialCoefficient.Execute(n, k).Should().Be(expected);
    }
}
