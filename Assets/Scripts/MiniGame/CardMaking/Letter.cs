using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Letter: MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject AfterImage;

    GameObject canvas;
    DragDrop dd;
    RectTransform rt;
    
    bool isEnter = false;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        dd = GameObject.FindObjectOfType<DragDrop>().GetComponent<DragDrop>(); //Hierachy -> DragDrop 스크립트를 가지고 있는 오브젝트를 찾는다
        rt = canvas.transform.GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }

    //편지지 안에 데코가 들어왔을 때
    public void OnPointerEnter(PointerEventData eventData)
    {
        isEnter = true;
    }

    //편지지 안에 데코가 나갔을 때
    public void OnPointerExit(PointerEventData eventData)
    {
        isEnter = false;
    }

    public bool GetEnter()
    {
        return isEnter;
    }
}
