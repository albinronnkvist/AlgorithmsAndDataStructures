﻿using Albin.AlgorithmsAndDataStructures.Core.Algorithms.Sorting;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.Algorithms.Sorting;
public class BubbleSortTests
{
    [Fact]
    public void BubbleSort_Sort_ReturnsSortedArray()
    {
        int[] unsorted = [64, 34, 25, 12, 22, 11, 90];

        var sorted = BubbleSort.Sort(unsorted);

        sorted.Should().BeInAscendingOrder();
    }
}
