using Albin.AlgorithmsAndDataStructures.Core.Other;
using FluentAssertions;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Other;

public class EuclideanTests
{
    [Theory]
    [InlineData(252, 60, 12)]
    [InlineData(1512, 444, 12)]
    [InlineData(4734, 1914, 6)]
    public void GCD_ShouldReturnGreatestCommonDivisor(int a, int b, int expectedGcd)
    {
        Euclidean.GCD(a, b).Should().Be(expectedGcd);
    }
}
