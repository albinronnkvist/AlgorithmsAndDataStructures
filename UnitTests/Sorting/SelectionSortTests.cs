﻿using Albin.AlgorithmsAndDataStructures.Core.Sorting;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Sorting;

public class SelectionSortTests
{
    [Fact]
    public void SelectionSort_Sort_ReturnsSortedArray()
    {
        int[] unsorted = { 64, 34, 25, 12, 22, 11, 90 };
        int[] expected = { 11, 12, 22, 25, 34, 64, 90 };

        var sorted = SelectionSort.Sort(unsorted);

        Assert.Equal(expected, sorted);
    }
}
