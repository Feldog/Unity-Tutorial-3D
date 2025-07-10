using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public GameObject objPrefab;

    public Transform parent;
    public Queue<GameObject> objectQueue = new Queue<GameObject>();

    public int poolSize = 100;


    private void Start()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objPrefab, parent);
            obj.GetComponent<PoolObject>().SetObjectPoolQueue(this);
            EnqueueObject(obj);
        }
    }

    public void EnqueueObject(GameObject obj)
    {
        objectQueue.Enqueue(obj);
        obj.SetActive(false);
    }

    public GameObject DequeueObject()
    {
        if(objectQueue.Count < 5)
        {
            CreateObject();
        }

        GameObject obj = objectQueue.Dequeue();
        obj.SetActive(true);
        return obj;
    }
}
