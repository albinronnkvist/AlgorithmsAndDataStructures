namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Sorting;

public static class BubbleSort
{
    public static int[] Sort(int[] arr)
    {
        var n = arr.Length;
        for (var i = 0; i < n - 1; i++)
        {
            for (var j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j+1]
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }

        return arr;
    }
}

/*
Bubble sort works by repeatedly stepping through a list to be sorted, 
comparing each pair of adjacent items, and swapping them if they are in the wrong order. 
This pass through the list is repeated until no more swaps are needed, which indicates that the list is sorted.

---

Step-by-step:

1. Start from the first element of the list, compare it with the next element. 
If the current element is greater than the next one, swap their positions. 
If it's not, move on to the next pair (second and third elements).

2. Continue this process for each pair of adjacent elements in the list. 
At the end of this pass, the largest element would have 'bubbled up' to its correct position at the end of the list.

3. Repeat the same process for the rest of the list (from the first element to the second-to-last element), 
then for the remainder of the list, and so forth, until no more swaps are needed.

---

Time complexity:
- Best: O(n). If input array is already sorted
- Average: O(n²)
- Worst: O(n²)

Space complexity:
O(1), because only a single additional memory space is required i.e., for temp variable used for swapping.
*/