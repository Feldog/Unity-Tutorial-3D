using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStackManager : MonoBehaviour
{
    public static UIStackManager Instance { get; private set; }

    public Stack<GameObject> uiStack = new Stack<GameObject>();
    public Button[] buttons;
    public GameObject[] popupUI;

    private void Start()
    {
        buttons[0].onClick.AddListener(PopupOn1);
        buttons[1].onClick.AddListener(PopupOn2);
        buttons[2].onClick.AddListener(PopupOn3);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && uiStack.Count > 0)
        {
            GameObject topUI = uiStack.Pop();
            topUI.SetActive(false);
        }
    }

    private void PopupOn1()
    {
        popupUI[0].SetActive(true);
        uiStack.Push(popupUI[0]);
    }
    private void PopupOn2()
    {
        popupUI[1].SetActive(true);
        uiStack.Push(popupUI[1]);
    }
    private void PopupOn3()
    {
        popupUI[2].SetActive(true);
        uiStack.Push(popupUI[2]);
    }
}
