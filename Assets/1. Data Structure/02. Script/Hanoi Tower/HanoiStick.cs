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
        if(HanoiTower.selectStick == null)
        {
            Debug.Log("Select Stick");
            HanoiTower.selectStick = this;
        }
        else
        {
            if (HanoiTower.selectStick != this && CanMoveDonut(HanoiTower.selectStick.PeekDonut()))
            {
                Debug.Log("Click Stick");
                PushDonut(HanoiTower.selectStick.PopDonut());
                HanoiTower.selectStick = null;
            }
            else
            {
                Debug.Log("Cannot Move Donut");
                HanoiTower.selectStick = null;
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
