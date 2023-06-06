namespace Albin.AlgorithmsAndDataStructures.Core.Sorting;
public static class InsertionSort
{
    public static int[] Sort(int[] arr)
    {
        var n = arr.Length;
        for (var i = 1; i < n; i++)
        {
            var key = arr[i];
            var j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }

        return arr;
    }
}
