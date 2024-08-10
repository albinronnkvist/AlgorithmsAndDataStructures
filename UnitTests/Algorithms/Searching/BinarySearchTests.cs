using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Searching;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Searching;

public class BinarySearchTests
{
    [Fact]
    public void Search_ReturnsCorrectIndex_WhenElementExists()
    {
        var arr = new[] { 2, 3, 4, 10, 40 };
        const int element = 10;
        const int expectedIndex = 3;

        var result = BinarySearch.Search(arr, element);

        result.Should().Be(expectedIndex);
    }

    [Fact]
    public void Search_ReturnsMinusOne_WhenElementDoesNotExist()
    {
        var arr = new[] { 2, 3, 4, 10, 40 };
        const int element = int.MaxValue;

        var result = BinarySearch.Search(arr, element);

        result.Should().Be(-1);
    }

    [Fact]
    public void Search_ReturnsCorrectIndex_WhenElementExistsInArrayWithOneElement()
    {
        var arr = new[] { 10 };
        const int element = 10;
        const int expectedIndex = 0;

        var result = BinarySearch.Search(arr, element);

        result.Should().Be(expectedIndex);
    }

    [Fact]
    public void Search_ReturnsMinusOne_WhenEmptyArray()
    {
        var arr = Array.Empty<int>();
        const int element = 10;

        var result = BinarySearch.Search(arr, element);

        result.Should().Be(-1);
    }
}