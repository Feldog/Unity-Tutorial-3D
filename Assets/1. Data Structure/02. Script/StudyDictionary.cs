using System.Collections.Generic;
using UnityEngine;

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, int> persons = new Dictionary<string, int>();

    private void Start()
    {
        persons.Add("Alice", 25);
        persons.Add("Bob", 30);
        persons.Add("Charlie", 35);

        int age = persons["Alice"];
        Debug.Log($"Alice's age: {age}");

        foreach (var person in persons)
        {
            Debug.Log($"{person.Key} is {person.Value} years old.");
        }

        if (persons.ContainsKey("Bob"))
        {
            Debug.Log("Bob is in the dictionary.");
        }

        if (persons.ContainsValue(30))
        {
            Debug.Log("30 age is in the dictionary");
        }
    }
}
