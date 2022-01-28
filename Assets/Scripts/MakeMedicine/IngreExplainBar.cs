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
        explainObj = GameObject.Find("MakeRoom Canvas").transform.Find("IngreText").gameObject;
        cursorPoint = explainObj.transform;
    }

    private void Update()
    {
        MouseMoving();
    }

    private void MouseMoving()
    {
        cursorPoint.localPosition = new Vector2(Input.mousePosition.x - (Screen.width / 2) + 8,
                                                Input.mousePosition.y - (Screen.height / 2) + 1);

    }

    public void ShowExplain()
    {
        TextMeshProUGUI explainText = explainObj.GetComponentInChildren<TextMeshProUGUI>();
        explainText.text = gameObject.name;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        explainObj.SetActive(true);
        ShowExplain();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        explainObj.SetActive(false);
    }
}
