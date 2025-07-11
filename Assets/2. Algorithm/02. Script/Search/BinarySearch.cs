using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    public int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    public int target = 7;

    private void Start()
    {
        Debug.Log(BSearch());
    }

    private int BSearch()
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (array[mid] == target) return mid;
            else if (array[mid] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        // Search Failed
        return -1;
    }
}
