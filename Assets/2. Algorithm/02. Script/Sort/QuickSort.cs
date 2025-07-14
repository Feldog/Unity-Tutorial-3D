using UnityEngine;

public class QuickSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start()
    {
        Debug.Log($"정렬 전 : {string.Join(", ", array)}");
        QSort(array, 0, array.Length - 1);
        Debug.Log($"정렬 후 : {string.Join(", ", array)}");
    }

    void QSort(int[] arr, int left, int right)
    {
        if (left < right) // element가 1개 남을 때까지
        {
            int pivot = Partition(array, left, right);

            QSort(arr, left, pivot - 1);
            QSort(arr, pivot + 1, right);
        }
    }

    int Partition(int[] arr, int left, int right) // 분할 후 정복하는 기능
    {
        int pivot = arr[right];
        int index = left - 1;

        for (int i = left; i < right; i++)
        {
            if (arr[i] < pivot)
            {
                index++;

                int temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
                Debug.Log(string.Join(", ", arr));
            }
        }

        int temp2 = arr[index + 1];
        arr[index + 1] = arr[right];
        arr[right] = temp2;

        return index + 1;
    }
}