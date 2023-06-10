using Albin.AlgorithmsAndDataStructures.Core.Searching;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Searching;
public class BinarySearchTests
{
    [Fact]
    public void Search_ReturnsCorrectIndex_WhenElementExists()
    {
        var arr = new[] { 2, 3, 4, 10, 40 };
        const int element = 10;
        const int expectedIndex = 3;

        var result = BinarySearch.Search(arr, element);

        Assert.Equal(expectedIndex, result);
    }

    [Fact]
    public void Search_ReturnsMinusOne_WhenElementDoesNotExist()
    {
        var arr = new[] { 2, 3, 4, 10, 40 };
        const int element = int.MaxValue;

        var result = BinarySearch.Search(arr, element);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void Search_ReturnsCorrectIndex_WhenElementExistsInArrayWithOneElement()
    {
        var arr = new[] { 10 };
        const int element = 10;
        const int expectedIndex = 0;

        var result = BinarySearch.Search(arr, element);

        Assert.Equal(expectedIndex, result);
    }

    [Fact]
    public void Search_ReturnsMinusOne_WhenEmptyArray()
    {
        var arr = new int[] { };
        const int element = 10;

        var result = BinarySearch.Search(arr, element);

        Assert.Equal(-1, result);
    }
}