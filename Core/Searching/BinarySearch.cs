namespace Albin.AlgorithmsAndDataStructures.Core.Searching;

public class BinarySearch
{
    public static int Search(int[] arr, int element)
    {
        int lowest = 0, highest = arr.Length - 1;
        while (lowest <= highest)
        {
            var mid = (lowest + highest) / 2;

            if (arr[mid] == element)
                return mid;

            if (arr[mid] < element)
                lowest = mid + 1;

            else
                highest = mid - 1;
        }

        return -1;
    }
}

/*
Binary search is an efficient algorithm that finds the position of a target value within a sorted array 
by repeatedly dividing the search interval in half. The process continues until the target value is 
found or the interval is empty, making it a practical choice for searching in large data sets.

Note that this only works if the array is already sorted. 

---

Step-by-step:

1. Find the Middle Element: 
Begin by finding the middle element of the sorted array. 
If the array has an odd number of items, this is straightforward. 
If it has an even number, there are two middle elements, so just pick one (usually the first of the two).

2. Compare Middle Element with Target Value: 
Compare the middle element with the target value you are searching for.

3. If the middle element equals the target value, congratulations, you've found the item you're searching for! 
The search is over, and you can return the index of the middle element.

4. Divide and Conquer:
  - If the target value is less than the middle element, you can ignore the right half of the array. Repeat the process, but now for the left half.
  - If the target value is greater than the middle element, ignore the left half of
the array. Now, your search space is just the right half.

5. Repeat Steps 1-4: Continue this process until you either find the target value or 
exhaust the array (when the size of the search space becomes 0). 
If you've searched the entire array and the element is not found, return -1 or some indicator that the value wasn't found.

---

Time complexity: O(log n)
Space complexity: O(1)

---

Example:

If you're looking for a person's phone number in a phonebook and the names are sorted alphabetically, 
you don't flip through every page. 
Instead, you'd likely open it roughly in the middle, 
see if the name you're looking for is in the first half or second half, 
and then repeat this process in the appropriate half until you find the person's name. 
*/