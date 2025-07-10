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
            // SelectStick�� null�̰� ���ÿ� ������ ���� ���
            if (hanoiTower.selectStick == null) return;

            // SelectStick�� ���� ��ƽ�� �ٸ���, �̵� ������ ������ ���
            if (hanoiTower.selectStick != this && CanMoveDonut(hanoiTower.selectStick.PeekDonut()))
            {
                Debug.Log("Click Stick");
                PushDonut(hanoiTower.selectStick.PopDonut());
                hanoiTower.GetScore();
                hanoiTower.selectStick = null;
            }
            //  SelectStick�� ���� ��ƽ�� ���ų�, �̵� �Ұ����� ������ ���
            else
            {
                Debug.Log("Cannot Move Donut");
                hanoiTower.selectStick = null;
                return;
            }
        }
    }

    // ������ �ѹ��� ������ ���� ���� �ִ� ���Ӻ��� ���� ���� �̵� ����
    // ����ִ� ���ÿ� ������ �̵��� �� ����
    private bool CanMoveDonut(GameObject moveDonut)
    {
        GameObject donut;
        if(!stickStack.TryPeek(out donut))
        {
            // TryPeek�� ��ȯ���� false�� ���, ������ �������
            return true;
        }
        // stickStack�� ������� ���� ���, moveDonut�� �ѹ��� ������ ���� ���� �ִ� ���Ӻ��� �۾ƾ� ��
        return moveDonut.GetComponent<Donut>().donutNumber < donut.GetComponent<Donut>().donutNumber;
    }
}
