namespace Albin.AlgorithmsAndDataStructures.Core.Algorithms.Sorting;

public static class SelectionSort
{
    public static int[] Sort(int[] arr)
    {
        for (var i = 0; i < arr.Length - 1; i++)
        {
            var minIndex = i;

            for (var j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
            }
        }

        return arr;
    }
}

/*
Selection sort is a simple comparison-based sorting algorithm. 
Its name comes from the idea that it repeatedly "selects" the smallest (or largest, depending on the order you're sorting in)
element from the unsorted portion of the list and moves it to the end of the sorted portion.

---

Step-by-step:

1. Find the Minimum: go through the entire list and find the smallest element. 
Keep track of this element's value and its index.

2. Swap: swap the found minimum element with the first element in the list.

3. Repeat: repeat the above steps for the rest of the list, 
i.e., consider the sublist starting from the second element to the end of the list, and so on.

---

Time complexity: O(N²), since nested loops
Space complexity: O(1), since we don't need an extra array for result
*/