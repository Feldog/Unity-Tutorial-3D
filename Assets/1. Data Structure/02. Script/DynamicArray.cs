using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>();

    private void Start()
    {
        for(int i = 1; i <= 10; i++)
        {
            list1.Add(i);
        }

        if(list1.Contains(5))
        {
            Debug.Log("List contains the number 5.");
        }
        else
        {
            Debug.Log("List does not contain the number 5.");
        }
    }
}
