using Albin.AlgorithmsAndDataStructures.Core.Sorting;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Sorting;
public class InsertionSortTests
{
    [Fact]
    public void InsertionSort_Sort_ReturnsSortedArray()
    {
        int[] unsorted = [64, 34, 25, 12, 22, 11, 90];

        var sorted = InsertionSort.Sort(unsorted);

        sorted.Should().BeInAscendingOrder();
    }
}
