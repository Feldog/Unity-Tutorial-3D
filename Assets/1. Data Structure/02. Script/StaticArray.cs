using UnityEngine;

public class StaticArray : MonoBehaviour
{
    public int[] array1;
    public int[] array2 = {10, 20, 30, 40, 50};
    public int[] array3 = new int[5];
    public int[] array4 = new int[5] {1, 2, 3, 4, 5};

    private void Start()
    {
        array1 = new int[5];
    }
}
