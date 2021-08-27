using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class IngreExplainBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject explainObj;
    Transform cursorPoint;

    private void Start()
    {
        explainObj = GameObject.Find("MakeRoom").transform.Find("IngreText").gameObject;
        cursorPoint = explainObj.transform;
    }

    private void Update()
    {
        MouseMoving();
    }

    // 설명이 마우스 따라다니는 함수
    private void MouseMoving()
    {
        cursorPoint.localPosition = new Vector2(Input.mousePosition.x - (Screen.width / 2) + 8,
                                                Input.mousePosition.y - (Screen.height / 2) + 1);

    }

    // text에 설명 넣는 함수
    public void ShowExplain()
    {
        TextMeshProUGUI explainText = explainObj.GetComponentInChildren<TextMeshProUGUI>();
        explainText.text = gameObject.name;
    }
    // 오브젝트 범위안에 들어가면 활성화시키는 함수
    public void OnPointerEnter(PointerEventData eventData)
    {
        explainObj.SetActive(true);
        ShowExplain();
    }
    // 오브젝트 범위밖으로 나가면 비활성화 시키는 함수
    public void OnPointerExit(PointerEventData eventData)
    {
        explainObj.SetActive(false);
    }
}
