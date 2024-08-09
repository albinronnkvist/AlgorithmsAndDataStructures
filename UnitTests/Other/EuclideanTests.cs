using Albin.AlgorithmsAndDataStructures.Core.Other;

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

    [Theory]
    [InlineData(12, 18, 36)]
    [InlineData(4711, 777, 522921)]
    public void LCM_ShouldReturnLeastCommonMultiple(int a, int b, int expectedLcm)
    {
        Euclidean.LCM(a, b).Should().Be(expectedLcm);
    }
}
