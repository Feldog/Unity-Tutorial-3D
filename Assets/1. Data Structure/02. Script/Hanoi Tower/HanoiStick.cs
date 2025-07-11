using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HanoiStick : MonoBehaviour
{
    public enum StickType
    {
        Left,
        Middle,
        Right
    }
    public StickType stickType;

    public Stack<GameObject> stickStack = new Stack<GameObject>();

    private HanoiTower hanoiTower;

    private void Start()
    {
        hanoiTower = HanoiTower.Instance;
    }

    public void PushDonut(GameObject donut)
    {
        donut.transform.position = transform.position + Vector3.up * 5f;
        donut.transform.rotation = Quaternion.identity;
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        stickStack.Push(donut);
    }

    public GameObject PopDonut()
    {
        if (stickStack.Count > 0)
        {
            
            return stickStack.Pop();
        }
        return null;
    }

    public GameObject PeekDonut()
    {
        if (stickStack.Count > 0)
        {
            return stickStack.Peek();
        }
        return null;
    }

    private void OnMouseDown()
    {
        if(hanoiTower.selectStick == null && stickStack.Count > 0)
        {
            Debug.Log("Select Stick");
            hanoiTower.selectStick = this;
        }
        else
        {
            // SelectStick이 null이고 스택에 도넛이 없는 경우
            if (hanoiTower.selectStick == null) return;

            // SelectStick이 현재 스틱과 다르고, 이동 가능한 도넛인 경우
            if (hanoiTower.selectStick != this && CanMoveDonut(hanoiTower.selectStick.PeekDonut()))
            {
                Debug.Log("Click Stick");
                PushDonut(hanoiTower.selectStick.PopDonut());
                hanoiTower.GetScore();
                hanoiTower.selectStick = null;
            }
            //  SelectStick이 현재 스틱과 같거나, 이동 불가능한 도넛인 경우
            else
            {
                Debug.Log("Cannot Move Donut");
                hanoiTower.selectStick = null;
                return;
            }
        }
    }

    // 도넛의 넘버가 스택의 가장 위에 있는 도넛보다 작을 때만 이동 가능
    // 비어있는 스택에 도넛을 이동할 수 있음
    private bool CanMoveDonut(GameObject moveDonut)
    {
        GameObject donut;
        if(!stickStack.TryPeek(out donut))
        {
            // TryPeek의 반환값이 false인 경우, 스택이 비어있음
            return true;
        }
        // stickStack이 비어있지 않은 경우, moveDonut의 넘버가 스택의 가장 위에 있는 도넛보다 작아야 함
        return moveDonut.GetComponent<Donut>().donutNumber < donut.GetComponent<Donut>().donutNumber;
    }
}
