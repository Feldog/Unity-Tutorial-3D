using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel {         
        Easy = 3,
        Medium = 4,
        Hard = 5
    }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs;
    public HanoiStick[] sticks;

    public static HanoiStick selectStick;
    public GameObject select;
    public Vector3 offset;

    IEnumerator Start()
    {
        for(int i = (int)hanoiLevel - 1; i >= 0 ; i--)
        {
            GameObject donut = Instantiate(donutPrefabs[i]);
            
            sticks[0].PushDonut(donut);

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Update()
    {
        if(selectStick != null)
        {
            if(select.activeSelf == false)
            {
                select.SetActive(true);
            }
            select.transform.position = selectStick.transform.position + offset;
        }
        else if(select.activeSelf)
        {
            select.SetActive(false);
        }
    }
}
